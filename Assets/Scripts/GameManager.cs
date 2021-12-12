using UnityEngine;

namespace FPS
{
    public class GameManager : MonoBehaviour
    {
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
                    LevelLoader.LoadGameFinishedScene();
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
        }
    }
}