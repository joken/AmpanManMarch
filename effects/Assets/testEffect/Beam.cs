using UnityEngine;
using System.Collections;

public class Beam : MonoBehaviour {
	public GameObject hand;
	public GameObject elbow;
	public GameObject heart;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (BeamMan.col);
		if (!BeamMan.col) {
			hand.transform.LookAt (hand.transform.position - (elbow.transform.position - hand.transform.position));
		} else {
			hand.transform.LookAt (hand.transform.position - (heart.transform.position - hand.transform.position));
		}
	}

}
