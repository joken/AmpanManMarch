using UnityEngine;
using System.Collections;
using System;

public class SimpleGestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{
	// GUI Text to display the gesture messages.
	public GUIText GestureInfo;
	
	// private bool to track if progress message has been displayed
	private bool progressDisplayed;

	//足元のやつ(左右)
	public GameObject footParticleRight;
	public GameObject footParticleLeft;

	//ほのおをだすやつ(左右分あるよ)
	public GameObject fireObjectRight;
	public GameObject fireObjectLeft;

	//水をだすやつ(左右)
	public GameObject waterObjectRight;
	public GameObject waterObjectLeft;

	//ビームだすやつ(左右)
	public GameObject beamObjectRight;
	public GameObject beamObjectLeft;

	//惑星だすやつ(左右)
	public GameObject planetObjectRight;
	public GameObject planetObjectLeft;
	
	
	public void UserDetected(uint userId, int userIndex)
	{
		// as an example - detect these user specific gestures
		//DetectしたいGestureをDetectGestureの引数に突っ込んで呼ぶようです
		KinectManager manager = KinectManager.Instance;

		//デフォルトのやつ(足元のやつ)
		this.GenerateFootParticle();

		//manager.DetectGesture(userId, KinectGestures.Gestures.Jump);
		//manager.DetectGesture(userId, KinectGestures.Gestures.Squat);

		manager.DetectGesture(userId, KinectGestures.Gestures.Push);
//		manager.DetectGesture(userId, KinectGestures.Gestures.Pull);

		manager.DetectGesture (userId, KinectGestures.Gestures.Psi);
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeRight);
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeLeft);
		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeUp);
		manager.DeleteGesture (userId, KinectGestures.Gestures.RaiseRightHand);
		manager.DeleteGesture (userId, KinectGestures.Gestures.RaiseLeftHand);
		
		if(GestureInfo != null)
		{
			GestureInfo.GetComponent<GUIText>().text = "User detected";
		}
	}
	
	public void UserLost(uint userId, int userIndex)
	{
		this.StopFootParticle ();
		if(GestureInfo != null)
		{
			GestureInfo.GetComponent<GUIText>().text = string.Empty;
		}
	}

	public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              float progress, KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
		//GestureInfo.guiText.text = string.Format("{0} Progress: {1:F1}%", gesture, (progress * 100));
		if(gesture == KinectGestures.Gestures.Click && progress > 0.3f)
		{
			string sGestureText = string.Format ("{0} {1:F1}% complete", gesture, progress * 100);
			if(GestureInfo != null)
				GestureInfo.GetComponent<GUIText>().text = sGestureText;
			
			progressDisplayed = true;
		}		
		else if((gesture == KinectGestures.Gestures.ZoomOut || gesture == KinectGestures.Gestures.ZoomIn) && progress > 0.5f)
		{
			string sGestureText = string.Format ("{0} detected, zoom={1:F1}%", gesture, screenPos.z * 100);
			if(GestureInfo != null)
				GestureInfo.GetComponent<GUIText>().text = sGestureText;
			
			progressDisplayed = true;
		}
		else if(gesture == KinectGestures.Gestures.Wheel && progress > 0.5f)
		{
			string sGestureText = string.Format ("{0} detected, angle={1:F1} deg", gesture, screenPos.z);
			if(GestureInfo != null)
				GestureInfo.GetComponent<GUIText>().text = sGestureText;
			
			progressDisplayed = true;
		}
	}

	public bool GestureCompleted (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
		string sGestureText = gesture.ToString() + " detected";
		if(gesture == KinectGestures.Gestures.Click)
			sGestureText += string.Format(" at ({0:F1}, {1:F1})", screenPos.x, screenPos.y);
		
		if(GestureInfo != null)
			GestureInfo.GetComponent<GUIText>().text = sGestureText;

		//ほのお
		if(gesture == KinectGestures.Gestures.Psi || 
			gesture == KinectGestures.Gestures.RaiseLeftHand ||
			gesture == KinectGestures.Gestures.RaiseRightHand){
			this.GenerateFire (gesture);
		}

		//水
		if (gesture == KinectGestures.Gestures.SwipeLeft ||
		   gesture == KinectGestures.Gestures.SwipeRight) {
			this.GenerateWater (gesture);
		}

		//ビーム
		if(gesture == KinectGestures.Gestures.Push){
			this.GenerateBeam ();
		}

		//惑星
		if(gesture == KinectGestures.Gestures.SwipeUp){
			this.GeneratePlanet (joint);
		}

		//jointを確かめるだけ
		//Debug.Log("joint : "+joint+" Gesture : "+sGestureText);
		
		progressDisplayed = false;
		
		return true;
	}

	public bool GestureCancelled (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint)
	{
		if(progressDisplayed)
		{
			// clear the progress info
			if(GestureInfo != null)
				GestureInfo.GetComponent<GUIText>().text = String.Empty;
			
			progressDisplayed = false;
		}
		
		return true;
	}

	private void GenerateFire(KinectGestures.Gestures gesture){
		switch (gesture) {
		//case KinectGestures.Gestures.Psi:
			//this.fireObjectLeft.GetComponent<ParticleGenerator> ().Generate ();
			//this.fireObjectRight.GetComponent<ParticleGenerator> ().Generate ();
		//	break;
		case KinectGestures.Gestures.RaiseLeftHand:
			//effectMan.bachiL = true;
			//this.fireObjectLeft.GetComponent<ParticleGenerator> ().Generate ();
			break;
		case KinectGestures.Gestures.RaiseRightHand:
			//effectMan.bachiR = true;
			//this.fireObjec tRight.GetComponent<ParticleGenerator> ().Generate ();
			break;
		}
	}

	private void GenerateWater(KinectGestures.Gestures gesture){
		if (gesture == KinectGestures.Gestures.SwipeLeft &&
		   gesture == KinectGestures.Gestures.SwipeRight) {
			//this.waterObjectLeft.GetComponent<ParticleGenerator> ().Generate ();
			//this.waterObjectRight.GetComponent<ParticleGenerator> ().Generate ();
		}
		switch (gesture) {
		case KinectGestures.Gestures.SwipeLeft:
			//effectMan.wavL = true;
			//this.waterObjectLeft.GetComponent<ParticleGenerator> ().Generate ();
			break;
		case KinectGestures.Gestures.SwipeRight:
			//effectMan.wavR = true;
			//this.waterObjectRight.GetComponent<ParticleGenerator> ().Generate ();
			break;
		}
	}

	private void GenerateFootParticle(){
		//this.footParticleLeft.GetComponent<ParticleGenerator> ().Generate ();
		//this.footParticleRight.GetComponent<ParticleGenerator> ().Generate ();
	}

	private void StopFootParticle(){
		//this.footParticleLeft.GetComponent<ParticleGenerator> ().Stop ();
		//this.footParticleRight.GetComponent<ParticleGenerator> ().Stop ();
	}

	private void GenerateBeam(){
		
		//this.beamObjectLeft.GetComponent<ParticleGenerator> ().Generate ();
		//this.beamObjectRight.GetComponent<ParticleGenerator> ().Generate ();
	}

	private void GeneratePlanet(KinectWrapper.NuiSkeletonPositionIndex joint){
		switch(joint){
		case KinectWrapper.NuiSkeletonPositionIndex.HandRight:
			effectMan.planet = true;
//			this.planetObjectRight.GetComponent<PlanetBehaviour> ().Play ();
			break;
		case KinectWrapper.NuiSkeletonPositionIndex.HandLeft:
			effectMan.planet = true;
			//this.planetObjectLeft.GetComponent<PlanetBehaviour> ().Play ();
			break;
		}
	}
	
}
