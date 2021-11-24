using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public static class GameEvents
    {
        public static event Action OnBulletShot;
        public static event Action OnBulletHit;

        public static void FireBulletShotEvent()
        {
            OnBulletShot?.Invoke();
        }

        public static void FireBulletHitEvent()
        {
            OnBulletHit?.Invoke();
        }
    }
}