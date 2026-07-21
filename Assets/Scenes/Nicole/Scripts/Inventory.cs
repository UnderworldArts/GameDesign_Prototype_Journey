using TMPro;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TextBox textbox; // references the text box script through the editor so your string variable can be brought over into the function
    string ForTextBox; // leave this blank

    [SerializeField] Inventory2 inventory;
    public string InventoryEntryString;

    [SerializeField] string itemDescription; // this is the variable you will use
    [SerializeField] string itemName;
    [SerializeField] int itemPrice;
    int noItem = 0;

    [SerializeField] int HPChange;
    [SerializeField] int muscleChange;
    [SerializeField] int reflexChange;
    [SerializeField] int smartsChange;
    [SerializeField] int magicsChange;

    AudioSource source; // nickname for the text sound effect


    void Start()
    {
        source = GetComponent<AudioSource>(); // assigns as the audiosource from the game object the script is on
    }

    void OnMouseEnter()
    {
        // Debug.Log("In");

        if (textbox.Pause == false)
        {
            ForTextBox = itemDescription;
            textbox.ShowText(ForTextBox);
        }
    }

    void OnMouseExit()
    {
        // Debug.Log("Out");

        if (textbox.Pause == false)
        {
            textbox.TextClear();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // maybe pop up button for confirmation?
        // Debug.Log("Click");

        if (textbox.Pause == false)
        {
            if (inventory.Gold >= itemPrice)
            {
                // check if can afford item
                ForTextBox = "You bought " + itemName + " for " + itemPrice + " gold!";
                inventory.Gold -= itemPrice;

                //Debug.Log(inventory.Gold);
                inventory.UpdateGoldCount();

                textbox.ShowText(ForTextBox);
                textbox.Pause = true;
                textbox.PauseHint();
                
                NewItem();
            }
            else
            {
                Debug.Log("HA POOR");
                ForTextBox = "Sorry, you cannot afford that item.";
                textbox.ShowText(ForTextBox);
            }
        }
    }

    public void NewItem()
    {
        noItem += 1;
        GotItemAudio();

        inventory.ItemInInventory(itemDescription, itemName, itemPrice, noItem);
    }

    public void GotItemAudio()
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
