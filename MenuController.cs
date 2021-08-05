using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject topbar_Activator;
    public GameObject topbar_Deactivator;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        topbar_Activator.SetActive(true);
        topbar_Deactivator.SetActive(false);

        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        topbar_Deactivator.SetActive(true);
        topbar_Activator.SetActive(false);


        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("LoadingMenu...");
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }

    public void QuitGame()
    {
        Application.Quit();
        //MenuController_scene0.EXIT();
    }
}