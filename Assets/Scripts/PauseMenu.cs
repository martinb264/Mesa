using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    [SerializeField]
    private GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnPauseMenu()
    {
        if (isPaused)
        {
            resume();
        }
        else
        {
            pause();
        }
    }
    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
    public void menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
    public void quit()
    {
        Application.Quit();
    }
    public void boss()
    {
        Time.timeScale = 1;
        this.transform.position = new Vector3(176, -10, 0);
    }


}
