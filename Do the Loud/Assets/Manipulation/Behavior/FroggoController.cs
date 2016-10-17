using UnityEngine;
using System.Collections;

public class FroggoController : MonoBehaviour {

	public float speed=20;
	private Rigidbody rb;
	bool mouseReleased;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		FroggoRotate ();
		FroggoPush ();
	

	}



	void FroggoRotate(){
		Vector3 mousePosition= Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Vector3.Distance(Camera.main.transform.position, transform.position)));
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.down);

		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (90,transform.eulerAngles.y, transform.eulerAngles.z);

		
	}

	void FroggoPush(){
		if (Input.GetMouseButtonDown (0)&& mouseReleased) {
			rb.AddForce(gameObject.transform.up * -speed);
			mouseReleased = false;
		}
		if (Input.GetMouseButtonUp (0)) {
			mouseReleased = true;
		}
	}
}