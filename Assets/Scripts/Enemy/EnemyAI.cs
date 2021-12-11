using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private float pursueTimeAfterPlayerBeyondRange = 5f;
        [SerializeField] private Transform visor;
        [SerializeField] private LayerMask raycastLayer;
        [SerializeField] private float viewDistance = 5f;

        private EnemyMovement enemyMovement;
        private EnemyAction enemyAction;
        private EnemyHealth enemyHealth;

        private EnemyState enemyState;
        private Transform player;

        private void Awake()
        {
            enemyMovement = GetComponent<EnemyMovement>();
            enemyAction = GetComponent<EnemyAction>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Start()
        {
            enemyState = EnemyState.Wander;
        }

        private void Update()
        {
            switch (enemyState)
            {
                case EnemyState.Wander:
                    enemyMovement.Wander();
                    break;
                case EnemyState.Pursue:
                    enemyMovement.Pursue(player);
                    enemyAction.Shoot(player);
                    break;
                default:
                    break;
            }
        }

        private void FixedUpdate()
        {
            Ray ray = new Ray(visor.position, visor.forward);
            if (Physics.Raycast(ray, out _, viewDistance, raycastLayer))
            {
                ChangeToPursueState();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                ChangeToPursueState();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(PursueAfterPlayer());
            }
        }

        private void ChangeToWanderState()
        {
            if (enemyState == EnemyState.Wander) return;
            GameEvents.FirePlayerLostEvent();
            enemyState = EnemyState.Wander;
        }

        private void ChangeToPursueState()
        {
            if (enemyState == EnemyState.Pursue) return;
            GameEvents.FirePlayerDetectedEvent();
            enemyState = EnemyState.Pursue;
        }

        private IEnumerator PursueAfterPlayer()
        {
            yield return new WaitForSeconds(pursueTimeAfterPlayerBeyondRange);
            ChangeToWanderState();
        }
    }
}