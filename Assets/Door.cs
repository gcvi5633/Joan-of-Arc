using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public Transform inDoor,outDoor;
	public GameObject storyZone1,storyZone2;
	public bool getOut =true,goIn = true,story1dis =false,story2dis = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!storyZone1) {
			story1dis = true;
		}
		if (!storyZone2) {
			story2dis = true;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			if (getOut && story1dis) {
				other.transform.parent.position = outDoor.position;
				getOut = false;
			} else if (goIn && story2dis) {
				other.transform.parent.position = inDoor.position;
				goIn = false;
			}
		}
	}
}
