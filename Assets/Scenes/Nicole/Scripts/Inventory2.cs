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

    public int inventorySpace = 20;
    string SpaceText;
    [SerializeField] TextMeshProUGUI inventorySpaceText;
    [SerializeField] TextMeshProUGUI inventorySpaceTextSHOP;

    public float Gold;
    string GoldText;
    [SerializeField] TextMeshProUGUI GoldTotal;
    [SerializeField] TextMeshProUGUI GoldTotalSHOP;

    [SerializeField] TMP_InputField inputfield;
    string userItemText;

    [SerializeField] Inventory inventory;

    [SerializeField] Actions actions;
    [SerializeField] TextMeshProUGUI PartyNames;
    [SerializeField] TMP_Dropdown UseOn;
    CharacterStats UseOnCharacter;

    [SerializeField] TextBox textbox; // references the text box script through the editor so your string variable can be brought over into the function
    string ForTextBox; // leave this blank

    void Start()
    {
        UpdateGoldCount();
        UpdateInventoryCount();
    }

    public void UpdateGoldCount()
    {
        GoldText = Gold.ToString() + " gold";
        GoldTotal.text = GoldText;
        GoldTotalSHOP.text = GoldTotal.text;
    }

    public void UpdateInventoryCount()
    {
        SpaceText = inventorySpace.ToString() + "/20";
        inventorySpaceText.text = SpaceText;
        inventorySpaceTextSHOP.text = SpaceText;
    }

    void Update()
    {
        inventoryContentTextSHOP.text = inventoryContentText.text;
    }

    public void UseOnOptions(List<CharacterStats> partyStats)
    {
        for(int i = 0; i < partyStats.Count; i++)
        {
            int index = i;
            index += 1;
            UseOn.options.Add(new TMP_Dropdown.OptionData() { text = " " + index + ": " + partyStats[i].characterClass });

            partyStats[i].IndexList = index;
        }
    }

    public void SetPartyNames(List<CharacterStats> partyStats)
    {
        for(int i = 0; i < partyStats.Count; i++)
        { 
            int index = i;
            index += 1;
            PartyNames.text += "\n" + index + ": " + partyStats[i].characterClass;

            partyStats[i].IndexList = index;
        }
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
            inventorySpace -= 1;
            UpdateInventoryCount();

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
        //Debug.Log(userItemText);
        //Debug.Log(inventoryStrings);

        if (inventoryStrings.Contains(userItemText))
        {
            Debug.Log("matched to item in inventory");

            // remove one entry from the list
        }
        else
        {
            //ForTextBox
        }
    }

    public void RecievingCharacter()
    {
        int SelectioninIndex = UseOn.value;
        UseOnCharacter = actions.partyStats[SelectioninIndex];
        Debug.Log(UseOnCharacter);
    }
}

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public int itemCount;
}