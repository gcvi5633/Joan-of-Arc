using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextScene : MonoBehaviour {
	public GameObject textBox;
	public int sceneName;
	TextBoxManager thetextBox;
	bool change =false;
	// Use this for initialization
	void Start () {
		thetextBox = FindObjectOfType<TextBoxManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	    if (thetextBox.currentLine >= 8) {
			change =true;
		}else if (Input.GetKeyDown (KeyCode.Alpha1)) {
			ChangeScene();
		}
		if (change) {
			Invoke("ChangeScene",2f);
		}

	}

	void ChangeScene(){
        SceneManager.LoadScene(sceneName);

    }
}
