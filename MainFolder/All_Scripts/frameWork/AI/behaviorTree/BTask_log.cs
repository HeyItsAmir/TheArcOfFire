using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTask_log : BTnode
{
    string message;
    public BTask_log(string message) 
    {
        this.message = message;
    }

    protected override nodeResult Execute()
    {
        Debug.Log(message);
        return nodeResult.mofaghiatAmijz;
    }
}
