using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDestination : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed;

    private Transform currentTarget;

    private void Start()
    {
        // Initialize by moving towards a random waypoint
        SetRandomTarget();
    }

    private void Update()
    {
        // Check if we've reached the current target
        if (Vector3.Distance(transform.position, currentTarget.position) <= 0.1f)
        {
            // Set a new random target once we reach the current one
            SetRandomTarget();
        }

        // Move towards the current target
        MoveTowardsTarget();
    }

    private void SetRandomTarget()
    {
        // Choose a random waypoint from the array
        int randomIndex = Random.Range(0, waypoints.Length);
        currentTarget = waypoints[randomIndex];
    }

    private void MoveTowardsTarget()
    {
        // Move towards the current target
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
    }
}
