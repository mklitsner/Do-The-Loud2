using UnityEngine;
using System.Collections;

public class YellingActivator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.parent.GetComponent<FroggoController> ().yelling){
			GetComponent<SphereCollider> ().enabled = true;
		}else{
			GetComponent<SphereCollider> ().enabled = false;
		}
}
}