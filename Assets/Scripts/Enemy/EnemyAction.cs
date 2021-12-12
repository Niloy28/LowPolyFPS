using System.Collections;
using UnityEngine;
using FPS.Weapon;

namespace FPS.Enemy
{
    public class EnemyAction : MonoBehaviour
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private float shootingDelay = 1.5f;

        private Transform player;
        private Animator animator;
        private bool isShootingAllowed;

        private void Start()
        {
            animator = GetComponent<Animator>();
            isShootingAllowed = true;
        }

        public void PrepareToShoot(Transform player)
        {
            if (isShootingAllowed)
            {
                animator.SetTrigger("Shoot");
                this.player = player;
                StartCoroutine(DelayNextShot());
            }
        }

        public void Shoot()
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            bullet.ApplyVelocity(transform.forward);
        }

        private IEnumerator DelayNextShot()
        {
            isShootingAllowed = false;
            yield return new WaitForSeconds(shootingDelay);
            isShootingAllowed = true;
        }
    }
}