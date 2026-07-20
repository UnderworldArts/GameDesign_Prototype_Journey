using UnityEngine;
using UnityEngine.UI;

public class ReadyButton : MonoBehaviour
{
    [SerializeField] private Button readyButton;
    [SerializeField] EventScript eventScript;
    [SerializeField] EventManager eventManager;
    [SerializeField] private CharacterStats character1; // Reference to the Character 1's script
    [SerializeField] private CharacterStats character2; // Reference to the Character 2's script
    [SerializeField] private CharacterStats character3; // Reference to the Character 3's script


    public void ReadyClicked()
    {
        Debug.Log("Ready button clicked!");

        // Call the GetReady() method in the CharacterStats script
        character1.GetReady();
        character2.GetReady();
        character3.GetReady();
        eventManager.Continue();
    }

}
