using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContButton()
    {
        EventScript.CanCont = true;
    }

    public void NextButton()
    {
        EventScript.CanNext = true;
    }

    public void EnterBG()
    {
        gameObject.SetActive(true); 
    }
}
