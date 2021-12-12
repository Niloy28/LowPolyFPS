using UnityEngine;

namespace FPS.Enemy
{
    public class EnemyHealth : EntityHealth
    {
        [SerializeField] private EnemyMovement movement;

        protected override void HandleDeath()
        {
            movement.DisableMovement();
            GameManager.Instance.EnemiesKilled++;
            animator.Play("Die", 0);
        }

        protected override void HandleHit()
        {
            currentHealth -= 10;
            Debug.Log(currentHealth);
        }

        public void DestroyEnemy()
        {
            Destroy(gameObject, 1f);
        }
    }
}