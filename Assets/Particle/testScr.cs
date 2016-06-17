using UnityEngine;
using System.Collections;

public class testScr : MonoBehaviour {
    ParticleSystem m_Blood;
    //public float m_BloodingTime;
	// Use this for initialization
	void Start () {
      
        m_Blood = GetComponent<ParticleSystem>();

    }
	
	// Update is called once per frame
	void Update () {  
        if (Input.GetKeyUp(KeyCode.Space))
        {
            m_Blood.Play();//使用這個方法可以撥放粒子系統
        }
	}
}
