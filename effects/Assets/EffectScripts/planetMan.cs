using UnityEngine;
using System.Collections;

public class planetMan : MonoBehaviour {
	public Color fire = new Color (1,0,0,1);
	public Color beam = new Color (0, 1, 0, 1);
	public Color water = new Color (0, 0, 1, 1);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (effectMan.bachiL || effectMan.bachiR) {
//			Debug.Log ("color");
			gameObject.GetComponent<Renderer> ().material.color = fire;
//			gameObject.GetComponent<Renderer>().material.color = Color.black;
		}else if(effectMan.beamsL||effectMan.beamsR){
			gameObject.GetComponent<Renderer> ().material.color = beam;
		}else if(effectMan.wavL||effectMan.wavR){
			gameObject.GetComponent<Renderer> ().material.color = beam;
		}
	}
}
