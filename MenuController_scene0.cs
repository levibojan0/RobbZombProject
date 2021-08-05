using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController_scene0 : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene(1); 
    }
    public static void EXIT()
    {
        Application.Quit();
    }
}
