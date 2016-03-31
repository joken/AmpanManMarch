using UnityEngine;
using System.Collections;

public class Beam : MonoBehaviour {
	public GameObject b1;
	public GameObject b2;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		b1.transform.LookAt (b1.transform.position-(b2.transform.position-b1.transform.position));
	}
}
