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

    public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    string inventoryStrings = "";
    int NextIndexinventoryItems = 0;
    List<InventoryItem> removinginventoryItem;

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
    string ToUseItemNameItem;
    int ToUseItemCountItem;
    int ToUseItemListEntry;
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

    public void StopPause()
    {
        textbox.Pause = false;
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
            partyStats[i].IndexList = index;
            index += 1;
            PartyNames.text += "\n" + index + ": " + partyStats[i].characterClass;
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

                //inventoryContent.Add(inventoryItems[NextIndexinventoryItems].CountItem + " " + inventoryItems[NextIndexinventoryItems].NameItem);
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

                        ToUseItemNameItem = inventoryItems[i].NameItem;
                        ToUseItemCountItem = inventoryItems[i].CountItem;
                        ToUseItemListEntry = i;
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
        //Debug.Log(UseOnCharacter);

        useCharacter = true;
        CheckForUseItem();
    }

    public void CheckForUseItem()
    {
        //Debug.Log("Check for use item");
        // remove one entry from the list
        if (useItem)
        {
            if (useCharacter)
            {
                ForTextBox = actions.Activecharacter.IndexList + ": " + actions.Activecharacter.characterClass + " uses " + userItemText + " on " + + UseOnCharacter.IndexList + ": " + UseOnCharacter.characterClass + "!";
                bool Statshavechanged = false;

                if (ToUseItem.muscleChange > 0)
                {
                    if (UseOnCharacter.muscle < 10)
                    {
                        Debug.Log(UseOnCharacter.muscle);

                        UseOnCharacter.muscle += ToUseItem.muscleChange;
                        if (UseOnCharacter.muscle > 10)
                        {
                            UseOnCharacter.muscle = 10;
                        }

                        Debug.Log(UseOnCharacter.muscle);
                        ForTextBox += " " + UseOnCharacter.IndexList + ": " + UseOnCharacter.characterClass + "'s muscle has increased to " + UseOnCharacter.muscle + "!";

                        Statshavechanged = true;
                    }
                }
                if (ToUseItem.reflexChange > 0)
                {
                    if (UseOnCharacter.relfex < 10)
                    {
                        Debug.Log(UseOnCharacter.relfex);

                        UseOnCharacter.relfex += ToUseItem.reflexChange;
                        if (UseOnCharacter.relfex > 10)
                        {
                            UseOnCharacter.relfex = 10;
                        }

                        Debug.Log(UseOnCharacter.relfex);
                        ForTextBox += " " + UseOnCharacter.IndexList + ": " + UseOnCharacter.characterClass + "'s reflexes have increased to " + UseOnCharacter.relfex + "!";

                        Statshavechanged = true;
                    }
                }
                if (ToUseItem.smartsChange > 0)
                {
                    if (UseOnCharacter.smarts < 10)
                    {
                        Debug.Log(UseOnCharacter.smarts);

                        UseOnCharacter.smarts += ToUseItem.smartsChange;
                        if (UseOnCharacter.smarts > 10)
                        {
                            UseOnCharacter.smarts = 10;
                        }

                        Debug.Log(UseOnCharacter.smarts);
                        ForTextBox += " " + UseOnCharacter.IndexList + ": " + UseOnCharacter.characterClass + "'s smarts have increased to " + UseOnCharacter.smarts + "!";

                        Statshavechanged = true;
                    }
                }
                if (ToUseItem.magicsChange > 0)
                {
                    if (UseOnCharacter.magics < 10)
                    {
                        Debug.Log(UseOnCharacter.magics);

                        UseOnCharacter.magics += ToUseItem.magicsChange;
                        if (UseOnCharacter.magics > 10)
                        {
                            UseOnCharacter.magics = 10;
                        }

                        Debug.Log(UseOnCharacter.magics);
                        ForTextBox += " " + UseOnCharacter.IndexList + ": " + UseOnCharacter.characterClass + "'s magics have increased to " + UseOnCharacter.magics + "!";

                        Statshavechanged = true;
                    }
                }
                if (ToUseItem.HPChange > 0)
                {
                    if (UseOnCharacter.currentHealth != UseOnCharacter.maxHealth)
                    {
                        Debug.Log(UseOnCharacter.currentHealth);

                        UseOnCharacter.currentHealth += ToUseItem.HPChange;
                        if (UseOnCharacter.currentHealth > UseOnCharacter.maxHealth)
                        {
                            UseOnCharacter.currentHealth = UseOnCharacter.maxHealth;
                        }

                        Debug.Log(UseOnCharacter.currentHealth);
                        ForTextBox += " " + UseOnCharacter.IndexList + ": " + UseOnCharacter.characterClass + "'s HP has increased to " + UseOnCharacter.currentHealth + "/" + "UseOnCharacter.maxHealth" + "!";

                        Statshavechanged = true;
                    }
                }
                if (ToUseItem.maxHealthChange > 0)
                {
                    Debug.Log(UseOnCharacter.maxHealth);

                    UseOnCharacter.maxHealth += ToUseItem.maxHealthChange;
                    UseOnCharacter.currentHealth += ToUseItem.maxHealthChange;

                    Debug.Log(UseOnCharacter.maxHealth);
                    ForTextBox += " " + UseOnCharacter.IndexList + ": " + UseOnCharacter.characterClass + "'s max health has increased to " + UseOnCharacter.maxHealth + "!";

                    Statshavechanged = true;
                }

                if (!Statshavechanged)
                {
                    ForTextBox += " But none of " + UseOnCharacter.IndexList + ": " + UseOnCharacter.characterClass + "'s stats have increased :(";
                }

                string temporaryOLDCountItem = ToUseItemCountItem + " " + ToUseItemNameItem;
                ToUseItemCountItem -= 1;

                foreach (InventoryItem item in inventoryItems)
                {
                    for (int i = 0; i < inventoryItems.Count; i++)
                    {
                        if (i == ToUseItemListEntry)
                        {
                            inventoryItems[i].CountItem -= 1;
                            if (inventoryItems[i].CountItem == 0)
                            {
                                //inventoryItems.Remove(inventoryItems[i]);
                                removinginventoryItem.Add(inventoryItems[i]);

                                string temporaryNEWCountItem = "";
                                inventoryStrings = inventoryStrings.Replace(temporaryOLDCountItem, temporaryNEWCountItem);
                                inventoryContentText.text = inventoryStrings;
                            }
                            else
                            {
                                string temporaryNEWCountItem = ToUseItemCountItem + " " + ToUseItemNameItem;        
                                inventoryStrings = inventoryStrings.Replace(temporaryOLDCountItem, temporaryNEWCountItem);
                                inventoryContentText.text = inventoryStrings;
                            }
                        }
                    }
                }

                inventoryItems.Remove(removinginventoryItem[0]);

                inventorySpace += 1;
                inputfield.text = "";
                UseOn.value = 0;

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