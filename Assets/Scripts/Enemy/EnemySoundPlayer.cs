using UnityEngine;

namespace FPS.Enemy
{
    [RequireComponent(typeof(AudioSource))]
    public class EnemySoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip playerDetectedClip;
        [SerializeField] private AudioClip playerLostClip;

        private AudioSource audioSource;

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