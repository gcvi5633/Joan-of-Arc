using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;
public class Enforce : MonoBehaviour
{

    public Transform target;
    public GameObject Refer;
    public TextBoxManager theBox;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		if (target) {
			if ((transform.parent.position.x - target.position.x) *
			         (transform.parent.position.x - target.position.x) +
			         (transform.parent.transform.position.z - target.position.z) *
			         (transform.parent.transform.position.z - target.position.z) > 632) {
				Refer.SetActive (true);
				Vector3 thisTarget = new Vector3 (target.position.x, transform.position.y, target.position.z);
				transform.LookAt (thisTarget);

			} else {

				Refer.SetActive (false);
			}
		}
        if (!target&&!theBox.isActive)
        {

            SceneManager.LoadScene(3);
        }
    }
}
