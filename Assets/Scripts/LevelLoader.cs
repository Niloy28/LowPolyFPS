using UnityEngine;
using UnityEngine.SceneManagement;

namespace FPS
{
    public class LevelLoader : MonoBehaviour
    {
        public static LevelLoader Instance { get; private set; }

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

        public void LoadGame()
        {
            SceneManager.LoadScene("Level 1");
        }

        public void LoadGameOver()
        {
            SceneManager.LoadScene("Game Over");
        }

        public void LoadGameFinishedScene()
        {
            SceneManager.LoadScene("Game Finished");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}