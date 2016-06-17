using UnityEngine;
using System.Collections;

public class TextManager : MonoBehaviour {

	public GameObject[] textObject;
	public GameObject finPic;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (TextAnima());
	}

	IEnumerator TextAnima(){
		for (int i = 0; i < textObject.Length; i++) {
			textObject [i].SetActive (true);
			yield return new WaitForSeconds(6.5f);
		}
		finPic.SetActive (true);
		//yield return new WaitForSeconds (3f);
		//Application.LoadLevel (0);
	}
}
