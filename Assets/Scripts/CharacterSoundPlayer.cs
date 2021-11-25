using UnityEngine;

namespace FPS.Player
{
    public class CharacterSoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource characterAudioSource;
        [Header("Movement Sounds")]
        [SerializeField] private AudioClip walkingSound;
        [SerializeField] private AudioClip runningSound;

        private void PlayWalkingSound()
        {
            if (characterAudioSource.clip == walkingSound && characterAudioSource.isPlaying)
            {
                return;
            }
            characterAudioSource.Stop();
            characterAudioSource.clip = walkingSound;
            characterAudioSource.Play();
        }

        private void PlayRunningSound()
        {
            if (characterAudioSource.clip == runningSound && characterAudioSource.isPlaying)
            {
                return;
            }
            characterAudioSource.Stop();
            characterAudioSource.clip = runningSound;
            characterAudioSource.Play();
        }

        public void StopMovementSound()
        {
            characterAudioSource.Stop();
        }
    }
}