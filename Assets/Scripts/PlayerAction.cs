using UnityEngine;
using UnityEngine.InputSystem;
using FPS.Weapon;

namespace FPS.Player
{
    public class PlayerAction : MonoBehaviour
    {
        [SerializeField] private Transform viewport;
        [SerializeField] private GameObject bulltePrefab;
        [SerializeField] private Transform bulletSpawnPoint;

        internal void Shoot(InputAction.CallbackContext _)
        {
            GameEvents.FireBulletShotEvent();
            var bullet = Instantiate(bulltePrefab, bulletSpawnPoint.position, viewport.rotation).GetComponent<Bullet>();
            bullet.ApplyVelocity(viewport.forward);
        }
    }
}