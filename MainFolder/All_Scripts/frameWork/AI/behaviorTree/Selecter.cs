using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecter : compositor
{
    protected override nodeResult Update()
    {
        nodeResult result = GetCurrentChild().updateNode();
        if(result == nodeResult.mofaghiatAmijz)
        {
            return nodeResult.mofaghiatAmijz; 
        }
        if (result == nodeResult.eshtebah)
        {
            if (Next())            
                return nodeResult.darHalAnjam;           
            else           
                return nodeResult.eshtebah;
            
        }
        return nodeResult.darHalAnjam;

    }
}
