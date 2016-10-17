using UnityEngine;
using System.Collections;

public class FollowFroggo : MonoBehaviour {

	GameObject froggo;

	// Use this for initialization
	void Start () {
		froggo = GameObject.Find ("Froggo");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position= new Vector3(froggo.transform.position.x,transform.position.y,froggo.transform.position.z);
	
	}
}
