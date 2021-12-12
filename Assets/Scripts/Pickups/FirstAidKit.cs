using FPS.Player;
using UnityEngine;

namespace FPS
{
    public class FirstAidKit : Pickup
    {
        [SerializeField] private int healAmount = 20;

        protected override void PickupAction(Collider collider)
        {
            var playerHealth = collider.GetComponent<PlayerHealth>();
            if (playerHealth.CurrentHealth < playerHealth.MaxHealth)
            {
                collider.GetComponent<PlayerHealth>().CurrentHealth += healAmount;
                Destroy(gameObject);
            }
        }
    }
}