using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {
	public ParticleSystem bachi1;
	public ParticleSystem bachi2;
	public ParticleSystem fi;
	public bool player;

	public SoundPlayer soundLeft;
	public SoundPlayer soundRight;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (effectMan.bachiR) {
			//Debug.Log ("test");
			//Debug.Log (effectMan.col);
			if (!effectMan.col) {
				//bachi1.transform.position = new Vector3 (Random.Range (-2.0f, 2.0f), Random.Range (-2.0f, 2.0f), Random.Range (-2.0f, 2.0f));
				bachi1.Play ();
				//bachi2.transform.position = new Vector3 (Random.Range (-2.0f, 2.0f), Random.Range (-2.0f, 2.0f), Random.Range (-2.0f, 2.0f));
				fi.Stop ();
			} else {
				if (player) {
					fi.Play ();
					player = false;
				}
			}
			soundRight.PlaySound ();
		}
		if (effectMan.bachiL) {
			if (!effectMan.col) {
				//bachi1.transform.position = new Vector3 (Random.Range (-2.0f, 2.0f), Random.Range (-2.0f, 2.0f), Random.Range (-2.0f, 2.0f));
				bachi2.Play ();
			}
			soundLeft.PlaySound ();
		}
			if(!effectMan.bachiL &&!effectMan.bachiR){
			fi.Stop ();
			//Debug.Log ("a");
				player = true;}
		
	}

}
