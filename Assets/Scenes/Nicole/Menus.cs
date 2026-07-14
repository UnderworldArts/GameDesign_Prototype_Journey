using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField] string nextScene; // assign script to a menu manager game object in scene, writing the scene name EXCATLY that you want the button to trigger

    [SerializeField] TextBox textbox; // references the text box script through the editor so your string variable can be brought over into the function
    string ForTextBox; // leave this blank to make it less confusing
    [SerializeField] string StringName; // this is the variable you will use

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

    // textbox testing

    public void TextTest()
    {
        Debug.Log("Button pressed");

        ForTextBox = StringName;
        textbox.ShowText(ForTextBox);
    }
}