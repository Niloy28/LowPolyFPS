using UnityEngine;

namespace FPS.Player
{
    public class CharacterSoundPlayer : MonoBehaviour
    {
        [Header("Character Audio Sources")]
        [SerializeField] private AudioSource movementAudioSource;
        [SerializeField] private AudioSource damageAudioSource;
        [Header("Movement Sounds")]
        [SerializeField] private AudioClip walkingSound;
        [SerializeField] private AudioClip runningSound;
        [Header("Damage Sounds")]
        [SerializeField] private AudioClip hitSound;
        [SerializeField] private AudioClip deathSound;

        private void PlayWalkingSound()
        {
            if (movementAudioSource.clip == walkingSound && movementAudioSource.isPlaying)
            {
                return;
            }
            movementAudioSource.Stop();
            movementAudioSource.clip = walkingSound;
            movementAudioSource.Play();
        }

        private void PlayRunningSound()
        {
            if (movementAudioSource.clip == runningSound && movementAudioSource.isPlaying)
            {
                return;
            }
            movementAudioSource.Stop();
            movementAudioSource.clip = runningSound;
            movementAudioSource.Play();
        }

        public void StopMovementSound()
        {
            movementAudioSource.Stop();
        }

        private void PlayPlayerHitSound()
        {
            damageAudioSource.Stop();
            damageAudioSource.clip = hitSound;
            damageAudioSource.Play();
        }

        private void PlayPlayerDeathSound()
        {
            damageAudioSource.Stop();
            damageAudioSource.clip = deathSound;
            damageAudioSource.Play();
        }

        private void OnEnable()
        {
            GameEvents.OnPlayerDamaged += PlayPlayerHitSound;
            GameEvents.OnPlayerDeath += PlayPlayerDeathSound;
        }

        private void OnDisable()
        {
            GameEvents.OnPlayerDamaged -= PlayPlayerHitSound;
            GameEvents.OnPlayerDeath -= PlayPlayerDeathSound;
        }
    }
}