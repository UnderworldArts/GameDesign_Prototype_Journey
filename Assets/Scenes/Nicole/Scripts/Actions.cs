using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Actions : MonoBehaviour
{
    [SerializeField] Menus menus; // for pop up OUT
    [SerializeField] ReadyButton readybutton;

    [SerializeField] TextBox textbox; // references the text box script through the editor so your string variable can be brought over into the function
    string ForTextBox; // leave this blank

    //bool CanRest = true;
    //bool CanAbility = true;

    [SerializeField] TMP_Dropdown CharacterSelect;
    public List<CharacterStats> partyStats = new List<CharacterStats>();
    public CharacterStats Activecharacter;

    [SerializeField] Inventory2 inventory;
    [SerializeField] static EventScript EventScript;

    public void AddOptions()
    {
        for(int i = 0; i < partyStats.Count; i++)
        {
            int index = i;
            index += 1;
            CharacterSelect.options.Add(new TMP_Dropdown.OptionData() { text = " " + index + ": " + partyStats[i].characterClass });

            partyStats[i].IndexList = index;
        }

        //CharacterSelect.value = 0;
       // inventory.UseOnOptions(partyStats);
      //  inventory.SetPartyNames(partyStats);
    }

    public void RemoveDeadCharacter(Character chosenCharacter, int IndexList)
    {
        CharacterSelect.options.RemoveAt(IndexList);
        //partyStats.Remove(chosenCharacter.character); // remove dead character from list
        Destroy(chosenCharacter);
    }

    public void SelectCharacter()
    {
        int SelectioninIndex = CharacterSelect.value;
        Activecharacter = partyStats[SelectioninIndex];
        //Debug.Log(Activecharacter);
        // changes which character the player is currently controlling
    }

    public void Rest()
    {
        if (!textbox.Pause)
        {
            //Debug.Log("Rest");
            // logic for resting, cannot rest when there are enemies, resting allows character to use ability
            if (EventScript.CanRest)
            {
                ForTextBox = Activecharacter.IndexList + ": " + Activecharacter.characterClass + " rests. You can now use " + Activecharacter.IndexList + ": " + Activecharacter.characterClass + "'s ability again.";
                textbox.ShowText(ForTextBox);
                textbox.Pause = true;
                textbox.PauseHint();

                Activecharacter.CanAbility = true;
            }
            else
            {
                ForTextBox = Activecharacter.IndexList + ": " + Activecharacter.characterClass + " is not safe to rest.";
                textbox.ShowText(ForTextBox);

                textbox.Pause = true;
                textbox.PauseHint();
            }
        }
    }

    public void Ability()
    {
        //Debug.Log("Ability");

        // may be too complex? Can cut
        if (!textbox.Pause)

            if (Activecharacter.CanAbility)
            {
                Activecharacter.CanAbility = false;

                // logic for ability, one use, rouge stabs or robs, warrior hits, mage heals, average joe ??
                // Average Joe, Mage, Priest, Rogue, Tank, Warrior
                //Debug.Log(Activecharacter.characterClass);

                if (Activecharacter.characterClass.Contains("Warrior"))
                {
                    ForTextBox = Activecharacter.IndexList + ": " + Activecharacter.characterClass + " trains with the party, increasing everyone's muscles by 1! " + + Activecharacter.IndexList + ": " + Activecharacter.characterClass + " will need to recharage to train again.";;
                    textbox.ShowText(ForTextBox);

                    for(int i = 0; i < partyStats.Count; i++)
                    {
                        if (partyStats[i].muscle < 10)
                        {
                            int muscleNEW = partyStats[i].muscle;
                            muscleNEW += 1;
                            partyStats[i].muscle = muscleNEW;
                            Debug.Log(partyStats[i].ToString() + partyStats[i].muscle.ToString());
                        }
                    }
                }

                if (Activecharacter.characterClass.Contains("Tank"))
                {
                    ForTextBox = Activecharacter.IndexList + ": " + Activecharacter.characterClass + " says something so incredibly dumb that it increases everyone else's smarts by 1! " + Activecharacter.IndexList + ": " + Activecharacter.characterClass + " will need to recharage to be especially stupid again.";;
                    textbox.ShowText(ForTextBox);

                    for(int i = 0; i < partyStats.Count; i++)
                    {
                        if (partyStats[i].smarts < 10)
                        {
                            //partyStats[i].smarts =+ 1;
                            int smartsNEW = partyStats[i].smarts;
                            smartsNEW += 1;
                            partyStats[i].smarts = smartsNEW;
                            Debug.Log(partyStats[i].ToString() + partyStats[i].smarts.ToString());
                        }
                    }

                    int smartsTANK = Activecharacter.smarts;
                    smartsTANK -= 1;
                    Activecharacter.smarts = smartsTANK;
                    Debug.Log(Activecharacter.ToString() + Activecharacter.smarts.ToString());

                }

                if (Activecharacter.characterClass.Contains("Rogue"))
                {
                    ForTextBox = Activecharacter.IndexList + ": " + Activecharacter.characterClass + " teaches the party a cool trick, increasing everyone's reflexes by 1! " + + Activecharacter.IndexList + ": " + Activecharacter.characterClass + " will need to recharage to do a trick again.";;
                    textbox.ShowText(ForTextBox);

                    for(int i = 0; i < partyStats.Count; i++)
                    {
                        if (partyStats[i].relfex < 10)
                        {
                            //partyStats[i].relfex =+ 1;
                            int relfexNEW = partyStats[i].relfex;
                            relfexNEW += 1;
                            partyStats[i].relfex = relfexNEW;
                            Debug.Log(partyStats[i].ToString() + partyStats[i].relfex.ToString());
                        }
                    }
                }

                if (Activecharacter.characterClass.Contains("Priest"))
                {
                    ForTextBox = Activecharacter.IndexList + ": " + Activecharacter.characterClass + " blesses the party, increasing everyone's magic by 1! " + + Activecharacter.IndexList + ": " + Activecharacter.characterClass + " will need to recharage to bless again.";
                    textbox.ShowText(ForTextBox);

                    for(int i = 0; i < partyStats.Count; i++)
                    {
                        if (partyStats[i].magics < 10)
                        {
                            //partyStats[i].magics =+ 1;

                            int magicsNEW = partyStats[i].magics;
                            magicsNEW += 1;
                            partyStats[i].magics = magicsNEW;
                            Debug.Log(partyStats[i].ToString() + partyStats[i].magics.ToString());
                        }
                    }
                }

                if (Activecharacter.characterClass.Contains("Mage"))
                {
                    ForTextBox = Activecharacter.IndexList + ": " + Activecharacter.characterClass + " heals all members of the party to max health! " + Activecharacter.IndexList + ": " + Activecharacter.characterClass + " will need to recharge to heal again.";
                    textbox.ShowText(ForTextBox);

                    for(int i = 0; i < partyStats.Count; i++)
                    {
                        if (partyStats[i].currentHealth < partyStats[i].maxHealth)
                        {
                            partyStats[i].currentHealth = partyStats[i].maxHealth;
                        }
                    }
                }

                if (Activecharacter.characterClass.Contains("Average Joe"))
                {
                    ForTextBox = Activecharacter.IndexList + ": " + Activecharacter.characterClass + " is just happy to be here. The rest of the party is inspired by their bravery in spite of this, and all suddenly feel well rested! " + Activecharacter.IndexList + ": " + Activecharacter.characterClass + " will need to recharge to encourage the party again.";
                    textbox.ShowText(ForTextBox);

                    for(int i = 0; i < partyStats.Count; i++)
                    {
                        partyStats[i].CanAbility = true;
                    }
                }
            }
            else
            {
                ForTextBox = "You cannot use " + Activecharacter.IndexList + ": " + Activecharacter.characterClass + "'s ability until " + Activecharacter.IndexList + ": " + Activecharacter.characterClass + " rests.";
                textbox.ShowText(ForTextBox);
            }

            textbox.Pause = true;
            textbox.PauseHint();
    }

    public void Finish()
    {
        Debug.Log("Finish");
        // player finishes turn
        menus.PopupOUT();

        // trigger stuff from menu script
    }
}
