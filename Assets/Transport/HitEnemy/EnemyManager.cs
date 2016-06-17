using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public Transform sword;
    public Transform rightHandPos;

    public GameObject swordCollider;
	ParticleSystem kilakila;
    public AudioSource swordVocal;
    public float distance;
    public float maxDis;
    public float minDis;
    public float speed;
	public float attackTime;
	 
    public Animator anim;

	public int status = 0;

	public bool isKyoukan;

	float attackTimer;

	GameObject target;

    bool canAttack = true;
    bool damage;
    // Use this for initialization
	Vector3 thisPos;
	Rigidbody rig;
    AnimatorStateInfo currentBaseState;

	int idleState = Animator.StringToHash("Base Layer.idle");
    int atkIdleState = Animator.StringToHash("Base Layer.attackstanceidle");
    int walkState = Animator.StringToHash("Base Layer.attackwalkforward");
    int attackState = Animator.StringToHash("Base Layer.attack3front");
    int gethurtState = Animator.StringToHash("Base Layer.attackgethit");
	int dieState = Animator.StringToHash("Base Layer.overlorddeath");

    void Start () {
		thisPos = this.transform.position;
		target = GameObject.Find ("JPos");//  FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        swordVocal = GetComponent<AudioSource>();

        kilakila = GetComponentInChildren<ParticleSystem>();
        equipSword();
		attackTimer = attackTime;
		rig = GetComponent<Rigidbody> ();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpdate() {
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

		//StatusChange ();
		Status ();
    }

	void StatusChange(){
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			status =0;
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			status =1;
		}else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			status =2;
		}
	}

	void Status(){
		var m_status = status;
		switch(m_status){
		case 0:// 一般狀態
			anim.Play("idle");
			break;
		case 1:// 戰鬥狀態
			Attack();
			GetHurt();
			Idle();
			Targeted();
			SwordCollider();
			break;
		case 2:			
			if (isKyoukan) {
				anim.Play ("idle");
			} else {
				anim.Play(dieState);
			}
			Invoke("Death",1f);
			break;
		default:
			break;
		}
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Atk")) {
			if (status == 1) {
				anim.Play ("attackgethit");
				kilakila.Play();
                swordVocal.Play();

                this.GetComponent<BattleManager>().blood --;
			}
		}
    }
    void SwordCollider() {
        if (currentBaseState.nameHash == attackState) {
            swordCollider.SetActive(true);
        } else {
            swordCollider.SetActive(false);
        }
    }

	void Death(){
		if (isKyoukan) {
			swordCollider.SetActive (false);
			status = 0;
		} else {
			gameObject.SetActive (false);
		}
		//transform.position = new Vector3(thisPos.x,thisPos.y-0.8f,thisPos.z);
		//transform.rotation = Quaternion.Euler (new Vector3(0,0,0));
		//var returnPos = this.GetComponent<BattleManager> ().originPos;
		//transform.position = new Vector3 (returnPos.position.x,thisPos.y,returnPos.position.z);
	}

    void Attack() {
        if(currentBaseState.nameHash != attackState && currentBaseState.nameHash != walkState) {
            if (canAttack) {
				if(target == null){
					return;
				}
				attackTimer -= Time.deltaTime;

				if (attackTimer <= 0) {
					{
						anim.Play (attackState);
						attackTimer = attackTime;
					}
				}
            }
        }
    }

    void GetHurt() {
        if (currentBaseState.nameHash == gethurtState) {

            canAttack = false;
        }
    }

    void Idle() {
		if(currentBaseState.nameHash == atkIdleState) {
            canAttack = true;
        }
		if(currentBaseState.nameHash == idleState) {
			anim.Play(atkIdleState);
		}
    }
    void Targeted() {
		if(target == null){
			return;
		}
        distance = Vector3.Distance(transform.position , target.transform.position);
        if (distance > maxDis) {
            canAttack = false;
        }
        if (distance < maxDis && distance > minDis) {
            if (currentBaseState.nameHash != walkState && currentBaseState.nameHash != attackState) {
                anim.Play("attackwalkforward");
            }
			Vector3 thisTarget = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
			transform.LookAt(thisTarget);
            //transform.LookAt(target.transform);
            if (currentBaseState.nameHash != attackState) {
                transform.position = Vector3.MoveTowards(transform.position , target.transform.position , speed * Time.fixedDeltaTime);
				//rig.AddForce(transform.forward*speed);
            }
        } else {
            if (currentBaseState.nameHash == walkState) {
                anim.Play("attackstanceidle");
            }
        }
    }

    void equipSword() {
        sword.parent = rightHandPos;
        sword.position = rightHandPos.position;
        sword.rotation = rightHandPos.rotation;
    }
}
