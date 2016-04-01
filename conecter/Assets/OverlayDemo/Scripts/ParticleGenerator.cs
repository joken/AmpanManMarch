using UnityEngine;
using System.Collections;

public class ParticleGenerator : MonoBehaviour {

	/*
	//やっぱりいらなかったよ...
	//位置をコピペする親
	public GameObject particlePositionParent;

	void Upadate(){
		this.transform.position = particlePositionParent.transform.position;
		this.transform.rotation = particlePositionParent.transform.rotation;

		foreach (Transform child in this.transform) {
			ParticleSystem particle = child.GetComponent<ParticleSystem>();
			if (particle.isPlaying) {
				particle.Simulate (0.005f);
				particle.Emit (particle.particleCount);
			}
		}
	}*/

	public void Generate(){
		foreach (Transform child in this.transform) {
			child.GetComponent<ParticleSystem> ().Play ();
		}
	}

	public void Stop(){
		foreach (Transform child in this.transform) {
			child.GetComponent<ParticleSystem> ().Stop ();
		}
	}
}
