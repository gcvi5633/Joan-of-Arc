using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	EnemyManager ene;

	// Use this for initialization
	void Start () {
		ene = FindObjectOfType<EnemyManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Keypad1)) {
			ene.status =0;
		} else if (Input.GetKeyDown (KeyCode.Keypad2)) {
			ene.status =1;
		}else if (Input.GetKeyDown (KeyCode.Keypad3)) {
			ene.status =2;
		}
		if (Input.GetKeyDown (KeyCode.Minus)) {
			GetComponent<BattleManager> ().blood = 0;
		}
	}
}
