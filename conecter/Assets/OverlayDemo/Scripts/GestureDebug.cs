using UnityEngine;
using System.Collections;

public class GestureDebug : MonoBehaviour {
	public GameObject RightHand;
	public GameObject Kata;
	public GameObject camera;

	private Vector3 distance;
	private Vector3 distanceViewport;
	private Camera mycamera;
	// Use this for initialization
	void Start () {
		mycamera = camera.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		distance = RightHand.GetComponent<Transform> ().position - Kata.GetComponent<Transform> ().position;
		distanceViewport = mycamera.WorldToViewportPoint (distance);
		Debug.Log ("Distance : " + distanceViewport.ToString());
	}
}
