using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundPlayer : MonoBehaviour {
	public List<AudioClip> Sounds;
	public AudioSource SoundObject;

	// Use this for initialization
	void Start () {
		if (Sounds.Capacity == 0) {
			SoundObject.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
		
	public void PlaySound(){
		if (effectMan.isSoundEnable && !SoundObject.isPlaying) {
			SoundObject.clip = Sounds[Random.Range(0,Sounds.Capacity)];
			SoundObject.Play ();
		}
	}
}
