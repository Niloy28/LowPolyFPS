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
        [Header("Gun Params")]
        [SerializeField] private int bulletsInMagazine = 10;
        [SerializeField] private int magazineSize = 50;
        [SerializeField] private int maxAmmoCapacity = 200;

        private int currentAmmoCount;

        public int BulletsInMagazine => bulletsInMagazine;
        public int MagazineSize => magazineSize;
        public int MaxAmmoCapacity => maxAmmoCapacity;
        public int CurrentAmmoCount
        {
            get => currentAmmoCount;
            set
            {
                currentAmmoCount = value;
                currentAmmoCount = Mathf.Clamp(currentAmmoCount, 0, maxAmmoCapacity);
            }
        }

        private Animator animator;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        private void Start()
        {
            currentAmmoCount = maxAmmoCapacity;
        }

        internal void Shoot(InputAction.CallbackContext _)
        {
            if (bulletsInMagazine > 0)
            {
                animator.Play("Fire", 0, 0f);
                var bullet = Instantiate(bulltePrefab, bulletSpawnPoint.position, viewport.rotation).GetComponent<Bullet>();
                bullet.ApplyVelocity(viewport.forward);
                bulletsInMagazine--;
            }
        }

        internal void Reload(InputAction.CallbackContext obj)
        {
            if (bulletsInMagazine > 0)
            {
                animator.Play("Reload Ammo Left", 0);
                GameEvents.FireGunReloadAmmoLeftEvent();
            }
            else if (bulletsInMagazine == 0)
            {
                animator.Play("Reload Out Of Ammo", 0);
                GameEvents.FireGunReloadOutOfAmmoEvent();
            }
        }

        public void ReloadMagazine()
        {
            var loadAmount = magazineSize - bulletsInMagazine;
            loadAmount = Mathf.Clamp(loadAmount, 0, currentAmmoCount);

            bulletsInMagazine += loadAmount;
            currentAmmoCount -= loadAmount;
        }
    }
}