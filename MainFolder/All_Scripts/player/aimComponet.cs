 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimComponet : MonoBehaviour
{
    [SerializeField] Transform jahatAim;
    [SerializeField] float RageAim = 1000;
    [SerializeField] LayerMask AimMask;

   
    public GameObject GetAim(out Vector3 aimDir)
    {
        Vector3 aimStart = jahatAim.position;
        aimDir = GetDir();
        if(Physics.Raycast(aimStart , GetDir(), out RaycastHit hitInfo ,RageAim, AimMask))
        {
            return hitInfo.collider.gameObject;
        }

        return null;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(jahatAim.position, jahatAim.position + GetDir() * RageAim);
    }
    Vector3 GetDir()
    {
        Vector3 JahatAimDir = jahatAim.forward;
        return new Vector3(JahatAimDir.x, 0f, JahatAimDir.z).normalized;
    }
}
