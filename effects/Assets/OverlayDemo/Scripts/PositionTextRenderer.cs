using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class PositionTextRenderer : MonoBehaviour {
	public KinectWrapper.NuiSkeletonPositionIndex TrackedJoint = KinectWrapper.NuiSkeletonPositionIndex.HandRight;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		KinectManager manager = KinectManager.Instance;
		int iJointIndex = (int)TrackedJoint;
		if (manager.IsUserDetected ()) {
			uint userId = manager.GetPlayer1ID ();

			if (manager.IsJointTracked (userId, iJointIndex)) {
				Vector3 posJoint = manager.GetRawSkeletonJointPos (userId, iJointIndex);
				this.GetComponent<Text> ().text = "point" + posJoint;
			}
		}
	}
}
