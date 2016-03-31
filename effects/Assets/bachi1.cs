using UnityEngine;
using System.Collections;

public class bachi1 : MonoBehaviour {
	public ParticleSystem bachi;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)){
			//Debug.Log ("test");
			bachi.transform.position = new Vector3 (Random.Range (-2.0f, 2.0f), Random.Range (-2.0f, 2.0f), Random.Range (-2.0f, 2.0f));
			bachi.Play ();
		}
	
	}
}
