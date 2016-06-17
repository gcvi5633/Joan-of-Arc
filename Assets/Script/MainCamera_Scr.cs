using UnityEngine;
using System.Collections;

public class MainCamera_Scr : MonoBehaviour {

    // Use this for initialization
    //public Transform targat;

    public float xSpeed = 40;//鏡頭轉動速度
    public float ySpeed = 40;
    public float maxMouseAngle = 45;//最大鏡頭傾仰角
    public float distance = 1;   //與目標距離
    public float disSpeed = 30;//縮放捲動速度
    public float minDistance = -0.8f;//最小最大目標距離
    public float maxDistance = 200;
    public GameObject m_Camera;
    //public float cameraHeight = 1.4f;//鏡頭高度
    //private Vector3 cameraPosition;
    private float x=180;     //鏡頭轉動座標
    private float y;
    // Use this for initialization

    void Start()
    {

        m_Camera.transform.localPosition = new Vector3(0, 0, -distance);
    }

    // Update is called once per frame
    void Update()
    {
        x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
        y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

        if (x > 360)
            x -= 360;
        else if (x < 0)
            x += 360;

        if (y > maxMouseAngle)
            y = maxMouseAngle;
        else if (y < -maxMouseAngle)
            y = -maxMouseAngle;
        if (Input.GetAxis("Mouse ScrollWheel")!=0)
        {
            distance -= Input.GetAxis("Mouse ScrollWheel") * disSpeed * Time.deltaTime;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
            m_Camera.transform.localPosition = new Vector3(0, 0, -distance);

        }
        
        transform.parent.rotation = Quaternion.Euler(0, x, 0);

        transform.rotation = Quaternion.Euler(y, x, 0);
        
        //Debug.Log(transform.rotation.eulerAngles.ToString());
    }
}

