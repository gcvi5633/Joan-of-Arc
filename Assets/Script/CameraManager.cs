using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    public int a, b;
    Camera myCamera;
    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
        a = myCamera.pixelWidth;
        b = myCamera.pixelHeight;
    }
}
