using UnityEngine;
using System.Collections;

public class wave : MonoBehaviour {
	public float posy=0;
	public bool clt = true;
	public bool clv = true;
	public float timer;

	public GameObject handR;
	public GameObject handL;
	public GameObject wat;
	public GameObject wav;
	public Object cwatR;
	public Object cwatL;
	public Object cwav;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (effectMan.wav) {
			if (clt) {
				clt = false;
				cwatR = Instantiate (wat, handR.transform.position, Quaternion.identity);
				cwatL = Instantiate (wat, handL.transform.position, Quaternion.identity);

			} else {
				timer += Time.deltaTime;
				if (timer > 2 && clv) {
					clv = false;
					cwav = Instantiate (wav, new Vector3 (0, posy, 0), Quaternion.identity);
				}
				
			}

		}else{

			if (!clt) {
				//GameObject.Destroy (wav);
				UnityEngine.Object.Destroy (cwatR);
				UnityEngine.Object.Destroy (cwatL);

			}
			if (!clv) {
				UnityEngine.Object.Destroy (cwav);
			}
			clt = true;
			clv = true;
			timer = 0;
			//Object.Destroy (wat);


		}

	}
}
