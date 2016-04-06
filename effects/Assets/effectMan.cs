using UnityEngine;
using System.Collections;

public class effectMan : MonoBehaviour {
	public GameObject handR;
	public GameObject handL;

	public static bool bachiR;
	public static bool beamsR;
	public static bool wavR;

	public static bool bachiL;
	public static bool beamsL;
	public static bool wavL;

	public Vector3 dis;
	public static bool col;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		beamsL = Input.GetKey (KeyCode.Q) ?true:false;
		beamsR = Input.GetKey (KeyCode.W) ?true:false;
		bachiR = Input.GetKey (KeyCode.E) ? true : false;
		bachiL = Input.GetKey (KeyCode.R) ? true : false;
		wavL = Input.GetKey (KeyCode.S) ? true : false;
		wavR = Input.GetKey (KeyCode.D) ? true : false;
		col = Input.GetKey (KeyCode.A) ? true : false;



		//dis = handR.transform.position - handR.transform.position;

		//Debug.Log (dis.x * dis.x + dis.y * dis.y + dis.z * dis.z);
		/*if (dis.x * dis.x + dis.y * dis.y + dis.z * dis.z < 10) {
			col = true;
		} else {
			col = false;
		}*/
	}
}
