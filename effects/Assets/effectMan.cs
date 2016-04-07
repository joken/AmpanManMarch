using UnityEngine;
using System.Collections;

public class effectMan : MonoBehaviour {
	public GameObject handR;
	public GameObject handL;
	public GameObject sholderR;
	public GameObject sholderL;
	public static bool bachiR;
	public static bool beamsR;
	public static bool wavR;

	public static bool bachiL;
	public static bool beamsL;
	public static bool wavL;
	public static bool planet;

	public Vector3 dis;
	public static bool col;
	public Vector3 WHR;// WhereHandR
	public Vector3 WHL;// WhereHandL
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		beamsL = Input.GetKey (KeyCode.Q) ?true:false;
		beamsR = Input.GetKey (KeyCode.W) ;
		bachiR = Input.GetKey (KeyCode.E) ? true : false;
		bachiL = Input.GetKey (KeyCode.R) ? true : false;
		wavL = Input.GetKey (KeyCode.S) ? true : false;
		wavR = Input.GetKey (KeyCode.D) ;
		//col = Input.GetKey (KeyCode.A) ? true : false;
		planet = Input.GetKey (KeyCode.Z) ;
	

		dis = handR.transform.position- handL.transform.position;
		col = dis.x * dis.x + dis.y * dis.y + dis.z * dis.z < 50;

		WHR = handR.transform.position - sholderR.transform.position;
		beamsR = (WHR.x*WHR.x + WHR.y*WHR.y < 25&& handR.transform.position.y > 1) ;
		wavR =(5 < WHR.x && -5 < WHR.y && WHR.y< 5);
		bachiR = WHR.y > 5;

		WHL = handL.transform.position - sholderL.transform.position;
		beamsL = (WHL.x*WHL.x + WHL.y*WHL.y < 25&&handR.transform.position.y >1) ;
		wavL = (-5 > WHL.x && -5 < WHL.y && WHL.y< 5);
		bachiL = WHL.y > 5;

	/*	if (dis.x * dis.x + dis.y * dis.y + dis.z * dis.z < 30) {
			col = true;
		} else {
			col = false;
		}*/
	}
}
