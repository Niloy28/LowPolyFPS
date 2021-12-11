using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace FPS.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [Header("Wander Params")]
        [SerializeField] private float wanderRadius = 2f;
        [SerializeField] private float wanderDelay = 2f;
        [Header("Pursue Params")]
        [SerializeField] private float singleStep = 0.3f;
        [SerializeField] private float minDistanceFromPlayer = 2f;


        private NavMeshAgent agent;
        private Animator animator;
        private bool isWandering;
        private bool isMovementAllowed = true;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            animator.SetFloat("Velocity", agent.velocity.magnitude);
        }

        public void Wander()
        {
            if (!isMovementAllowed)
                return;

            if (!isWandering)
            {
                StartCoroutine(WaitBeforeNewWanderTarget(wanderDelay));

                float circleX = Random.Range(0, wanderRadius);
                float circleY = Mathf.Sqrt(wanderRadius * wanderRadius - circleX * circleX);

                var xPos = Random.Range(-circleX, circleX);
                var zPos = Random.Range(-circleY, circleY);

                Vector3 target = new Vector3(transform.position.x + xPos, 0, transform.position.z + zPos);
                agent.SetDestination(target);
            }
        }

        public void Pursue(Transform player)
        {
            FacePlayer(player);
            MoveTowardsPlayer(player);
        }

        private void MoveTowardsPlayer(Transform player)
        {
            agent.SetDestination(player.position);
        }

        private void FacePlayer(Transform player)
        {
            transform.LookAt(player);
        }

        private IEnumerator WaitBeforeNewWanderTarget(float wanderDelay)
        {
            isWandering = true;
            yield return new WaitForSeconds(wanderDelay);
            isWandering = false;
        }

        public void DisableMovement()
        {
            isMovementAllowed = false;
        }
    }
}