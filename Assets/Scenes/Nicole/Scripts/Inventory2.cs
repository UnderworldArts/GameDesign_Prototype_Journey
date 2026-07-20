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

    public List<string> inventoryContent = new List<string>();
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    string inventoryStrings = "";
    int inventorySpace = 20;

    public float Gold;
    string GoldText;
    [SerializeField] TextMeshProUGUI GoldTotal;
    [SerializeField] TextMeshProUGUI GoldTotalSHOP;

    [SerializeField] TMP_InputField inputfield;
    string userItemText;

    [SerializeField] Inventory inventory;


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

    public void ItemInInventory(string itemDescription, string itemName, int itemPrice, int noItem)
    {
        // Debug.Log("New item");

        for (int i = 0; i < inventorySpace; i++)
        {
            inventoryContent.Insert((i), itemName); // inserts item onto the list
                                                    //Debug.Log(inventoryStrings);

            //if (inventoryContent.Contains(inventoryContent[])
            //{
            //    inventoryContent[i].itemCount++;
            //}
            //else
            //{
            //    InventoryItem item = new InventoryItem();
            //    item.itemName = itemName;
            //    item.itemCount = 1;
            //    inventoryContent.Add(item);
            //    //Display text
            //}


            //i += 1; // marks the spot so the list is order of when the player adds items to the inventory

            if (inventoryStrings.Contains(itemName))
            {
               
                for (int j = 0; j < inventoryItems.Count; j++)
                {
                    if (inventoryItems[j] != null)
                    {
                        if (inventoryItems[j].itemName == itemName)
                        {
                            inventoryItems[j].itemCount++;
                        }
                    }
                }

                //inventoryItems[i].itemName = 


                inventoryContentText.text = inventoryContentString;

            }
            else
            {
                InventoryItem item = new InventoryItem();
                item.itemName = itemName;
                item.itemCount++;
                inventoryItems.Add(item);

                inventoryContentText.text = inventoryContentString;
            }

            inventoryStrings = "List contents: " + string.Join(", ", inventoryContent);
            Debug.Log(inventoryItems[i].itemName);
            Debug.Log(inventoryItems[i].itemCount);
            return;
        }

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

                //Debug.Log(inventory.);
            }
        }

        public void TypedTextRecievingCharacter()
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

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public int itemCount;
}