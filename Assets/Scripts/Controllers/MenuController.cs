using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Controllers
{
    public class MenuController
    {
        public void NextScene()
        {
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
            LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void PreviousScene()
        {
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
            LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        private void LoadScene(int scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void ExitGame()
        {
            Debug.Log($"Game has exited");
            Application.Quit();
        }
    }
}
