using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using Unity.VisualScripting;

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
    [SerializeField] Actions Actions;
    [SerializeField] public bool CanRest;
    [SerializeField] Button ContinueEvent;
    [SerializeField] Button NextEvent;
    public static bool CanCont;
    public static bool CanNext;
    private bool EventDone;


    private void Update()
    {
        if (CanCont)
        {
            Debug.Log("CanCont is cancont");
            CanCont = false;
            Event();

        }
        if (CanNext)

        {
            CanNext = false;
            EventFinish();
        }
    }

 
    void Start()
    {
    

        EventDone = false;
        textbox.TextClear();
        ForTextBox = EventStartText;
        textbox.ShowText(ForTextBox);
     
        Debug.Log("Void Start");
    } 
   

    public void Event() //If the event calls for a strength check for eg, only give the enemy a strength number >0. all others stay as 0 so the characters automatically win in that stat.
    {

        //CharacterStats.SetStats();
        Debug.Log("Event is working");
        if (Actions.Activecharacter.muscle < EnemyMuscle || Actions.Activecharacter.relfex < EnemyReflex || Actions.Activecharacter.smarts < EnemySmarts || Actions.Activecharacter.magics < EnemyMagics)
        {
            EventFail();
        }

        if (Actions.Activecharacter.muscle >= EnemyMuscle || Actions.Activecharacter.relfex >= EnemyReflex || Actions.Activecharacter.smarts >= EnemySmarts || Actions.Activecharacter.magics >= EnemyMagics)
        {
            EventSuccess();
        }



        Debug.Log("Event is working");
        if (Actions.Activecharacter.muscle < EnemyMuscle || Actions.Activecharacter.relfex < EnemyReflex || Actions.Activecharacter.smarts < EnemySmarts || Actions.Activecharacter.magics < EnemyMagics)
        {
         EventFail();
       }
            
        if (Actions.Activecharacter.muscle >= EnemyMuscle || Actions.Activecharacter.relfex >= EnemyReflex || Actions.Activecharacter.smarts >= EnemySmarts || Actions.Activecharacter.magics >= EnemyMagics)
        {
          EventSuccess();
        }
    } 

    void EventSuccess()
    {
        textbox.TextClear();
        ForTextBox = EventSuccessText;
        textbox.ShowText(ForTextBox);
        EventDone = true;
        CanRest = true;
        ContinueEvent.gameObject.SetActive(false);
        NextEvent.gameObject.SetActive(true);
        CanCont = false;
       
    }

    void EventFail()
    {
        textbox.TextClear();
        ForTextBox = EventFailText;
        textbox.ShowText(ForTextBox);
       // CharacterStats.currentHealth -= DamageTaken; //if damage is dealt. leave DamageTaken as 0 if situation doesnt call for it
        EventDone = true;
        CanRest = true;
        ContinueEvent.gameObject.SetActive(false);
        NextEvent.gameObject.SetActive(true);
       
        CanCont = false;
    }

 public void EventFinish()
    {
        textbox.TextClear();
        object value = EventManager.EventCount += 1;
            EventManager.Events.Remove(this.gameObject);
           
            EventManager.Continue();
          CanNext = false;
            Debug.Log("EventDone - " + gameObject.name);
            Destroy(this.gameObject);
    }


}
