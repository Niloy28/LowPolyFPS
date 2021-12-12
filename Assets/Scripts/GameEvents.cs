using System;

namespace FPS
{
    public static class GameEvents
    {
        public static event Action OnBulletShot;
        public static event Action OnBulletHit;
        public static event Action OnGunReloadAmmoLeft;
        public static event Action OnGunReloadOutOfAmmo;
        public static event Action OnPlayerDetected;
        public static event Action OnPlayerLost;
        public static event Action OnPlayerDamaged;
        public static event Action OnPlayerDeath;

        public static void FireBulletShotEvent()
        {
            OnBulletShot?.Invoke();
        }

        public static void FireBulletHitEvent()
        {
            OnBulletHit?.Invoke();
        }

        public static void FireGunReloadAmmoLeftEvent()
        {
            OnGunReloadAmmoLeft?.Invoke();
        }

        public static void FireGunReloadOutOfAmmoEvent()
        {
            OnGunReloadOutOfAmmo?.Invoke();
        }

        public static void FirePlayerDetectedEvent()
        {
            OnPlayerDetected?.Invoke();
        }

        public static void FirePlayerLostEvent()
        {
            OnPlayerLost?.Invoke();
        }

        public static void FirePlayerDamagedEvent()
        {
            OnPlayerDamaged?.Invoke();
        }

        public static void FirePlayerDeathEvent()
        {
            OnPlayerDeath?.Invoke();
        }
    }
}