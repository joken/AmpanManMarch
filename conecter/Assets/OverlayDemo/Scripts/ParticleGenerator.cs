using UnityEngine;
using System.Collections;

public class ParticleGenerator : MonoBehaviour {
	public GameObject particlePositionParent;

	void Start(){
		this.transform.position = particlePositionParent.transform.position;
	}

	public void Generate(){
		foreach (Transform child in this.transform) {
			child.GetComponent<ParticleSystem> ().Play ();
		}
	}
}
