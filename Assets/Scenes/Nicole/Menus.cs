using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField] string nextScene;

    public void StartGame()
    {
        Debug.Log("Game Start!");
        SceneManager.LoadScene(nextScene);
    }
    
    public void ExitGame()
    {
        Debug.Log("Leave Game :(");
        Application.Quit();
    }
}