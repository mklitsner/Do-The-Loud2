﻿using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
[RequireComponent(typeof(AudioSource))]

public class sleeper : MonoBehaviour {

	enum State {asleep,dozing,idle,waking,enlightened};
	private Animator animator;
	public float sleepTimer;
	private Color spriteColor;


	//wakingTimer counts down from the last time its been yelled at
	float wakingTimer;
	public float timerAverageStart;//50
	float resistance;
	float floatation;
	private SpriteRenderer sprite;
	AudioClip dreamSong;

	bool yelledAt;

	sleeper.State _sleeperState;

	// Use this for initialization
	void Start () {

		spriteColor = new Color (Random.Range(.55f,.65f), Random.Range(.65f,.8f),Random.Range(.75f,.9f), 1);

			GetComponent<SpriteRenderer>().color=spriteColor;

		//Music play
		dreamSong=GetComponent<AudioSource> ().clip;


		AudioSource audio = GetComponent<AudioSource>();

		audio.Play();




		_sleeperState = State.idle;
		animator = GetComponent<Animator> ();
		animator.SetInteger ("AnimState", 0);
		sleepTimer = Random.Range(timerAverageStart,timerAverageStart+20);
		floatation = 0;
		resistance = 0;
		sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (transform.position.x, floatation, transform.position.z);

		//times how long until they fall asleep
		sleepTimer -= Time.deltaTime;

		if (_sleeperState == State.idle) {
			

			//if yelled at, reset sleepTimer, resistance goes up
			if (yelledAt) {
				ResetTimer ();
				resistance += 1;
				_sleeperState = State.waking;

			}

			//if sleepTimer goes below 20, start dozing
			if (sleepTimer < 20) {
				_sleeperState = State.dozing;
			}
				
			

		} else if (_sleeperState == State.waking) {

			if (animator.GetCurrentAnimatorStateInfo (0).normalizedTime > 1 && !animator.IsInTransition (0)) {
				animator.SetInteger ("AnimState", 2);
			}
			wakingTimer -= Time.deltaTime;

			if (wakingTimer<0) {
				yelledAt = false;
				_sleeperState = State.idle;
				animator.SetInteger ("AnimState", 0);
			}

		} else if (_sleeperState == State.dozing) {

			//gradually switch between idle and dozing, while dozing more frequently as sleepTimer gets closer to 0
			float sleepiness;
			sleepiness = Random.Range (0, sleepTimer * sleepTimer);

			if (sleepiness < 5) {
				animator.SetInteger ("AnimState", -1);
			} else if (animator.GetCurrentAnimatorStateInfo (0).normalizedTime > 1 && !animator.IsInTransition (0)) {
				animator.SetInteger ("AnimState", 0);
				
			}



			//if yelled at, reset sleepTimer, go to waking
			if (yelledAt) {
				ResetTimer ();
				resistance += 1;
				_sleeperState = State.waking;

			}

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
				GetComponent<SpriteRenderer>().color = Color.Lerp(spriteColor,new Color(0.15f,0.22f,0.27f,1),floatation*-.06f);
				sprite.sortingLayerName = "Below";
				if (floatation < -20) {
					Destroy (gameObject);
				}
			}



			//if yelled at, reset sleepTimer and wake up
			if (yelledAt) {
				ResetTimer ();
				resistance += 1;
				_sleeperState = State.waking;

			}
			//if touching partner, wake up

			
		} else if (_sleeperState == State.enlightened) {
			//Rise up
			floatation +=0.1f;
			animator.SetInteger ("AnimState", 3);
			sprite.sortingLayerName = "Above";
			GetComponent<SpriteRenderer>().color = Color.Lerp(spriteColor,new Color(1,0.93f,0.25f,1),floatation*.1f);
			if (floatation > 20) {
				Destroy (gameObject);
			}

			
		} else {
			//Debug.Log ("sleeper lost state");
		}
	}

		void OnTriggerStay(Collider col){
		if (col.gameObject.name == "Yell_space") {
			yelledAt = true;
			wakingTimer = 0.5f;
			Debug.Log ("yelledAt");
		}

	}

	void OnTriggerEnter(Collider col){
	if (col.gameObject.tag == "Sleeper") {
			if (col.GetComponent<AudioSource> ().clip == dreamSong) {
				_sleeperState = State.enlightened;
			}
			Debug.Log (col.GetComponent<AudioSource> ().clip + " and " + dreamSong);
		}
	}


		
		

	void ResetTimer(){
		sleepTimer = Random.Range (timerAverageStart - resistance, timerAverageStart+20 - resistance);
	}




		//Debug.Log (Time.time);
	
}
