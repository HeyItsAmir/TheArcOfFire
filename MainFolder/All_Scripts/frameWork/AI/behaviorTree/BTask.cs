using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT : BTnode
{
    
    float waitTime = 2f;
    float timeElapsed = 0f;

    public BT(float waitTime)
    {
      this.waitTime = waitTime;          
    }

    protected override nodeResult Execute()
    {
        if (waitTime <= 0) 
        {
            return nodeResult.mofaghiatAmijz;           
        }
        Debug.Log($"wait started with duration{waitTime}");
        timeElapsed = 0f;
        return nodeResult.darHalAnjam;  
    }
    protected override nodeResult Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= waitTime)
        {
            Debug.Log("wait finished");
            return nodeResult.mofaghiatAmijz;        
        }
        //Debug.Log($"waiting for {timeElapsed}");
        return nodeResult.darHalAnjam;
    }
}
