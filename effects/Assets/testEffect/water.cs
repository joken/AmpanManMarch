using UnityEngine;
using System.Collections;
using UnityEngine;
public class water : MonoBehaviour {
	public float posy=0;
	public bool cl = true;

	public GameObject wat;
	public GameObject wav;
	public Object cwat;
	public Object cwav;
	// Use this for initialization
	void Start () {
		//wav.transform.position = gameObject.transform;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			if (cl) {
				cl = false;
				cwat = Instantiate (wat, gameObject.transform.position, Quaternion.identity);
				cwav = Instantiate (wav, new Vector3 (0, posy, 0), Quaternion.identity);
			} 

		}else{
			
			if (!cl) {
				//GameObject.Destroy (wav);
				UnityEngine.Object.Destroy (cwat);
				UnityEngine.Object.Destroy (cwav);
			}
			cl = true;
			//Object.Destroy (wat);


		}
				
	}
}
