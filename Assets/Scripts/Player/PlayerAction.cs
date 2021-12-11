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

        private Animator animator;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        internal void Shoot(InputAction.CallbackContext _)
        {
            animator.Play("Fire", 0, 0f);
            var bullet = Instantiate(bulltePrefab, bulletSpawnPoint.position, viewport.rotation).GetComponent<Bullet>();
            bullet.ApplyVelocity(viewport.forward);
        }
    }
}