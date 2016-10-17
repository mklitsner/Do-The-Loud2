using UnityEngine;
using System.Collections;

public class FroggoController : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 mousePosition= Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Vector3.Distance(Camera.main.transform.position, transform.position)));
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.down);

		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (90,transform.eulerAngles.y, transform.eulerAngles.z);
		Debug.Log (mousePosition);
	}
}