using UnityEngine;
using System.Collections;

public class goal: MonoBehaviour {
	public GameObject planet;
	public GameObject cube;
	Vector3 m_pos;
	// Use this for initialization
	void Start () {
		//Emp = GameObject.Find ("Emp") as GameObject;
		m_pos = transform.position;


		

	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = cube.transform.position;
		if (Input.GetKeyDown (KeyCode.Space)) {
			for (int i = 1; i < 10; i++) {
				m_pos.x = m_pos.x + 5 * Mathf.Cos (0.7f * i);
				m_pos.z = m_pos.z + 5 * Mathf.Sin (0.7f * i);

				GameObject p = (GameObject)Instantiate (planet, m_pos, Quaternion.identity);
				p.transform.parent = gameObject.transform;
				m_pos = transform.position;
			}
		}
		
	}
}
