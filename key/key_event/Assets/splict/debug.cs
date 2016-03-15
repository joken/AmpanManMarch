using UnityEngine;
using System.Collections;

public class debug : MonoBehaviour {
	private string t1 = "0";
	public GameObject ob;
	public float p1;
	void OnGUI(){
		//t1 = ().ToString;
		GUI.TextField (new Rect (10, 10, 100, 100),t1) ;
		 
	}
	// Use this for initialization
	void Start () {
		ob = GameObject.Find ("Cube");
		p1 = (float)ob.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		t1 = ((float)ob.transform.position.x - p1).ToString("R");
		p1 = (float)ob.transform.position.x;

	}
}
