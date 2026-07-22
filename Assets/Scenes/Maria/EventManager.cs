using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    [SerializeField] string EndScene;
    public int EventCount;
    public List<GameObject> Events;
    [SerializeField] Button ContinueEvent;
    [SerializeField] Button NextEvent;

    void Start()
    {
        EventCount = 0;
        ContinueEvent.gameObject.SetActive(false);
        NextEvent.gameObject.SetActive(false);
    }
   
    public void Continue()
    {
        if (EventCount == 5)
        {
            EndGame();
        }
        if (EventCount != 5)//selects a random gameobject and activates it
       {
            ContinueEvent.gameObject.SetActive(true);
            NextEvent.gameObject.SetActive(false);
            Debug.Log("Event started");
            GameObject randomObject = GetRandomObject(Events);
            Debug.Log("Event Chosen: " + randomObject.name);
             GameObject GetRandomObject(List<GameObject> list)
            {
            int index = Random.Range(0, list.Count);
            return list[index];
             }
            randomObject.SetActive(true);
    }
        }
    public void EndGame()
    {
        SceneManager.LoadScene(EndScene);
    }
}
