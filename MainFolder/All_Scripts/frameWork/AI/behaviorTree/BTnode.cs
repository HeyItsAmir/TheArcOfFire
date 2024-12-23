using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum nodeResult 
{
    mofaghiatAmijz,
    eshtebah,
    darHalAnjam
}


public abstract class BTnode 
{



    public nodeResult updateNode()
    {
        if(!ShoroShode)
        {
            ShoroShode = false;
            nodeResult execResult = Execute();
            if (execResult != nodeResult.darHalAnjam)
            {
                endNode();
                return execResult;
            }
        }
        nodeResult updateResult = Update();
        if (updateResult != nodeResult.darHalAnjam)
        {
            endNode();
        }
        return updateResult;
    }


    protected virtual nodeResult Execute()
    {
        return nodeResult.mofaghiatAmijz;
    }

    protected virtual nodeResult Update()
    {
        return nodeResult.mofaghiatAmijz;
    }

    protected virtual void End()
    {

    }

    private void endNode()
    {
        ShoroShode = false;
        End();
    }

    bool ShoroShode = false;
}
