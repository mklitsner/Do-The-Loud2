using UnityEngine;
using System.Collections;

public class moveobject : MonoBehaviour {

	public float soundLevel;
	public bool thresholdBroken;
	public float threshold=1000;
	public float force;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		soundLevel = GetComponent<MicrophoneListener> ().soundLevel;

		if (soundLevel> threshold && thresholdBroken==false){
			thresholdBroken = true;
			GetComponent<Rigidbody>().AddForce(Vector3.up *(soundLevel-threshold)*force, ForceMode.Impulse);


		}

		if (soundLevel < threshold) {
			thresholdBroken = false;
		}
	}
}
