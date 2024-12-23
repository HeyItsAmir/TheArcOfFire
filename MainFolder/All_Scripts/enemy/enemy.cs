using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody[] ragdollBodies;
    [SerializeField] Rigidbody enemyRigidbody;
    [SerializeField] perceptionComponent perception_Comp;
    [SerializeField] behoviorTree BHTR;
    [SerializeField] Transform player;
    NavMeshAgent agent;
    [SerializeField] sideSense sightSense;
    [SerializeField] AlwaysAwarsSesen awareSense;

   
    GameObject Target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (healthBar != null)
        {
            healthBar.onDeath += StartDeath;
            healthBar.onTakingDamage += TakingDamage;
        }
        perception_Comp.targetChanged += TargetChange;
        if (perception_Comp != null)
        {
            perception_Comp.targetChanged += TargetChange;
        }
    }

    private void TargetChange(GameObject target, bool sense)
    {
        if(sense)
        {
            BHTR.BlackBoard.SetOrAddData("Target", target);
            player = target.transform;
        }
        else
        {
            BHTR.BlackBoard.removeBlackBoard("Target");
            player = null;
        }
    }

    private void StartDeath()
    {
        TriggerToDeathAnimation();
        ApplyDeathForce();
    }

    private void TakingDamage(float health, float delta, float maxHealth, GameObject Instigator)
    {
        
    }

    public void TriggerToDeathAnimation()
    {
        if (animator != null)
        {
            animator.enabled = false;

            
            foreach (Rigidbody rb in ragdollBodies)
            {
                rb.isKinematic = false;
            }
        }
    }

    private void ApplyDeathForce()
    {
        if (enemyRigidbody != null)
        {
            Vector3 aimDirection = transform.forward; 
            float deathForce = 10f; 
            enemyRigidbody.AddForce(aimDirection * deathForce, ForceMode.Impulse);
        }
    }

    public void Update()
    {
        float speed = agent.velocity.magnitude;
        if (speed >= 1 )
        {
            animator.SetFloat("EnemyMovement", 1f);
        }
        else
        {
            animator.SetFloat("EnemyMovement", speed);
        }
        

        if (player != null)
        {
            Vector3 directionToPlayer = player.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        }
        //if (sightSense.IsStimulisSensable(player) && awareSense.IsStimulisSensable(player))
        //{
        //    Debug.Log("Player is close");
        //}
    }

    private void OnDrawGizmos()
    {
        if (BHTR && BHTR.BlackBoard.getBlackBoardData("Target", out GameObject target))
        {
            Vector3 darawTargetPosition = Target.transform.position + Vector3.up;
            Gizmos.DrawWireSphere(darawTargetPosition, 0.8f);  

            Gizmos.DrawLine(transform.position + Vector3.up , darawTargetPosition);

        }
    }

}