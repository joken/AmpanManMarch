using UnityEngine;
using System.Collections;

public class HandCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider target){
		Debug.Log ("collision");
		if (target.gameObject.tag == "Hand") {
			effectMan.col = true;
		}
	}
			
	void OnTriggerExit(){
		effectMan.col = false;
	}
}
