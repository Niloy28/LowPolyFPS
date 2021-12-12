using FPS.Player;
using UnityEngine;

namespace FPS
{
    public class AmmoBox : Pickup
    {
        [SerializeField] private int ammo = 30;

        protected override void PickupAction(Collider collider)
        {
            var playerAction = collider.GetComponentInChildren<PlayerAction>();
            if (playerAction.CurrentAmmoCount < playerAction.MaxAmmoCapacity)
            {
                playerAction.CurrentAmmoCount += ammo;
                Destroy(gameObject);
            }
        }
    }
}