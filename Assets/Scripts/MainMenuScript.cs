using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //Made with the help of https://www.youtube.com/watch?v=76WOa6IU_s8 
    [SerializeField]
    private string firstLevel;

    [SerializeField]
    private GameObject optionsScreen;
    // Start is called before the first frame update
  

    public void StartGame()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(firstLevel);
        LevelManagerScript.instance.loadLevel(SaveSystem.loadPlayer());
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
