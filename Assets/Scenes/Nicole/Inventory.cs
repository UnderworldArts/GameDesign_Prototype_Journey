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

    [SerializeField] string itemDescription; // this is the variable you will use
    [SerializeField] string itemName;
    [SerializeField] int itemPrice;
    int noItem = 0;

    bool Pause = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        // Debug.Log("In");

        if (Pause == false)
        {
            ForTextBox = itemDescription;
            textbox.ShowText(ForTextBox);
        }
    }

    void OnMouseExit()
    {
        // Debug.Log("Out");

        if (Pause == false)
        {
            textbox.TextClear();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        // Debug.Log("Click");

        if (Pause == false)
        {
            // check if can afford item
            ForTextBox = "You bought item for price!";
            textbox.ShowText(ForTextBox);
            //Pause = true;
            noItem += 1;
            inventory.ItemInInventory(itemDescription, itemName, itemPrice, noItem);
        }
    }
}
