using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpriteManager : MonoBehaviour {
	public Sprite[] storySprite;
	public GameObject storyImage;
	public GameObject textBox;
	public GameObject enemyTeamManager;
	TextBoxManager textBoxManager;
	Image storyPic;
	EnemyTeamManager enemyTMFinaly;
	Door door;
	// Use this for initialization
	void Start () {
		textBoxManager = textBox.GetComponent<TextBoxManager> ();
		storyPic = storyImage.GetComponent<Image> ();
		enemyTMFinaly = enemyTeamManager.GetComponent<EnemyTeamManager> ();
		door = GameObject.Find ("DoorInOut").GetComponent<Door> ();
	}
	
	// Update is called once per frame
	void Update () {
		//var storyPic = storyImage.GetComponent<Image> ();
		if (storyImage.activeInHierarchy)
        {
			if (!door.goIn)
            {
                if (textBoxManager.currentLine >= 11)
                {
                    storyPic.color = new Color(1, 1, 1, 1);
                    storyPic.sprite = storySprite[2];
                }
                else
                {
                    storyPic.color = new Color(1,1,1,0);
                }
			}
            else
            {

				if (textBoxManager.currentLine == 1)
                {
					Debug.Log ("321");
					storyPic.sprite = storySprite [0];
				} else if (textBoxManager.currentLine == 6)
                {
					Debug.Log ("323211");
					storyPic.sprite = storySprite [1];
				}
			}
		}
	}
}
