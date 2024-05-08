using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }
        public ThirdPersonCharacter character { get; private set; }
        public Transform[] waypoints; // Array of waypoints for patrolling
        private int currentWaypointIndex = 0;

        public float chaseDistance = 20f; // Distance threshold to start chasing the target
        public float followDistance = 10f; // Distance threshold to switch to following the player

        public Transform target;
        public bool isFollowingPlayer;

        [Header("Third Person Enemy")]
        public ThirdPersonCharacter thirdPerson;

        private Animator animator;

        private void Start()
        {
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            animator = GetComponent<Animator>();
            agent.updateRotation = false;
            agent.updatePosition = true;

            // Initialize waypoint patrol if waypoints are set
            if (waypoints != null && waypoints.Length > 0)
            {
                SetTarget(waypoints[currentWaypointIndex]);
            }
        }

        private void Update()
        {
            
            // Calculate distance between player (target) and this enemy
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget <= followDistance && !thirdPerson.hasEnemyDied)
            {
                // If distance to player is less than or equal to followDistance, follow the player
                agent.SetDestination(target.position);
                isFollowingPlayer = true;

                animator.SetTrigger("Shooting");
                animator.ResetTrigger("NotShooting");
            }
            else if (waypoints != null && waypoints.Length > 0 && !thirdPerson.hasEnemyDied)
            {
                // If distance to player is greater than followDistance, move towards waypoints
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    // Set next waypoint as target
                    isFollowingPlayer = false;
                    currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                    SetTarget(waypoints[currentWaypointIndex]);

                    animator.SetTrigger("NotShooting");
                    animator.ResetTrigger("Shooting");
                }
            }

            if (agent.remainingDistance > agent.stoppingDistance && !thirdPerson.hasEnemyDied)
            {
                // Move the character
                character.Move(agent.desiredVelocity, false, false);
            }
            else
            {
                // Stop moving
                character.Move(Vector3.zero, false, false);
            }
        }

        public void SetTarget(Transform newTarget)
        {
            agent.SetDestination(newTarget.position);
        }
    }
}
