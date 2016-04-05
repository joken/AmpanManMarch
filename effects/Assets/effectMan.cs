using UnityEngine;
using System.Collections;

public class effectMan : MonoBehaviour {
	public GameObject handR;
	public GameObject handL;

	public static bool under;
	public static bool bachi;
	public static bool beams;
	public static bool wav;

	public Vector3 dis;
	public static bool col;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Q)) {
			beams = true;
		} else {
			beams = false;
		}
		bachi = Input.GetKey (KeyCode.W) ? true : false;

		col = Input.GetKey (KeyCode.A) ? true : false;
		wav = Input.GetKey (KeyCode.E) ? true : false;


		//dis = handR.transform.position - handR.transform.position;

		//Debug.Log (dis.x * dis.x + dis.y * dis.y + dis.z * dis.z);
		/*if (dis.x * dis.x + dis.y * dis.y + dis.z * dis.z < 10) {
			col = true;
		} else {
			col = false;
		}*/
	}
}
