using UnityEngine;
using System.Collections;

public class sleeper : MonoBehaviour {

	enum State {asleep,dozing,idle,waking,enlightened};
	private Animator animator;
	public float sleepTimer;
	float resistance;
	float floatation;
	private SpriteRenderer sprite;

	sleeper.State _sleeperState;

	// Use this for initialization
	void Start () {
		_sleeperState = State.idle;
		animator = GetComponent<Animator> ();
		animator.SetInteger ("AnimState", 0);
		sleepTimer = Random.Range(50,70);
		floatation = 0;
		sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (transform.position.x, floatation, transform.position.z);

		sleepTimer -= Time.deltaTime;

		if (_sleeperState == State.idle) {
			

			//if yelled at, reset sleepTimer, resistance goes up

			//if sleepTimer goes below 20, start dozing
			if (sleepTimer < 20) {
				_sleeperState = State.dozing;
			}

			//if collided with partner is found, become enlightened
			

		} else if (_sleeperState == State.waking) {
			//depending on resistance, wake up after being yelled at for certain amount of time

			//if not yelled at enough, go back to dozing

			// go to idle once point is reached

		} else if (_sleeperState == State.dozing) {

			//gradually switch between idle and dozing, while dozing more frequently as sleepTimer gets closer to 0
			float sleepiness;
			sleepiness=Random.Range(0,sleepTimer*sleepTimer);

			if (sleepiness < 5) {
				animator.SetInteger ("AnimState", -1);
			} else if (animator.GetCurrentAnimatorStateInfo (0).normalizedTime > 1 && !animator.IsInTransition (0)) {
				animator.SetInteger ("AnimState", 0);
				
			}



			//if yelled at, reset sleepTimer, go to waking

			//if sleepTimer goes below 5, fall asleep
			if (sleepTimer < 5) {
				animator.SetInteger ("AnimState", -1);
				if (animator.GetCurrentAnimatorStateInfo (0).normalizedTime > 1 && !animator.IsInTransition (0)) {
					animator.SetInteger ("AnimState", -2);
					_sleeperState = State.asleep;
				}

			}


		} else if (_sleeperState == State.asleep) {
			//if sleepTimer goes below 0, fall
			if (sleepTimer < 0) {
				floatation = sleepTimer;
				sprite.sortingLayerName = "Below";
				if(floatation<-20){
					Destroy (gameObject);
				}
			}

			//if yelled at, reset sleepTimer and wake up

			//if touching partner, wake up

			
		} else if (_sleeperState == State.enlightened) {
			//Rise up
			
		} else {
			//Debug.Log ("sleeper lost state");
		}






		//Debug.Log (Time.time);
	}
}
