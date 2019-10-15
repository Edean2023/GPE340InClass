using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKThing : MonoBehaviour
{
    // sets arm positions depending on the weight
    // should be used for different weapons
    public Transform rhPoint;
    public Transform lhPoint;

    public Transform rElbow;
    public Transform lElbow;

    [Range(0, 1)] public float weight;

    public Animator anim;
    // Start is called before the first frame update
    public void Start()
    {
        if (anim == null) anim = GetComponent<Animator>();
    }

    public void OnAnimatorIK()
    {
        anim.SetIKPosition(AvatarIKGoal.RightHand, rhPoint.position);
        anim.SetIKPosition(AvatarIKGoal.LeftHand, lhPoint.position);

        anim.SetIKRotation(AvatarIKGoal.RightHand, rhPoint.rotation);
        anim.SetIKRotation(AvatarIKGoal.LeftHand, lhPoint.rotation);

        anim.SetIKHintPosition(AvatarIKHint.RightElbow, rElbow.position);
        anim.SetIKHintPosition(AvatarIKHint.LeftElbow, lElbow.position);
        anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, weight);
        anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, weight);

        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, weight);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, weight);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, weight);

    }

}
