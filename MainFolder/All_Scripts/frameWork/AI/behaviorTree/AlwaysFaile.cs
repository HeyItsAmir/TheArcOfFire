using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFaile : BTnode
{
    protected override nodeResult Execute()
    {
        Debug.Log("eshtebah");
        return nodeResult.eshtebah;
    }
}
