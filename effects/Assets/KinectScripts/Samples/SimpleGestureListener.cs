using UnityEngine;
using System.Collections;
using System;

public class SimpleGestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{
	// GUI Text to display the gesture messages.
	public GUIText GestureInfo;
	
	// private bool to track if progress message has been displayed
	private bool progressDisplayed;

	//足元のやつ
	public GameObject footParticle;

	//べつの場所でいじる
	/*public GameObject footParticleLeft;

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
	public GameObject planetObjectLeft;*/

	//ビーム発射じかん
	public float TTLBeam = 3.0f;
	//ほのお再生じかん
	public float TTLFire = 1.0f;
	//惑星再生じかん
	public float TTLPlanet = 5.0f;
	
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
		this.StopWater ();
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
			this.GeneratePlanet ();
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
		case KinectGestures.Gestures.Psi:
			effectMan.bachiL = true;
			effectMan.bachiR = true;
			//this.fireObjectLeft.GetComponent<ParticleGenerator> ().Generate ();
			//this.fireObjectRight.GetComponent<ParticleGenerator> ().Generate ();
			break;
		case KinectGestures.Gestures.RaiseLeftHand:
			effectMan.bachiL = true;
			//this.fireObjectLeft.GetComponent<ParticleGenerator> ().Generate ();
			break;
		case KinectGestures.Gestures.RaiseRightHand:
			effectMan.bachiR = true;
			//this.fireObjectRight.GetComponent<ParticleGenerator> ().Generate ();
			break;
		}
		Invoke ("StopFire", TTLFire);
	}

	private void StopFire(){
		effectMan.bachiL = false;
		effectMan.bachiR = false;
	}

	private void GenerateWater(KinectGestures.Gestures gesture){
		if (gesture == KinectGestures.Gestures.SwipeLeft &&
		   gesture == KinectGestures.Gestures.SwipeRight) {
			effectMan.wavL = true;
			effectMan.wavR = true;
			return;
			//this.waterObjectLeft.GetComponent<ParticleGenerator> ().Generate ();
			//this.waterObjectRight.GetComponent<ParticleGenerator> ().Generate ();
		}
		switch (gesture) {
		case KinectGestures.Gestures.SwipeLeft:
			effectMan.wavL = true;
			//this.waterObjectLeft.GetComponent<ParticleGenerator> ().Generate ();
			break;
		case KinectGestures.Gestures.SwipeRight:
			effectMan.wavR = true;
			//this.waterObjectRight.GetComponent<ParticleGenerator> ().Generate ();
			break;
		}
	}

	private void StopWater(){
		effectMan.wavL = false;
		effectMan.wavR = false;
	}

	private void GenerateFootParticle(){
		this.footParticle.GetComponent<ParticleGenerator> ().Generate ();
	}

	private void StopFootParticle(){
		this.footParticle.GetComponent<ParticleGenerator> ().Stop ();
	}

	private void GenerateBeam(){
		effectMan.beamsL = true;
		effectMan.beamsR = true;
		Invoke ("StopBeam", TTLBeam);
		//this.beamObjectLeft.GetComponent<ParticleGenerator> ().Generate ();
		//this.beamObjectRight.GetComponent<ParticleGenerator> ().Generate ();
	}

	private void StopBeam(){
		effectMan.beamsL = false;
		effectMan.beamsR = false;
	}

	private void GeneratePlanet(){
		effectMan.planetKun = true;
		Invoke ("StopPlanet", TTLPlanet);
		/*switch(joint){
		case KinectWrapper.NuiSkeletonPositionIndex.HandRight:
			this.planetObjectRight.GetComponent<PlanetBehaviour> ().Play ();
			break;
		case KinectWrapper.NuiSkeletonPositionIndex.HandLeft:
			this.planetObjectLeft.GetComponent<PlanetBehaviour> ().Play ();
			break;
		}*/
	}

	private void StopPlanet(){
		effectMan.planetKun = false;
	}
	
}
