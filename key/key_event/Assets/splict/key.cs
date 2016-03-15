using UnityEngine;
using System.Collections;

public class key : MonoBehaviour {
	private float ad = 0.004f;
	private float sp = 0.0f;
	private Vector3 m_pos;
	// Use this for initialization
	void Start () {
		m_pos = transform.localPosition;
	}

	// Update is called once per frame
	void Update () {
		transform.localPosition = m_pos;
		if (Input.GetKey (KeyCode.RightArrow)) {
			sp += ad;
			m_pos.x += sp;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			sp -= ad;
			m_pos.x += sp;
		} else {
			sp = 0.0f;
		}
			
	}
}
