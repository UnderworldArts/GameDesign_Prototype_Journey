using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class EventScript : MonoBehaviour
{
    //Script to attach to Event GameObjects
    [SerializeField] int EnemyMuscle;
    [SerializeField] int EnemyReflex;
    [SerializeField] int EnemySmarts;
    [SerializeField] int EnemyMagics;
    [SerializeField] int DamageTaken;
    [SerializeField] CharacterStats CharacterStats;
    [SerializeField] EventManager EventManager;
    [SerializeField] TextBox textbox; // references the text box script through the editor so your string variable can be brought over into the function
    string ForTextBox; // leave this blank
    [SerializeField] string EventStartText; // this is the variable you will use
    [SerializeField] string EventSuccessText;
    [SerializeField] string EventFailText;

    void Start()
    {
        ForTextBox = EventStartText;
        if (Input.GetKey(KeyCode.Space))
        {
            Event();
        }
    }
    void Event() //If the event calls for a strength check for eg, only give the enemy a strength number >0. all others stay as 0 so the characters automatically win in that stat.
    {
        if (CharacterStats.muscle < EnemyMuscle && CharacterStats.relfex < EnemyReflex && CharacterStats.smarts < EnemySmarts && CharacterStats.magics < EnemyMagics)
        {
            EventSuccess();
        }
        if (CharacterStats.muscle > EnemyMuscle && CharacterStats.relfex > EnemyReflex && CharacterStats.smarts > EnemySmarts && CharacterStats.magics > EnemyMagics)
        {
            EventFail();
        }
    }

    void EventSuccess()
    {
        //textbox.TextClear();
        ForTextBox = EventSuccessText;
        textbox.ShowText(ForTextBox);
        if (Input.GetKey(KeyCode.Space))
        {
            EventManager.Continue();
            Destroy(gameObject);//so the same event doesnt get chosen again
            
        }

    }

    void EventFail()
    {
        //textbox.TextClear();
        ForTextBox = EventFailText;
        textbox.ShowText(ForTextBox);
        CharacterStats.currentHealth -= DamageTaken; //if damage is dealt. leave DamageTaken as 0 if situation doesnt call for it
        if (Input.GetKey(KeyCode.Space))
        {
            EventManager.Continue();
            Destroy(gameObject);
        }
    }




}
