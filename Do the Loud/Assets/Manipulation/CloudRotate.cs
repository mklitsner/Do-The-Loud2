using UnityEngine;
using System.Collections;

public class CloudRotate : MonoBehaviour {


	public float speed;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		float shift = Time.time * .01f * speed;

		transform.rotation = Quaternion.Euler(90,transform.rotation.y,transform.rotation.z+shift);
	
	}
}
