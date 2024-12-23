using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehovior : behoviorTree
{
    protected override void ConstructTree(out BTnode rootNode)
    {
       MoveToTarget moveToTarget = new MoveToTarget(this, "Target", 4f);
            
        rootNode = moveToTarget;

    }
    
    
}
