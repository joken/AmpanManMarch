using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KinectOverlayer : MonoBehaviour 
{
//	public Vector3 TopLeft;
//	public Vector3 TopRight;
//	public Vector3 BottomRight;
//	public Vector3 BottomLeft;

	public GUITexture backgroundImage;
	//public KinectWrapper.NuiSkeletonPositionIndex TrackedJoint = KinectWrapper.NuiSkeletonPositionIndex.HandRight;
	private List<KinectWrapper.NuiSkeletonPositionIndex> TrackedJoints;
	public List<GameObject> OverlayObjects;
	public float smoothFactor = 5f;
	
	public GUIText debugText;

	private float distanceToCamera = 10f;


	void Start()
	{
		TrackedJoints = new List<KinectWrapper.NuiSkeletonPositionIndex> (OverlayObjects.Count);
		OverlayObjects.ForEach (o => TrackedJoints.Add(o.GetComponent<SkeltonPosIndexName>().getSkelton()));
		if(OverlayObjects[0])
		{
			distanceToCamera = (OverlayObjects[0].transform.position - Camera.main.transform.position).magnitude;
		}
	}
	
	void Update() 
	{
		KinectManager manager = KinectManager.Instance;
		
		if(manager && manager.IsInitialized())
		{
			//backgroundImage.renderer.material.mainTexture = manager.GetUsersClrTex();
			if(backgroundImage && (backgroundImage.texture == null))
			{
				backgroundImage.texture = manager.GetUsersClrTex();
			}
			
//			Vector3 vRight = BottomRight - BottomLeft;
//			Vector3 vUp = TopLeft - BottomLeft;

			if (manager.IsUserDetected ()) {
				uint userId = manager.GetPlayer1ID ();

				foreach(GameObject joint in this.OverlayObjects) {
					KinectWrapper.NuiSkeletonPositionIndex skelton = joint.GetComponent<SkeltonPosIndexName>().getSkelton();
					int iJointIndex = this.TrackedJoints.IndexOf(skelton);
					Debug.Log ("Pos : "+iJointIndex);

					if (manager.IsJointTracked (userId, iJointIndex)) {
						Vector3 posJoint = manager.GetRawSkeletonJointPos (userId, (int)skelton);
				
						if (posJoint != Vector3.zero) {
							// 3d position to depth
							Vector2 posDepth = manager.GetDepthMapPosForJointPos (posJoint);
							
							// depth pos to color pos
							Vector2 posColor = manager.GetColorMapPosForDepthPos (posDepth);
							
							float scaleX = (float)posColor.x / KinectWrapper.Constants.ColorImageWidth;
							float scaleY = 1.0f - (float)posColor.y / KinectWrapper.Constants.ColorImageHeight;
							
							//						Vector3 localPos = new Vector3(scaleX * 10f - 5f, 0f, scaleY * 10f - 5f); // 5f is 1/2 of 10f - size of the plane
							//						Vector3 vPosOverlay = backgroundImage.transform.TransformPoint(localPos);
							//Vector3 vPosOverlay = BottomLeft + ((vRight * scaleX) + (vUp * scaleY));
				
							if (debugText) {
								debugText.GetComponent<GUIText> ().text = "Tracked user ID: " + userId;  // new Vector2(scaleX, scaleY).ToString();
							}
							
							if (OverlayObjects[0]) {
								Vector3 vPosOverlay = Camera.main.ViewportToWorldPoint (new Vector3 (scaleX, scaleY, distanceToCamera));
								OverlayObjects[iJointIndex].transform.position = Vector3.Lerp (OverlayObjects[iJointIndex].transform.position, vPosOverlay, smoothFactor * Time.deltaTime);
							}
						}
					}
					
				}
			}
			
		}
	}
}
