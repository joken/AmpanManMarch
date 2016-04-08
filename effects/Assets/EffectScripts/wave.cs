using UnityEngine;
using System.Collections;

public class wave : MonoBehaviour {
	public float posy;
	public bool cltR = true;
	public bool cltL = true;

	public bool clv = true;
	public float timer;

	public GameObject Cam;
	public GameObject handR;
	public GameObject handL;
	public GameObject Foot;
	public GameObject wat;
	public GameObject wav;
	public Object cwatR;
	public Object cwatL;
	public Object cwav;
	public bool csteam = true;
	public Object Steam;
	public Object[] Steams = new Object[5];

	public SoundPlayer soundLeft;
	public SoundPlayer soundRight;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		posy = Foot.transform.position.y;
		if (effectMan.wavR) {
			if (cltR) {
				cltR = false;
				cwatR = Instantiate (wat, handR.transform.position, Quaternion.identity);
				soundRight.PlaySound ();
			} else {
				timer += Time.deltaTime;
				if (timer > 2 && clv ) {
					clv = false;
					cwav = Instantiate (wav, new Vector3 (0, posy, 0), Quaternion.identity);
				}
				
			}
				
		}else{			
			if (!cltR) {
				//GameObject.Destroy (wav);
				UnityEngine.Object.Destroy (cwatR);

			}

		} if (effectMan.wavL) {
			if (cltL) {
				cltL = false;
				cwatL = Instantiate (wat, handL.transform.position, Quaternion.identity);
				soundLeft.PlaySound ();
			} else {
				timer += Time.deltaTime;
				if (timer > 2 && clv) {
					clv = false;
					cwav = Instantiate (wav, new Vector3 (0, posy, 0), Quaternion.identity);
				}

			}

		
		} else {

			if (!cltL) {
				//GameObject.Destroy (wav);
				//UnityEngine.Object.Destroy (cwatR);
				UnityEngine.Object.Destroy (cwatL);
			}
		}
			
	
		if (!effectMan.wavL&&!effectMan.wavR) {
			if (!clv) {
				UnityEngine.Object.Destroy (cwav);
			}
			cltR = true;
			cltL = true;
			clv = true;
			timer = 0;
		}if (effectMan.wavL && effectMan.wavR) {
			
			if (csteam) {
				for (int i = 0; i < 5; i++) {
					Debug.Log ("create");
					Steams [i] = Instantiate (Steam, Cam.transform.position-new Vector3 (2-i,0,-4), Quaternion.identity);
				}
			}csteam = false;
		} else {
			foreach (Object i in Steams) {
				GameObject.Destroy (i);
			}
			csteam = true;
		}

			//Object.Destroy (wat);

	}

}

