using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sequencers : compositor
{
    protected override nodeResult Update()
    {
        nodeResult result = GetCurrentChild().updateNode();

        if(result == nodeResult.eshtebah)
        {
            return nodeResult.eshtebah;
        }
        if(result == nodeResult.mofaghiatAmijz)
        {
            if (Next())          
                return nodeResult.darHalAnjam;          
            else            
               return nodeResult.mofaghiatAmijz;
                     
        }
        return nodeResult.darHalAnjam;
    }
}
