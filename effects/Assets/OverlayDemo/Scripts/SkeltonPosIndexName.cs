using UnityEngine;
using System.Collections;

public class SkeltonPosIndexName : MonoBehaviour {

	public KinectWrapper.NuiSkeletonPositionIndex Skelton ;

	public KinectWrapper.NuiSkeletonPositionIndex getSkelton(){
		return this.Skelton;
	}
}
