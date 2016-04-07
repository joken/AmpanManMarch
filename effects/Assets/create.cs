using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class create : MonoBehaviour {
	public GameObject Emp;
	public GameObject planet;

	public Vector3 m_pos;

//	private List<List<GameObject>> planets;

	// Use this for initialization
	void Start () {
//		planets = new List<List<GameObject>> ();
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = Emp.transform.position;
		if (effectMan.planetKun) {
			m_pos = transform.position;
			for (int i = 1; i < 10; i++) {
//				List<GameObject> childplanets = new List<GameObject> ();
				m_pos.x = m_pos.x + 15 * Mathf.Cos (0.7f * i);
				m_pos.z = m_pos.z + 15 * Mathf.Sin (0.7f * i);

				GameObject p = (GameObject)Instantiate (planet, m_pos, Quaternion.identity);
				p.transform.parent = gameObject.transform;
				m_pos = transform.position;
			}
			Debug.Log ("planets : " + gameObject.transform.childCount);
		} else {
			if (gameObject.transform.childCount != 0) {
				foreach(Transform child in gameObject.transform){
					GameObject.Destroy (child.gameObject);
				}
				Debug.Log ("cleared.");
			}
		}
	}
}
