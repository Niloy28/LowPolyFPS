namespace FPS.Player
{
    public class PlayerHealth : EntityHealth
    {
        public int CurrentHealth => currentHealth;
        public int MaxHealth => maxHealth;

        protected override void HandleDeath()
        {
            GameEvents.FirePlayerDeathEvent();
            GetComponent<PlayerController>().DisableInputs();
        }

        protected override void HandleHit()
        {
            GameEvents.FirePlayerDamagedEvent();
            currentHealth -= 10;
        }
    }
}