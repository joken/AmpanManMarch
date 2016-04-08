using UnityEngine;
using System.Collections;

public class BallMeshRenderer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void MeshRendererDisable(){
		foreach (Transform child in this.transform) {
			child.GetComponent<MeshRenderer> ().enabled = false;
		}
	}

	public void MeshRendererEnable(){
		foreach (Transform child in this.transform) {
			child.GetComponent<MeshRenderer> ().enabled = true;
		}
	}
}
