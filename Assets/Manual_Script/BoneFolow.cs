using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneFolow : MonoBehaviour {

    public Transform FollowTransform;
    public Vector3 MoveGlobalposition, MoveGlovalrotation;
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
        MoveGlovalrotation 
            = new Vector3(Mathf.DeltaAngle(0f,MoveGlovalrotation.x), Mathf.DeltaAngle(0f, MoveGlovalrotation.y), Mathf.DeltaAngle(0f, MoveGlovalrotation.z));
        if (FollowEasing <=0)
        {
            gameObject.transform.position = FollowTransform.position + MoveEasing * MoveGlobalposition;
            gameObject.transform.eulerAngles = FollowTransform.eulerAngles + MoveEasing * MoveGlovalrotation;

            NonHandedPos = FollowTransform.position;
            NonhandedRot = FollowTransform.eulerAngles;
        }
        else
        {
            gameObject.transform.position = (1 - FollowEasing) * FollowTransform.position + FollowEasing * NonHandedPos + MoveEasing * MoveGlobalposition;
            gameObject.transform.eulerAngles =  (1 - FollowEasing) * FollowTransform.eulerAngles + FollowEasing * NonhandedRot + MoveEasing * MoveGlovalrotation;
        }
    }
}
