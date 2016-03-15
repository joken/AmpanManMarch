using UnityEngine;
using System.Collections;

public class create : MonoBehaviour {
	public GameObject planet;

	Vector3 m_pos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) ) {
			m_pos = transform.position;
			for (int i = 1; i < 12; i++) {
				m_pos.x = m_pos.x + 10*Mathf.Cos(0.7f*i);
				m_pos.z = m_pos.z + 10 * Mathf.Sin (0.7f * i);

				Instantiate (planet, m_pos, Quaternion.identity);
				m_pos = transform.position;
			}
		} 
	}
}
