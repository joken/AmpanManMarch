using UnityEngine;
using System.Collections;

public class ParticleGenerator : MonoBehaviour {
	//うまく位置がコピーできないので一時オミット()
	/*public GameObject particlePositionParent;

	private Vector3 parentPosition;

	void Start(){
		this.parentPosition = new Vector3 ();
	}

	void Upadate(){
		this.parentPosition.Set(
			particlePositionParent.transform.position.x,
			particlePositionParent.transform.position.y,
			particlePositionParent.transform.position.z
		);
		this.transform.position = parentPosition;
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
