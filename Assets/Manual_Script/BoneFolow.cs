using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneFolow : MonoBehaviour {

    public Transform FollowTransform;
    public Vector3 MoveGlobalposition, MoveGlobalrotation;
    [Range(0f, 1f)]
    public float FollowEasing, MoveEasing;

    Transform FirstPosition;
    Vector3 NonHandedPos, NonhandedRot;
	// Use this for initialization
	void Start () {
        FirstPosition = gameObject.transform;
    }
	
	// Update is called once per frame
	void Update () {
        MoveGlobalrotation 
            = new Vector3(Mathf.DeltaAngle(0f,MoveGlobalrotation.x), Mathf.DeltaAngle(0f, MoveGlobalrotation.y), Mathf.DeltaAngle(0f, MoveGlobalrotation.z));
        if (FollowEasing <=0)
        {
            gameObject.transform.position = FollowTransform.position + MoveEasing * MoveGlobalposition;
            gameObject.transform.eulerAngles = FollowTransform.eulerAngles + MoveEasing * MoveGlobalrotation;

            NonHandedPos = FollowTransform.position;
            NonhandedRot = FollowTransform.eulerAngles;
        }
        else
        {
            gameObject.transform.position = (1 - FollowEasing) * FollowTransform.position + FollowEasing * NonHandedPos + MoveEasing * MoveGlobalposition;
            gameObject.transform.eulerAngles =  (1 - FollowEasing) * FollowTransform.eulerAngles + FollowEasing * NonhandedRot + MoveEasing * MoveGlobalrotation;
        }
    }
}
