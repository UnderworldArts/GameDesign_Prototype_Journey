using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    [SerializeField] string EndScene;
    int EventCount;
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
            GameObject randomObject = GetRandomObject(Events);
            Debug.Log("Event Chosen: " + randomObject.name);
            randomObject.SetActive(true);
            GameObject GetRandomObject(List<GameObject> list)
            {
                int index = Random.Range(0, list.Count);
                return list[index];
            }
        }
    }
    public void EndGame()
    {
        SceneManager.LoadScene(EndScene);
    }
}
