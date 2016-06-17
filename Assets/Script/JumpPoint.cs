using UnityEngine;
using System.Collections;

public class JumpPoint : MonoBehaviour {
	public GameObject point1,point2,point3,point4,point5,point6,point7;
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.transform.position = point1.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.transform.position = point3.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player.transform.position = point4.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            player.transform.position = point5.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            player.transform.position = point6.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            player.transform.position = point2.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            player.transform.position = point7.transform.position;
        }
    }
}
