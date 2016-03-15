using UnityEngine;
using System.Collections;

public class look : MonoBehaviour {
	public GameObject ob;

	// Use this for initialization
	void Start () {
		ob = GameObject.Find ("Cube");

	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (ob.transform.position);
	}
}
