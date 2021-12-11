using UnityEngine;

namespace FPS
{
    public abstract class EntityHealth : MonoBehaviour
    {
        [SerializeField] protected int maxHealth = 100;
        [SerializeField] protected string hitTag;

        protected int currentHealth;
        protected Animator animator;

        protected abstract void HandleHit();
        protected abstract void HandleDeath();

        protected void Start()
        {
            animator = GetComponent<Animator>();
            currentHealth = maxHealth;
        }

        protected void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(hitTag))
            {
                HandleHit();
                if (currentHealth <= 0)
                {
                    HandleDeath();
                }
            }
        }
    }
}