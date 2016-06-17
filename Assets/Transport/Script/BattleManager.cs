using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour {

    public GameObject lookAt;
    public GameObject soldierCollider1;
	public GameObject soldierCollider2;

    public GameObject dialobox;
	public Transform originPos;
	public int blood;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Minus)) {
			blood =0;
		}
		if (this.gameObject.GetComponent<EnemyManager> ().isKyoukan) {
			StartBattle ();
		}
		FinishBattle ();
	}
	void FinishBattle(){
		if (blood <= 0) {
            //this.transform.position = new Vector3(originPos.position.x,this.transform.position.y,originPos.position.z);
            if (soldierCollider2) {
				soldierCollider2.SetActive (true);
                lookAt.GetComponent<Enforce>().target = soldierCollider2.transform;
                soldierCollider2.GetComponent<ActivateTextAtLine> ().StartTalk ();
			}
			this.GetComponent<EnemyManager>().status =2;
			if (this.gameObject.GetComponent<EnemyManager> ().isKyoukan) {
				this.enabled = false;
			}
		}
	}

	void StartBattle(){
		if (!soldierCollider1 && !dialobox.activeInHierarchy) {
			this.GetComponent<EnemyManager>().status =1;
		}
	}
}
