using UnityEngine;
using System.Collections;

public class AudioTest : MonoBehaviour {

	// Use this for initialization
	GameObject MoveThisObjectWithSound;//public GameObject MoveThisObjectWithSound;
	AudioSource audio;
	public float background=0;
	public float y=0;
	void Start () {
		MoveThisObjectWithSound = this.gameObject; //MoveThisObjectWithSound = GameObject.FindGameObjectWithTag("Cube");
		audio = gameObject.AddComponent<AudioSource>();
		audio.clip = Microphone.Start("Built-in Microphone", true, 1, 44100);

	}


	// Update is called once per frame
	void Update () {
		

			if (audio.isPlaying) {
			} else if (audio.clip.isReadyToPlay) {
				audio.Play ();
			} else {
				audio.clip = Microphone.Start ("Built-in Microphone", true, 1, 44100);
			}
			y = audio.GetSpectrumData (128, 0, FFTWindow.BlackmanHarris) [64] * 1000000;
		if (Input.GetKeyDown ("space")) {
		background = audio.GetSpectrumData (128, 0, FFTWindow.BlackmanHarris) [64] * 1000000;
		}else{

		if (y >= 500+background) {
				MoveThisObjectWithSound.transform.position += new Vector3 (0, 1, 0) * 5 * Time.deltaTime;

			}

		}
	}
	
}
