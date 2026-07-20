using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    [SerializeField] string EndScene;
    public int EventCount;
    public List<GameObject> Events;
   

    void Start()
    {
        EventCount = 0;
    }
    void Update()
    {
       
    }

    public void Continue()
    {
        if (EventCount == 5)
        {
            EndGame();
        }
        if (EventCount != 5)//selects a random gameobject and activates it
       {
         
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
