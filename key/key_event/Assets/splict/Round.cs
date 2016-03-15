using UnityEngine;
using System.Collections;

public class Round : MonoBehaviour {
	public GameObject ob;
	public Vector3 pos;
	// Use this for initialization
	void Start () {
		ob = GameObject.Find ("Cube");
		pos = ob.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//m_pos.x = ob.transform.position.x ;
		//transform.position = m_pos;
		Vector3 axis = transform.TransformDirection (new Vector3(0.2f,1,0.2f));//Vector3.up = Vecter3(0,1,0)
		transform.RotateAround(ob.transform.position,axis,30f*Time.deltaTime);//bad
		//transform.RotateAround(pos,axis,30f*Time.deltaTime);//better
	}
}
