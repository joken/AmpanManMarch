using UnityEngine;
using System.Collections;

public class HeroMan : MonoBehaviour {
	public Vector3 dir = new Vector3(Mathf.Sqrt(2.0f),0,Mathf.Sqrt(2.0f));
	public Vector3 pos;
	public Vector3 posMan;

	public float ang  = 0.0f;
	public float speedMan = 10.0f;
	public bool col = false;
	public GameObject camera;
	public GameObject camMan;

	// Use this for initialization
	void Start () {
		pos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//pos = gameObject.transform.position;
		/*if (Input.GetKey (KeyCode.UpArrow) && !(col)) {
			pos.x -= ((pos - camera.transform.position) * speedMan).x;
			pos.z -= ((pos - camera.transform.position) * speedMan).z;
		} else if (Input.GetKey (KeyCode.RightArrow) && !(col)) {
			posMan.x = ((pos - camera.transform.position) * speedMan).z;
			posMan.z = ((pos - camera.transform.position) * speedMan).x;
			posMan.y = 0;
			pos += posMan;
		} else if (Input.GetKey (KeyCode.LeftArrow) && !(col)) {
			posMan.x = -((pos - camera.transform.position) * speedMan).z;
			posMan.z = -((pos - camera.transform.position) * speedMan).x;
			posMan.y = 0;
			pos += posMan;

		} else if (Input.GetKey (KeyCode.DownArrow) && !(col)) {
			pos.x += ((pos - camera.transform.position) * speedMan).x;
			pos.z += ((pos - camera.transform.position) * speedMan).z;
		}*/


		CamMan();
		if (Input.GetKey (KeyCode.UpArrow)) {
			this.GetComponent<Rigidbody> ().AddForce (
				camera.transform.forward, ForceMode.VelocityChange);
		}
//		 if (Input.GetKey (KeyCode.RightArrow)) {
//			dir.x = Mathf.Sin (ang);
//			dir.z = Mathf.Cos (ang);
//		}
//		if (Input.GetKey (KeyCode.LeftArrow)) {
//			dir.x = Mathf.Sin (ang);
//			dir.z = Mathf.Cos (ang);
//		}
		 if (Input.GetKey(KeyCode.DownArrow)) {
			this.GetComponent<Rigidbody>().AddForce(
				-camera.transform.forward,ForceMode.VelocityChange);
		}
		//camera.transform.position = gameObject.transform.position-(pos - gameObject.transform.position) * 1000.0f;
		//camera.transform.LookAt (gameObject.transform.position);
		//Debug.Log (ang);
		//Debug.Log (Mathf.PI);
		//posMan = gameObject.transform.position - pos;
		//Debug.Log(Mathf.Acos(posMan.z/Mathf.Sqrt(posMan.x*posMan.x+posMan.z*posMan.z))*180/Mathf.PI);


		//transform.rotation = Quaternion.Euler (0, Mathf.Acos(dir.z/Mathf.Sqrt(dir.x*dir.x+dir.z*dir.z))*180/Mathf.PI, 0);
		//transform.rotation = Quaternion.Euler (0, Mathf.Acos(posMan.z/Mathf.Sqrt(posMan.x*posMan.x+posMan.z*posMan.z))*180/Mathf.PI, 0);
		//gameObject.transform.position = pos;


	}
	public void CamMan(){
		camMan.transform.position = gameObject.transform.position;
		camMan.transform.Rotate (0,(Mathf.Atan (Input.GetAxis ("Horizontal")) * speedMan),0);
		camMan.transform.LookAt (gameObject.transform.position/*+dir*/);
	}
}
