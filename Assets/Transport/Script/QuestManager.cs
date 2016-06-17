using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestManager : MonoBehaviour {

	public Text questTextGameObject;
	public string questText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeQuestText(){
		questTextGameObject.text = questText;
	}
}
