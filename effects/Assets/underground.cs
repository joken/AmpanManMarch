using UnityEngine;
using System.Collections;

public class underground : MonoBehaviour {
	public GameObject foot1;
	public GameObject foot2;
	public ParticleSystem un;
	public Color unC = new Color (0,0,0,1);
	public Vector3 dis;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		un.startColor = unC;
		unC.a = 1;
		unC.r = 1-foot1.transform.position.y * 0.1f;
		unC.g = 1-foot2.transform.position.y * 0.1f;
		dis = foot1.transform.position - foot2.transform.position;
		unC.b = (Mathf.Sqrt (dis.x * dis.x + dis.z * dis.z) - 2) * 0.1f > 0 ? 1-(Mathf.Sqrt (dis.x * dis.x + dis.z * dis.z) - 6) * 0.1f:1 ;
		Debug.Log (un.startColor);
	}
}
