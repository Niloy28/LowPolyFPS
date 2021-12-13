using System;
using UnityEngine;

namespace FPS.Enemy
{
    [RequireComponent(typeof(AudioSource))]
    public class EnemySoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip playerDetectedClip;
        [SerializeField] private AudioClip playerLostClip;
        [SerializeField] private AudioClip gunShotSound;

        private AudioSource audioSource;

        internal void DisableAllSound()
        {
            audioSource.Stop();
        }

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void PlayPlayerDetectedSound()
        {
            audioSource.Stop();
            audioSource.PlayOneShot(playerDetectedClip);
        }

        private void PlayPlayerLostSound()
        {
            audioSource.Stop();
            audioSource.PlayOneShot(playerLostClip);
        }

        private void PlayGunShotSound()
        {
            audioSource.PlayOneShot(gunShotSound, 0.1f);
        }

        private void OnEnable()
        {
            GameEvents.OnPlayerDetected += PlayPlayerDetectedSound;
            GameEvents.OnPlayerLost += PlayPlayerLostSound;
        }

        private void OnDisable()
        {
            GameEvents.OnPlayerDetected -= PlayPlayerDetectedSound;
            GameEvents.OnPlayerLost -= PlayPlayerLostSound;
        }
    }
}