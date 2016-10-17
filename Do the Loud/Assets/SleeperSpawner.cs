using UnityEngine;
using System.Collections;

public class SleeperSpawner : MonoBehaviour {
	public GameObject sleeper;
	public int spawnCount;
	// Use this for initialization
	void Start () {
		for (int i=0; i<spawnCount; i++){
			GameObject go = Instantiate (sleeper) as GameObject;
			go.transform.position = new Vector3 (Random.Range (-20, 20), 0, Random.Range (-20, 20));
			go.transform.rotation =  Quaternion.Euler(90,Random.Range (0, 360),0);
	}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
