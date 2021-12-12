using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FPS
{
    public class LevelLoader : MonoBehaviour
    {
        public void LoadGame()
        {
            SceneManager.LoadScene("Level 1");
        }

        public static void LoadGameOver()
        {
            SceneManager.LoadScene("Game Over");
        }

        public static void LoadGameFinishedScene()
        {
            SceneManager.LoadScene("Game Finished");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}