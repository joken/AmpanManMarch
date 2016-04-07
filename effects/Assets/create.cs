using UnityEngine;
using System.Collections;

public class create : MonoBehaviour {
	public GameObject Emp;
	public GameObject planet;
	public GameObject[] planets = new GameObject[10];

	public Vector3 m_pos;
	public bool created = true;
	public float timer;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = Emp.transform.position;
		if (effectMan.planet) {
			if (created) {
				created = false;
				m_pos = transform.position;
				for (int i = 1; i < 10; i++) {
					m_pos.x = m_pos.x + 15 * Mathf.Cos (0.7f * i);
					m_pos.z = m_pos.z + 15 * Mathf.Sin (0.7f * i);

					GameObject p = (GameObject)Instantiate (planet, m_pos, Quaternion.identity);
					p.transform.parent = gameObject.transform;
					planets [i] = p;
					m_pos = transform.position;
				}
			}
		} else {
			if (!created) {
				timer += Time.deltaTime;
				if (timer > 10) {
					foreach (GameObject g in planets) {
						GameObject.Destroy (g);
					}
					timer = 0;
					created = true;
				}
			}
		
		}
	}
}
