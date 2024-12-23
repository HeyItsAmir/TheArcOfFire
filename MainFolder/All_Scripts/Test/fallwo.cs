using UnityEngine;

public class CubeFollower : MonoBehaviour
{
    public Transform player;
    public float followDistance = 5f;
    public float movementSpeed = 5f;

    private Vector3 lastKnownPlayerPosition;

    private void Start()
    {
        lastKnownPlayerPosition = player.position;
    }

    private void Update()
    {
        // Calculate the distance between the cube and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the follow distance
        if (distanceToPlayer <= followDistance)
        {
            // Update the last known position of the player
            lastKnownPlayerPosition = player.position;

            // Calculate the direction vector towards the player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            // Move the cube towards the player
            transform.position += directionToPlayer * movementSpeed * Time.deltaTime;
        }
        else
        {
            // Calculate the direction vector towards the last known player position
            Vector3 directionToLastKnownPosition = (lastKnownPlayerPosition - transform.position).normalized;

            // Move the cube towards the last known player position
            transform.position += directionToLastKnownPosition * movementSpeed * Time.deltaTime;
        }
    }
}