﻿using UnityEngine;
using System.Collections;

public class beam : MonoBehaviour {
	public ParticleSystem[] beams1 = new ParticleSystem[3];
	public ParticleSystem[] beams2 = new ParticleSystem[3];
	public ParticleSystem[] beamb = new ParticleSystem[4];
	public GameObject hand1;
	public GameObject hand2;
	public GameObject elbow1;
	public GameObject elbow2;
	public GameObject heart;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//終わったらさしかえて
		//if (effectMan.beamsR) {
		if(true){
			Debug.Log ("test");
			if (!effectMan.col) {
					player (beams1);
					stopper (beamb);
					hand1.transform.LookAt (hand1.transform.position - (elbow1.transform.position - hand1.transform.position));
					hand2.transform.LookAt (hand2.transform.position - (elbow2.transform.position - hand2.transform.position));
				} else {
					stopper (beams2);
					player (beamb);
					hand1.transform.LookAt (hand1.transform.position - (heart.transform.position - hand1.transform.position));
				}
			}
		if (effectMan.beamsL) {
			if (!effectMan.col) {
				player (beams2);
				hand1.transform.LookAt (hand1.transform.position - (elbow1.transform.position - hand1.transform.position));
				hand2.transform.LookAt (hand2.transform.position - (elbow2.transform.position - hand2.transform.position));
			} else {
				stopper (beams2);
			}
		}
		//終わったら外して
		/*if (!effectMan.beamsL&&!effectMan.beamsR) {
			stopper (beams1);
			stopper (beams2);
			stopper (beamb);
		}*/


	}
	void player( ParticleSystem[] p){
		foreach (ParticleSystem i in p) {
			i.Play ();
		}
	}
	void stopper( ParticleSystem[] p){
		foreach (ParticleSystem i in p) {
			i.Stop ();
		}
	}
}
