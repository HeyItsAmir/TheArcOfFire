using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysAwarsSesen : senseComp
{
    [SerializeField] float awareDisSense = 2f;
    protected override bool IsStimulisSensable(perception stimulis)
    {
        return Vector3.Distance(transform.position, stimulis.transform.position) <= awareDisSense;
    }

    protected override void draawDebog()
    {
        base.draawDebog();
        Gizmos.DrawWireSphere(transform.position + Vector3.up, awareDisSense);
    }
}
