using UnityEngine;
using System.Collections;

public class water : MonoBehaviour {
	public float posy;
	public bool cl = true;

	public GameObject wat;
	public GameObject wav;
	// Use this for initialization
	void Start () {
		wav.transform.parent = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			if (cl) {
				cl = false;
				Instantiate (wat, gameObject.transform.position, Quaternion.identity);
				Instantiate (wav, new Vector3 (0, posy, 0), Quaternion.identity);
			} else {
			//	wav.transform.position  = new Vector3(0,wav.transform.position.y +0.5f,0);
			}
		}else{
			cl = true;
			GameObject.Destroy(wav);
			GameObject.Destroy(wat);
			}
				
	}
}
