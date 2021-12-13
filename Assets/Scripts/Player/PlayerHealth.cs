using System.Collections;
using UnityEngine;

namespace FPS.Player
{
    public class PlayerHealth : EntityHealth
    {
        public int CurrentHealth
        {
            get => currentHealth;
            set
            {
                currentHealth = Mathf.Clamp(value, 0, maxHealth);
            }
        }
        public int MaxHealth => maxHealth;

        protected override void HandleDeath()
        {
            GameEvents.FirePlayerDeathEvent();
            GetComponent<PlayerController>().DisableInputs();
            StartCoroutine(DelayGameOver());
        }

        private IEnumerator DelayGameOver()
        {
            yield return new WaitForSeconds(1f);
            LevelLoader.Instance.LoadGameOver();
        }

        protected override void HandleHit()
        {
            GameEvents.FirePlayerDamagedEvent();
            currentHealth -= 5;
        }
    }
}