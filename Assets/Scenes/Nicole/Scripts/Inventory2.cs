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

    public List<string> inventoryContent = new List<string>();
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    string inventoryStrings = "";
    int NextIndexinventoryItems = 0;

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

    [SerializeField] Actions actions;
    [SerializeField] TextMeshProUGUI PartyNames;
    [SerializeField] TMP_Dropdown UseOn;
    CharacterStats UseOnCharacter;
    Inventory ToUseItem;
    bool useCharacter = false;
    bool useItem = false;

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


    public void ItemInInventory(string itemDescription, string itemName, int itemPrice, int noItem, Inventory itemItself)
    {
        for (int i = 0; i < inventorySpace; i++)
        {
            if (inventoryStrings.Contains(itemName))
            {
                for (int j = 0; j < inventoryItems.Count; j++)
                {
                    if (inventoryItems[j] != null)
                    {
                        if (inventoryItems[j].NameItem == itemName)
                        {
                            string temporaryOLDCountItem = inventoryItems[j].CountItem + " " + inventoryItems[j].NameItem;

                            inventoryItems[j].CountItem++;

                            string temporaryNEWCountItem = inventoryItems[j].CountItem + " " + inventoryItems[j].NameItem;
                            
                            inventoryStrings = inventoryStrings.Replace(temporaryOLDCountItem, temporaryNEWCountItem);
                        }
                    }
                }
            }
            else
            {
                Debug.Log("$ First {itemName} in list");
                InventoryItem item = new InventoryItem();
                item.NameItem = itemName;
                item.CountItem = noItem;
                item.itemItself = itemItself;
                inventoryItems.Add(item);

                inventoryContent.Add(inventoryItems[NextIndexinventoryItems].CountItem + " " + inventoryItems[NextIndexinventoryItems].NameItem);
                string AddtoInventoryStrings = inventoryItems[NextIndexinventoryItems].CountItem + " " + inventoryItems[NextIndexinventoryItems].NameItem;
                inventoryStrings += "\n" + AddtoInventoryStrings;

                NextIndexinventoryItems += 1;
            }

            inventoryContentText.text = inventoryStrings;

            inventorySpace -= 1;
            UpdateInventoryCount();

            return;
        }

    }

    public void TypedTextItem()
    {
        userItemText = inputfield.text;

        if (inventoryStrings.Contains(userItemText))
        {
            Debug.Log("matched to item in inventory");

            foreach (InventoryItem item in inventoryItems)
            {
                for (int i = 0; i < inventoryItems.Count; i++)
                {
                    if (inventoryItems[i].itemItself.itemName == userItemText)
                    {
                        Debug.Log(inventoryItems[i].itemItself.itemName + " matches " + userItemText);
                        ToUseItem = inventoryItems[i].itemItself;
                    }
                }
            }

            useItem = true;
            CheckForUseItem();
        }
        else
        {
            ForTextBox = userItemText + " does not exist in your inventory. Check your spelling and capitalization matches exactly, then press enter.";
            textbox.ShowText(ForTextBox);
        }
    }

    public void RecievingCharacter()
    {
        int SelectioninIndex = UseOn.value;
        UseOnCharacter = actions.partyStats[SelectioninIndex];
        Debug.Log(UseOnCharacter);

        useCharacter = true;
        CheckForUseItem();
    }

    public void CheckForUseItem()
    {
        Debug.Log("Check for use item");
        // remove one entry from the list
        if (useItem)
        {
            if (useCharacter)
            {
                if (UseOnCharacter.muscle < 10)
                {
                    int muscleNEW = UseOnCharacter.muscle;
                    muscleNEW =+ ToUseItem.muscleChange;
                    UseOnCharacter.muscle = muscleNEW;
                    Debug.Log(UseOnCharacter.muscle);
                }
                UseOnCharacter.muscle += ToUseItem.muscleChange;
                UseOnCharacter.relfex += ToUseItem.reflexChange;
                UseOnCharacter.smarts += ToUseItem.smartsChange;
                UseOnCharacter.magics += ToUseItem.magicsChange;

                //UseOnCharacter.maxhealth += ;
                //UseOnCharacter.currentHealth = .HPChange;

                ForTextBox = actions.Activecharacter + " uses " + userItemText + " on " + UseOnCharacter + "!";
                textbox.ShowText(ForTextBox);
            }
        }
        else
        {
            ForTextBox = "Check you have filled out both the input and the dropdown, and you pressed enter on the input!";
            textbox.ShowText(ForTextBox);
        }
    }
}


[System.Serializable]
public class InventoryItem
{
    public string NameItem;
    public int CountItem;
    public Inventory itemItself;
}