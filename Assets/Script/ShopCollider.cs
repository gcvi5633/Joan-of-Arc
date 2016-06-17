using UnityEngine;
using System.Collections;

public class ShopCollider : MonoBehaviour {
	public GameObject lookAt;
	public GameObject soldierCollier1;
	public GameObject soldierCollier2;
	public GameObject soldierCollier3;
    public GameObject playerSword,BusiSword;

    bool canTalk;
	// Use this for initialization
	void Start () {
		canTalk = false;
	}
	
	// Update is called once per frame
	void Update () {
		OpenCollider ();
	}

	void OpenCollider(){
		if (!soldierCollier1 && soldierCollier2) {
			canTalk =true;
		}
	}

	void CloseCollider(){
		if (soldierCollier1) {
			Destroy (soldierCollier1);
		}
		if (soldierCollier2) {
			Destroy (soldierCollier2);
		}
		soldierCollier3.SetActive (true);
		this.GetComponent<QuestManager>().ChangeQuestText();
		lookAt.GetComponent<Enforce>().target = soldierCollier3.transform;
		Destroy (this.gameObject);
	}

	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag ("Player")) {
			if(Input.GetKeyDown(KeyCode.E)){
				if(canTalk){
                    playerSword.SetActive(true);
                    BusiSword.SetActive(false);
                CloseCollider();
				}
			}
		}
	}
}
