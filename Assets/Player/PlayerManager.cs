using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    Rigidbody playerRigidbody;
    public GameObject m_Camera;
    public GameObject m_movePoint;
    public GameObject Sword;
    Animator anim;
    public GameObject atkCollider;
    public float speed;
    public GameObject hpBar;
    public ParticleSystem kilakila;
	public GameObject dialogBox;
    public float ReAddHPTime;//回血時間
    float LastGetDamegeTime;//最後損血時間
    public float HowMatchAddHP;//每秒鐘回血量
    public float MaxHP;
    public float HP;//腳色HP，應設private
	public GameObject RePlayButton;
    float playerHp;
    bool atk;
    bool LockMouseState=true;
    public AudioSource swordVocal;
    // Use this for initialization
    void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
        LockMouse(LockMouseState);
        LastGetDamegeTime = Time.time;
        HP = MaxHP;
        anim = GetComponent<Animator>();
        swordVocal= GetComponent<AudioSource>();
        kilakila = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.L))
        {
            LockMouse(LockMouseState = !LockMouseState);

        }
        if (dialogBox.activeSelf) {
			anim.SetFloat("Speed", 0);
			Time.timeScale = 0;
			return;
		}
        if (HP <= 0)
        {
			Time.timeScale = 0;
            RePlayButton.gameObject.SetActive(true);

            LockMouse(false);
            Debug.Log("YOU DIE!");
        }
        else
        {
            hpBar.GetComponent<HPBar_scr>().m_HP = HP / MaxHP * 100;

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if ((h != 0 || v != 0))
            {
                Vector3 CPos;
                Quaternion CQua;
                float s = 1 / Mathf.Sqrt(h * h + v * v);

                v = s * v * Mathf.Abs(v) * Time.deltaTime * speed;
                h = s * h * Mathf.Abs(h) * Time.deltaTime * speed;
                anim.SetFloat("Speed", 1/s);
                //Vector2 moveDirection = ;
                //anim.SetFloat("Turn", h);
                //var move = new Vector3(0, 0, v * Time.deltaTime * speed);
                //var rotation = new Vector3(0, h * 3, 0);
                
                m_movePoint.transform.localPosition = new Vector3(h, 0, v);
                player.transform.Translate(m_movePoint.transform.position - m_Camera.transform.position);
                //transform.rotation= Quaternion.Lerp(transform.rotation, m_Camera.transform.rotation, 1000);
                transform.LookAt(m_movePoint.transform.position);
                //m_Camera.transform.rotation = CQua;

                /*//old
                m_Camera.transform.Translate(new Vector3(h, 0, v));

                CPos = m_Camera.transform.position;
                CQua = m_Camera.transform.rotation;
                player.transform.LookAt(m_Camera.transform.position);
                m_Camera.transform.localPosition = new Vector3(0, 0, 0);
                m_Camera.transform.rotation = CQua;
                //Vector3 a = new Vector3(CPos.x - m_Camera.transform.position.x, 0, CPos.z - m_Camera.transform.position.z);
                //player.transform.Translate(a);
                player.transform.position = CPos;
                */


                //this.transform.Rotate(rotation);
            }
            if ((Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))&& Sword.activeInHierarchy)
            {
				anim.Play ("POSE30");
				atk = true;
				//StartCoroutine ("xxx");
				Invoke ("xxx", 0.4f);
            }
            if (Time.time-LastGetDamegeTime>=ReAddHPTime)
            {
                if (HP + HowMatchAddHP * Time.deltaTime < MaxHP)
                {

                    ChangeHP(HowMatchAddHP * Time.deltaTime);
                }
                else
                {

                    HP = MaxHP;
                }
            }
            Atk();
        }
    }

	void xxx()
	{
		//anim.SetBool("Atk", false);
        atk = false;
    }

    void Atk()
    {
        if (atk)
            atkCollider.SetActive(true);
        else
            atkCollider.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sword"))
        {
            kilakila.Play();

            swordVocal.Play();
            anim.Play("DAMAGED00");
            
            ChangeHP(-20);
        }
    }
    public void ChangeHP(float a)
    {
        if (a<0)
        {
            LastGetDamegeTime = Time.time;
        }
        HP += a;
    }
    void LockMouse(bool a)
    {

        if (a)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void RePlay()
    {
        SceneManager.LoadScene(0);
    }
}
