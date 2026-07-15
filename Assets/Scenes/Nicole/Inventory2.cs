using TMPro;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory2 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI inventoryContentText; // the text game object itself
    string inventoryContentString;
    string inventoryContentString2;

    List<string> inventoryContent = new List<string>();
    int inventorySpace = 20;

    public bool ItemInInventory(string itemDescription, string itemName, int itemPrice, int noItem)
    {
        // Debug.Log("New item");

        for (int i = 0; i < inventorySpace; i++)
        {
            string inventoryStrings = "List contents: " + string.Join(", ", inventoryContent);
            //Debug.Log(inventoryStrings);
            inventoryContent.Insert((i), itemName); // inserts item onto the list

            i += 1; // marks the spot so the list is order of when the player adds items to the inventory

            if (inventoryStrings.Contains(itemName))
            {
                //Debug.Log($"The word '{itemName}' exists in the sentence.");
                string inventoryContentString3 = "\n" + noItem + " " + itemName;
                string itemNameBackup2 = itemName;

                //Debug.Log(itemNameBackup);

                inventoryContentString2 = inventoryContentString2.Replace(itemNameBackup, itemNameBackup2);
                inventoryContentString = inventoryContentString.Replace(inventoryContentString2, inventoryContentString3);

                Debug.Log(inventoryContentString2);
                //inventoryContentString += inventoryContentString2;
                inventoryContentString2 = "\n" + noItem + " " + itemName;

                inventoryContentText.text = inventoryContentString;
            }
            else
            {
                //Debug.Log($"The word '{itemName}' does not exist in the sentence.");
                inventoryContentString += "\n" + noItem + " " + itemName;
                inventoryContentString2 = "\n" + noItem + " " + itemName;
                itemNameBackup = itemName;
                Debug.Log(itemNameBackup);

                inventoryContentText.text = inventoryContentString;
            }

            return true;
        }
        return true;
        //Destroy(gameObject);
    }
}
