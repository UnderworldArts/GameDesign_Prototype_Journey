using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField] string nextScene; // assign script to a menu manager game object in scene, writing the scene name EXCATLY that you want the button to trigger

    [SerializeField] GameObject popUp;
    [SerializeField] Animator anim;

    AudioSource source; // nickname for the text sound effect
    bool onScreen = false;

    void Start()
    {
        source = GetComponent<AudioSource>(); // assigns as the audiosource from the game object the script is on
    }

    public void NextScene() // drag the manager under the on click section on the button game object and select this function under the menus drop down
    {
        Debug.Log("New Scene");
        SceneManager.LoadScene(nextScene);
    }

    public void ExitGame() // drag the manager under the on click section on the button game object and select this function under the menus drop down
    {
        Debug.Log("Leave Game :(");
        Application.Quit();
    }

    public void PopupIN()
    {
        this.gameObject.SetActive(true);
        Debug.Log("Pop up comes up!");
        if (anim == null)
        return;
        anim.SetBool("In", true);
        anim.SetBool("Out", false);

        if (onScreen == false)
        OpenAudio();
        onScreen = true;
    }

    public void PopupOUT()
    {
        Debug.Log("Pop up goes out");
        anim.SetBool("Out", true);
        anim.SetBool("In", false);
        onScreen = false;
        OpenAudio();
        
    }

    public void OpenAudio()
    {
        if (source != null && source.clip != null) // checks if audio source was on game object and if it has an audio clip attached
        {
            source.Play();
        }
        else // debugging
        {
            Debug.LogWarning("No audio source on game object");
        }
    }
}