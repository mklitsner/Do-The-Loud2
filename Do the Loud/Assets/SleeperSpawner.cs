using UnityEngine;
using System.Collections;

public class SleeperSpawner : MonoBehaviour {
	public GameObject sleeper;
	public int pairSpawnCount;
	public AudioClip[] Songs;
	// Use this for initialization
	void Start () {
		for (int i=0; i<pairSpawnCount; i++){
			int songIndex=Random.Range (0, Songs.Length);

			GameObject partnerA = Instantiate (sleeper) as GameObject;
			partnerA.transform.position = new Vector3 (Random.Range (-20, 20), 0, Random.Range (-20, 20));
			partnerA.transform.rotation =  Quaternion.Euler(90,Random.Range (0, 360),0);
			partnerA.GetComponent<AudioSource> ().clip = Songs [songIndex];

			GameObject partnerB = Instantiate (sleeper) as GameObject;
			partnerB.transform.position = new Vector3 (Random.Range (-20, 20), 0, Random.Range (-20, 20));
			partnerB.transform.rotation =  Quaternion.Euler(90,Random.Range (0, 360),0);
			partnerB.GetComponent<AudioSource> ().clip = Songs [songIndex];
	}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
