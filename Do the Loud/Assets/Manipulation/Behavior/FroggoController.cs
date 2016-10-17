using UnityEngine;
using System.Collections;

public class FroggoController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	bool mouseReleased;
	private Animator animator;
	enum State {idle,yell};
	FroggoController.State _froggoState;
	public bool voiceActivation;



	//variables gutted from moveobject
	public float soundLevel;
	public bool thresholdBroken;
	public float threshold=1000;
	public float force;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
		animator.SetInteger ("AnimState", 0);
		_froggoState = State.idle;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (voiceActivation == true) {
			FroggoVoice ();
		} else {
			FroggoClick ();
		}

	}



	void FroggoVoice(){
		FroggoRotate ();
		soundLevel = GetComponent<MicrophoneListener> ().soundLevel;
		if (soundLevel > threshold && thresholdBroken == false) {
			thresholdBroken = true;
			animator.SetInteger ("AnimState", 4);
			_froggoState=State.yell;
		}
		if (soundLevel < threshold && _froggoState==State.yell) {
			thresholdBroken = false;
			animator.SetInteger ("AnimState", 0);
			_froggoState=State.idle;
		}
		if(_froggoState==State.idle){
			FroggoPush ();
		}
		
	}






		void FroggoClick(){
			FroggoRotate ();
			if (Input.GetMouseButtonDown (1)) {
				animator.SetInteger ("AnimState", 4);
				_froggoState=State.yell;

			}
			if (Input.GetMouseButtonUp (1)&&_froggoState==State.yell) {
				animator.SetInteger ("AnimState", 0);
				_froggoState=State.idle;
			}
			if(_froggoState==State.idle){
				FroggoPush ();
			}
		}

		





	void FroggoRotate(){
		Vector3 mousePosition= Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Vector3.Distance(Camera.main.transform.position, transform.position)));
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.down);

		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (90,transform.eulerAngles.y, transform.eulerAngles.z);
		transform.position = new Vector3 (transform.position.x,0, transform.position.z);

		
	}

	void FroggoPush(){
		if (Input.GetMouseButtonDown (0)&& mouseReleased) {
			rb.AddForce(gameObject.transform.up * -speed);
			mouseReleased = false;
			animator.SetInteger ("AnimState", 3);
		}else if (Input.GetMouseButtonUp(0)) {
			mouseReleased = true;
			animator.SetInteger ("AnimState", 0);
			
		}
	}
}