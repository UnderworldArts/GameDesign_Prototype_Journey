using UnityEngine;

public class Actions : MonoBehaviour
{
    [SerializeField] Menus menus; // for pop up OUT

    [SerializeField] TextBox textbox; // references the text box script through the editor so your string variable can be brought over into the function
    string ForTextBox; // leave this blank

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectCharacter()
    {
        Debug.Log("Select character");
        // changes which character the player is currently controlling
    }

    public void Rest()
    {
        Debug.Log("Rest");
        // logic for resting, cannot rest when there are enemies, resting allows character to use ability
        ForTextBox = "You rest.";
        textbox.ShowText(ForTextBox);
    }

    public void Ability()
    {
        Debug.Log("Ability");
        // logic for ability, one use, rouge stabs or robs, warrior hits, mage heals, average joe ??

        // may be too complex? Can cut
    }

    public void Finish()
    {
        Debug.Log("Finish");
        // player finishes turn
        menus.PopupOUT();
    }
}
