using UnityEngine;
using System.Collections;

public class PlanetBehaviour : MonoBehaviour {
	//何秒で爆発か
	public float LifeTime = 5.0f;
	//角速度
	public float angle = 30f;

	void Update(){
		//自分の上方向?
		Vector3 axis = transform.InverseTransformDirection(Vector3.up);
		this.transform.RotateAround (this.transform.position, axis, angle*Time.deltaTime);
	}

	public void Play(){
		gameObject.SetActive (true);
		Invoke ("Stop", this.LifeTime);
	}

	private void Stop(){
		gameObject.SetActive (false);
		this.Explosive ();
	}

	private void Explosive(){
	}
}
