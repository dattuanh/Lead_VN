using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(pauseMenu);
        Time.timeScale = 0;
    }

    public void Home()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
