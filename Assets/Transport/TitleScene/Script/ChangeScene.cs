using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public int sceneNumber;
    public Image titleImage;

    public Text helpText;
    int a = 0;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
            a++;
		}
        if (a==1)
        {
            if (titleImage && helpText)
            {
                titleImage.gameObject.SetActive(false);
                helpText.gameObject.SetActive(true);
            }
            else
                a = 2;
        }
        else if (a==2)
        {

            SceneManager.LoadScene(sceneNumber);
        }
	}
}
