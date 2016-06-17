using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;
    public GameObject missionList;
    public GameObject headSprite;
	public GameObject storyImage;
	public string NPCName;
	public Text speakerName;
    public Text theText;

    public TextAsset textFile;

    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    //public PlayerController player;
	public bool lookStoryPic;
    public bool isActive;
    public bool stopPlayerMovement;

    private bool isTyping = false;
    private bool cancelTyping = false;

    public float tyoeSpeed;

    // Use this for initialization
    void Start()
    {
        //player = FindObjectOfType<PlayerController>();
        
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0) {
            endAtLine = textLines.Length - 1;
        }
        if(isActive) {
            EnableTextBox();
        }else {
            DisableTextBox();
        }
        if (missionList)
        {

            missionList.SetActive(!textBox.activeInHierarchy);
        }
    }

    // Update is called once per frame
    void Update () {
        if(!isActive) {
            return;
        }
        
        //theText.text = textLines[currentLine];

		if (Input.GetKeyDown(KeyCode.Space)) {
            if(!isTyping) {
                currentLine += 1;
                if (currentLine > endAtLine)
                {
                    DisableTextBox();
                    ActivateTextAtLine a = FindObjectOfType<ActivateTextAtLine>();
                    //a.waitForPress = true;
				}else {
					CheckSpeakerName();

                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else if(isTyping && !cancelTyping) {
                cancelTyping = true;
            }
        }
	}

	public void NextLine()
	{
		if (!isTyping)
		{
			currentLine += 1;
			if (currentLine > endAtLine)
			{
				DisableTextBox();
			}
			else {
				StartCoroutine(TextScroll(textLines[currentLine]));
			}
		}
		else if (isTyping && !cancelTyping)
		{
			cancelTyping = true;
		}
	}

    private IEnumerator TextScroll(string lineOfText) {
        int latter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;

        while(isTyping && !cancelTyping && (latter < lineOfText.Length-1)) {

            theText.text += lineOfText[latter];
            latter++;
            yield return new WaitForSeconds(tyoeSpeed);
        }
        theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

	void CheckSpeakerName(){
		if(textLines[currentLine] == "NPC"){
			speakerName.text = NPCName;
			currentLine+=1;
		}else if(textLines[currentLine] == "Player"){
			speakerName.text = "貞德";
			currentLine+=1;
		}
	}

    public void EnableTextBox() {
		if (lookStoryPic) {
			storyImage.SetActive(true);
		}
		//Time.timeScale = 0;
        textBox.SetActive(true);
        if (missionList)
        {

            missionList.SetActive(!textBox.activeInHierarchy);
        }
        isActive = true;
        /*if(stopPlayerMovement) {
            player.canMove = false;
        }*/

		CheckSpeakerName ();
        StartCoroutine(TextScroll(textLines[currentLine]));
    }

    public void DisableTextBox()
    {
		Time.timeScale = 1;
		currentLine = 0;
		lookStoryPic = false;
		if (storyImage) {
			storyImage.SetActive (false);
		}
        textBox.SetActive(false);
        if (missionList)
        {

            missionList.SetActive(!textBox.activeInHierarchy);
        }
        isActive = false;
        //player.canMove = true;
    }

    public void ReloadScript(TextAsset theText) {
        if(theText!=null) {
            textLines = new string[0];
            textLines = (theText.text.Split('\n'));
        }
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
    }
}
