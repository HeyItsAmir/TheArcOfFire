using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : BTnode
{
    NavMeshAgent agent;
    string targetKey;
    GameObject target;
    float distance = 4f;
    behoviorTree tree;
    // ...

    // Distance to maintain from the player
    float distanceToMaintain = 2f;

    // ...


    public MoveToTarget(behoviorTree tree, string targetKey, float distance = 4f)
    {
        this.tree = tree;
        this.targetKey = targetKey;
        this.distance = distance;
    }

    protected override nodeResult Execute()
    {
        blackBoard blackBoard = tree.BlackBoard;
        if (blackBoard == null|| !blackBoard.getBlackBoardData(targetKey, out target))
        {
            return nodeResult.eshtebah;
        }
        agent = tree.GetComponent<NavMeshAgent>();
        if (agent == null)
        
            return nodeResult.eshtebah;
            
        if (IsTargetInAcceptableDiatance()) 
        
            return nodeResult.mofaghiatAmijz;


        blackBoard.onChange += BlackboardValueChanged;

        agent.SetDestination(target.transform.position);
        agent.isStopped = false;
        return nodeResult.darHalAnjam; 
    }

    private void BlackboardValueChanged(string key, object value)
    {
        if (key == targetKey)
        {
            target = (GameObject)value;
        }
    }

    protected override nodeResult Update()
    {
        // ...

        // Calculate the direction vector towards the player
        Vector3 directionToPlayer = target.transform.position - tree.transform.position;
        directionToPlayer.Normalize();

        // Calculate the new destination with the desired distance from the player
        Vector3 destination = target.transform.position - directionToPlayer * distanceToMaintain;

        // Set the new destination for the enemy to move towards
        agent.SetDestination(destination);

        if (target == null)
        {
            agent.isStopped = true;
            return nodeResult.eshtebah;
        }
        agent.SetDestination(target.transform.position);
        if(IsTargetInAcceptableDiatance())
        {
            agent.isStopped = true;
            return nodeResult.mofaghiatAmijz;
        }
        return nodeResult.darHalAnjam;
    }
    bool IsTargetInAcceptableDiatance()
    {
        return Vector3.Distance(target.transform.position, tree.transform.position) <= distance;
    }


}
