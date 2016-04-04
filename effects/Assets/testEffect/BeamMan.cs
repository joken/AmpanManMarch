using UnityEngine;
using System.Collections;

public class BeamMan : MonoBehaviour {
	public ParticleSystem Beams11;
	public ParticleSystem Beams12;
	public ParticleSystem Beams13;
	public ParticleSystem Beams21;
	public ParticleSystem Beams22;
	public ParticleSystem Beams23;

	public ParticleSystem Beamb1;
	public ParticleSystem Beamb2;
	public ParticleSystem Beamb3;
	public ParticleSystem Beamb4;
	public GameObject Hand1;
	public GameObject Hand2;

	public Vector3 dis;

	public static bool col = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.RightArrow)){
			Hand1.transform.position += new Vector3 (1,0,0);
		}

		if (Input.GetKey(KeyCode.LeftArrow)){
			Hand1.transform.position -= new Vector3 (1,0,0);
		}
		if (Input.GetKey (KeyCode.Space)) {

			player (col);

		} else {
			stoper ();
		}
		dis = Hand1.transform.position - Hand2.transform.position;
		//Debug.Log (dis.x * dis.x + dis.y * dis.y + dis.z * dis.z);
		if (dis.x * dis.x + dis.y * dis.y + dis.z * dis.z < 10) {
			col = true;
		} else {
			col = false;
		}
	}
	void player(bool col){
		if (!col) {
			Beams11.Play ();
			Beams12.Play ();
			Beams13.Play ();
			Beams21.Play ();
			Beams22.Play ();
			Beams23.Play ();
			Beamb1.Stop ();
			Beamb2.Stop ();
			Beamb3.Stop ();
			Beamb4.Stop ();
		} else {
			Beams11.Stop ();
			Beams12.Stop ();
			Beams13.Stop ();
			Beams21.Stop ();
			Beams22.Stop ();
			Beams23.Stop ();
			Beamb1.Play ();
			Beamb2.Play ();
			Beamb3.Play ();
			Beamb4.Play ();
		}
	}
	void stoper(){
		Beams11.Stop ();
		Beams12.Stop ();
		Beams13.Stop ();
		Beams21.Stop ();
		Beams22.Stop ();
		Beams23.Stop ();
		Beamb1.Stop ();
		Beamb2.Stop ();
		Beamb3.Stop ();
		Beamb4.Stop ();
	}
	/*void OnTriggerEnter(Collision other) { 
		col = true;
	} //オブジェクトが離れた時 
	void OnTriggerExit(Collision other) {
		col = false;
	}*/
}
