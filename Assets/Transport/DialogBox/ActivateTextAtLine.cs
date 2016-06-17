using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset theText;

	public GameObject connectStory;
	public GameObject lookAt;
    public int startLine;
    public int endLine;

	public string thisNPCName;
    public TextBoxManager theTextBox;

    public bool requireButtonPress;
    public bool waitForPress;
	public bool lookStoryPic;
    public bool destroyWhenActivated;

    public Sprite npcSprite;
    
    public bool autoTrigger;

	GameObject target;

	GameObject thisParent;
	// Use this for initialization
	void Start () {
		thisParent = this.transform.parent.gameObject;
        theTextBox = FindObjectOfType<TextBoxManager>();
		target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(waitForPress && Input.GetKeyDown(KeyCode.E)) {
            StartTalk();
        }
        
	}
    public void StartTalk() {
        waitForPress = false;
		if (lookStoryPic) {
			theTextBox.lookStoryPic = true;
		}
        //theTextBox.headSprite.GetComponent<Image>().sprite = npcSprite;
        
        theTextBox.NPCName = thisNPCName;
        theTextBox.currentLine = startLine;
        theTextBox.endAtLine = endLine;
        theTextBox.stopPlayerMovement = true;
        theTextBox.ReloadScript(theText);
        theTextBox.EnableTextBox();
		if (connectStory) {
			lookAt.GetComponent<Enforce> ().target = connectStory.transform;
		}
        if(destroyWhenActivated) {
            if (connectStory != null)
            {
                connectStory.SetActive(true);
            }
			this.GetComponent<QuestManager>().ChangeQuestText();

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            if(autoTrigger) {
                
                StartTalk();
            }
            if(requireButtonPress) {
                waitForPress = true;
                return;
            }
            
        }
        
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            waitForPress = false;
        }
    }
}
