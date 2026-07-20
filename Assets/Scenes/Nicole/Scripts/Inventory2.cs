using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class Inventory2 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI inventoryContentText; // the text game object itself
    [SerializeField] TextMeshProUGUI inventoryContentTextSHOP; // the text game object itself
    string inventoryContentString;
    string inventoryContentString2;
    string inventoryContentString3;

    //public List<string> inventoryContent = new List<string>();
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
        for (int i = 0; i < inventorySpace; i++)
        {
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
            }
            else
            {
                Debug.Log("$ First {itemName} in list");
                InventoryItem item = new InventoryItem();
                item.itemName = itemName;
                item.itemCount++;
                inventoryItems.Add(item);
            }

         //entoryStrings = "List contents: " + string.Join(", ", inventoryContent);

            inventoryContentText.text = "";
            inventoryContentString = "";

            

            inventoryContentText.text = inventoryContentString;
            inventoryStrings += inventoryItems[i].itemCount + " " + inventoryItems[i].itemName + " ";


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