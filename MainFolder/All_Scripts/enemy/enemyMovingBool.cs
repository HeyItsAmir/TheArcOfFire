using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovingBool : MonoBehaviour
{
    [SerializeField] Transform player;
    private float initialZPosition;
    private float backwardDistanceThreshold = 5f; 

    void Start()
    {
        initialZPosition = transform.position.z;
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer < backwardDistanceThreshold)
            {
                Vector3 newPosition = transform.position;
                newPosition.z = initialZPosition - (backwardDistanceThreshold - distanceToPlayer);
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 3f);
            }
        }
    }

}
