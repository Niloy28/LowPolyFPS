using System;
using UnityEngine;

namespace FPS
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private bool lockCursor = true;

        public static GameManager Instance { get; private set; }

        public int LevelEnemyCount { get; set; }
        public int EnemiesKilled
        {
            get => enemiesKilled;
            set
            {
                enemiesKilled = value;
                if (EnemiesKilled == LevelEnemyCount)
                {
                    LevelLoader.Instance.LoadGameFinishedScene();
                }
            }
        }

        private int enemiesKilled;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            LockCursor();
        }

        public void LockCursor()
        {
            if (lockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        public void UnlockCursor()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        private void OnDestroy()
        {
            UnlockCursor();
        }
    }
}