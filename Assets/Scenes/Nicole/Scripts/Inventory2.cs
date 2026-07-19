using TMPro;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory2 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI inventoryContentText; // the text game object itself
    [SerializeField] TextMeshProUGUI inventoryContentTextSHOP; // the text game object itself
    string inventoryContentString;
    string inventoryContentString2;

    List<string> inventoryContent = new List<string>();
    string inventoryStrings = "";
    int inventorySpace = 20;

    public float Gold;
    string GoldText;
    [SerializeField] TextMeshProUGUI GoldTotal;
    [SerializeField] TextMeshProUGUI GoldTotalSHOP;

    [SerializeField] TMP_InputField inputfield;
    string userItemText;


    void Start()
    {
        UpdateGoldCount();
    }

    public void UpdateGoldCount()
    {
        GoldText = Gold.ToString() + " gold";
        GoldTotal.text = GoldText;
    }

    void Update()
    {
        inventoryContentTextSHOP.text = inventoryContentText.text;
        GoldTotalSHOP.text = GoldTotal.text;
    }

    public bool ItemInInventory(string itemDescription, string itemName, int itemPrice, int noItem)
    {
        // Debug.Log("New item");

        for (int i = 0; i < inventorySpace; i++)
        {
            inventoryContent.Insert((i), itemName); // inserts item onto the list
            //Debug.Log(inventoryStrings);

            i += 1; // marks the spot so the list is order of when the player adds items to the inventory

            if (inventoryStrings.Contains(itemName))
            {
                //Debug.Log($"The word '{itemName}' exists in the sentence.");
                string inventoryContentString3 = "\n" + noItem + " " + itemName;
                string itemNameBackup2 = itemName;

                //Debug.Log(itemNameBackup);

                //inventoryContentString2 = inventoryContentString2.Replace(itemNameBackup, itemNameBackup2);
                inventoryContentString = inventoryContentString.Replace(inventoryContentString2, inventoryContentString3);

                //Debug.Log(inventoryContentString2);
                //inventoryContentString += inventoryContentString2; - Commented out due to warning
                inventoryContentString2 = "\n" + noItem + " " + itemName;

                inventoryContentText.text = inventoryContentString;
            }
            else
            {
                //Debug.Log($"The word '{itemName}' does not exist in the sentence.");
                inventoryContentString += "\n" + noItem + " " + itemName;
                inventoryContentString2 = "\n" + noItem + " " + itemName;

                //itemNameBackup = itemName; - Commented out due to warning 
                //Debug.Log("itemNameBackup");

                inventoryContentText.text = inventoryContentString;
            }

            inventoryStrings = "List contents: " + string.Join(", ", inventoryContent);

            return true;
        }
        return true;
        //Destroy(gameObject);
    }

        public void UseItem()
        {
            Debug.Log("Use item");
        }

        public void TypedTextItem()
        {
            //Debug.Log("Wrote text");
            userItemText = inputfield.text;
            Debug.Log(userItemText);
            Debug.Log(inventoryStrings);

            if (inventoryStrings.Contains(userItemText))
            {
                Debug.Log("matched to item in inventory");

                // addtional use item logic
                inventoryStrings = inventoryStrings.Replace(userItemText, "");
                // remove one entry from the list
            }
        }
}
