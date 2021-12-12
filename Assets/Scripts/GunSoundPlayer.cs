using System.Collections.Generic;
using UnityEngine;

namespace FPS.Weapon
{
    public class GunSoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip gunTakeOutSound;
        [SerializeField] private AudioClip reloadAmmoLeftSound;
        [SerializeField] private AudioClip reloadOutOfAmmoSound;
        [SerializeField] private AudioClip shootingSound;
        [SerializeField] private List<AudioClip> bulletHitSounds;

        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void PlayGunTakeOutSound()
        {
            audioSource.PlayOneShot(gunTakeOutSound);
        }

        private void PlayShootingSound()
        {
            audioSource.PlayOneShot(shootingSound);
        }

        private void PlayBulletHitSound()
        {
            var soundToPlay = bulletHitSounds[Random.Range(0, bulletHitSounds.Count)];
            audioSource.PlayOneShot(soundToPlay);
        }

        private void PlayReloadAmmoLeftSound()
        {
            audioSource.PlayOneShot(reloadAmmoLeftSound);
        }

        private void PlayReloadOutOfAmmoSound()
        {
            audioSource.PlayOneShot(reloadOutOfAmmoSound);
        }

        private void OnEnable()
        {
            GameEvents.OnBulletHit += PlayBulletHitSound;
            GameEvents.OnGunReloadAmmoLeft += PlayReloadAmmoLeftSound;
            GameEvents.OnGunReloadOutOfAmmo += PlayReloadOutOfAmmoSound;
        }

        private void OnDisable()
        {
            GameEvents.OnBulletHit -= PlayBulletHitSound;
            GameEvents.OnGunReloadAmmoLeft -= PlayReloadAmmoLeftSound;
            GameEvents.OnGunReloadOutOfAmmo -= PlayReloadOutOfAmmoSound;
        }
    }
}