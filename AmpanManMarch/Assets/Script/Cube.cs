using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {
	public float speed = 4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		Rigidbody rigidbody = GetComponent<Rigidbody> ();
		if (Input.GetKey ("right")) {
			rigidbody.AddForce (speed, 0, 0);
		} else if (Input.GetKey ("left")) {
			rigidbody.AddForce (-speed, 0, 0);
		} else if (Input.GetKey ("up")) {
			rigidbody.AddForce (0, 0, speed);
		} else if (Input.GetKey ("down")) {
			rigidbody.AddForce(0,0,-speed);
		}
	}
}
