using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
	public Transform target;//追尾先オブジェクト
	private Vector3 offset;//距離

	// Use this for initialization
	void Start () {
		offset = GetComponent<Transform> ().position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Transform> ().position = target.position + offset;
	}
}
