using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {

	public GameObject largeMap;
	public GameObject miniMap;
	public GameObject dialogBox;
	public GameObject canvas;

	bool openLargeMap = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogBox.activeInHierarchy || largeMap.activeInHierarchy) {
			miniMap.SetActive (false);
		} else {
			miniMap.SetActive (true);
		}
		if (largeMap.activeInHierarchy) {
			canvas.SetActive (false);
		} else {
			canvas.SetActive (true);
		}
        if (Input.GetKeyDown(KeyCode.M))
        {
            openLargeMap = !openLargeMap;
            largeMap.SetActive(openLargeMap);
        }
    }
}
