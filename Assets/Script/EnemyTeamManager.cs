using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyTeamManager : MonoBehaviour {
	public GameObject[] enemyFab;
	public Transform[] ePos;
	public GameObject finalyTalk;
	public bool finaly,reborn=false;
	public float tc;//看是要幾秒  #Timecontroller
    
	Door door;

    //public Text time;
    int min;
    int sec;

	// Use this for initialization
	void Start () {
		foreach (GameObject e in enemyFab) {
			e.SetActive(false);
		}
		door = GameObject.Find ("DoorInOut").GetComponent<Door> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		if (reborn) {
			for (int i = 0; i < enemyFab.Length; i++) {
				if (!enemyFab [i].activeSelf) {
					enemyFab [i].GetComponent<EnemyManager> ().status = 1;
					enemyFab [i].GetComponent<BattleManager> ().blood = 5;
					enemyFab [i].transform.position = ePos [i].position;
                    enemyFab [i].SetActive (true);
				}
			}
			if (tc > 0){
	            Timer();
			}else if(tc <= 0)
            {
				if(finalyTalk){
				    finalyTalk.SetActive (true);
			        finalyTalk.GetComponent<ActivateTextAtLine>().StartTalk();
			    }
			}
			if (!door.goIn) {
				reborn = false;
				foreach (GameObject e in enemyFab) {
					e.SetActive(false);
				}
			}
		}
	}

	public void Timer(){
		tc -= Time.deltaTime;
		sec = (int)tc;//將 int 型態的 tc設成 sec
		min = sec / 60;
		sec = sec % 60;
		//使用 ToString("D2") 的方法來使輸出的時間數字保持有兩位數位置
		//time.text = min.ToString("D2") + ":" + sec.ToString("D2");
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			if (finaly) {
				reborn = true;
			}
			for (int i = 0; i < enemyFab.Length; i++) {
				if (finaly) {
					enemyFab [i].GetComponent<EnemyManager> ().maxDis = 100;
					enemyFab [i].GetComponent<EnemyManager> ().attackTime = 1;
				}
				enemyFab [i].GetComponent<EnemyManager> ().status = 1;
				enemyFab [i].GetComponent<BattleManager> ().blood = 5;
				enemyFab [i].transform.position = ePos [i].position;
				enemyFab [i].SetActive (true);
			}
		}
	}
	void OnTriggerExit(Collider other){
		if (other.CompareTag ("Player")) {
			if(!finaly){
			foreach (GameObject e in enemyFab) {
				reborn = false;
				e.SetActive(false);
			}
		}
		}
	}
}
