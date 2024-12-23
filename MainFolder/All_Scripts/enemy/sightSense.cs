using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideSense : senseComp
{
    [SerializeField] float sightDistance = 5f;
    [SerializeField] float sightAngle = 5f;
    [SerializeField] float eyeAngleHight = 1f; 
    protected override bool IsStimulisSensable(perception stimulis)
    {
       float ditance = Vector3.Distance(stimulis.transform.position, transform.position);

        if (ditance > sightDistance)
        
            return false;
        
        Vector3 forwardDir = transform.forward;
        Vector3 stimulisDir = (stimulis.transform.position - transform.position).normalized;

         if( Vector3.Angle(forwardDir, stimulisDir) > sightAngle)
            return false;   

         if(Physics.Raycast(transform.position + Vector3.up * eyeAngleHight, stimulisDir, out RaycastHit hitInfo, sightDistance))
         {
            if (hitInfo.collider.gameObject != stimulis.gameObject)
            {
                return false ;
            }
         }

         return true ;

    }

    protected override void draawDebog()
    {
        base.draawDebog();
        Vector3 darwCenter = transform.position + Vector3.up * eyeAngleHight;

        Gizmos.DrawWireSphere(darwCenter, sightDistance);

        Vector3 leftLimitDir = Quaternion.AngleAxis(sightAngle,Vector3.up) * transform.forward;
        Vector3 rightLimitDir = Quaternion.AngleAxis(-sightAngle, Vector3.up) * transform.forward;

        Gizmos.DrawLine(darwCenter, darwCenter + leftLimitDir * sightDistance);
        Gizmos.DrawLine(darwCenter, darwCenter + rightLimitDir * sightDistance);

    }



}
