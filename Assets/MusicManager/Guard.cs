using UnityEngine;
using System.Collections;

public class Guard : MonoBehaviour {

	public GameObject guard;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			guard.SetActive (true);
		}
	}
}
