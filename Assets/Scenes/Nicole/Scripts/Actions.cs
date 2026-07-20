using UnityEngine;

public class Actions : MonoBehaviour
{
    [SerializeField] Menus menus; // for pop up OUT

    [SerializeField] TextBox textbox; // references the text box script through the editor so your string variable can be brought over into the function
    string ForTextBox; // leave this blank

    bool CanRest = true;
    bool CanAbility = true;

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
        if (CanRest)
        {
            ForTextBox = "You rest.";
            textbox.ShowText(ForTextBox);
            CanAbility = true;
        }
        else
        {
            ForTextBox = "You cannot rest.";
            textbox.ShowText(ForTextBox);
        }
    }

    public void Ability()
    {
        Debug.Log("Ability");

        // may be too complex? Can cut

        if (CanAbility)
        {
            ForTextBox = "You use your ability.";
            textbox.ShowText(ForTextBox);
            CanAbility = false;
            // logic for ability, one use, rouge stabs or robs, warrior hits, mage heals, average joe ??
        }
        else
        {
            ForTextBox = "You cannot use your ability.";
            textbox.ShowText(ForTextBox);
            CanAbility = false;
        }
    }

    public void Finish()
    {
        Debug.Log("Finish");
        // player finishes turn
        menus.PopupOUT();
    }
}
