using UnityEngine;

public class ReadyButton : MonoBehaviour
{

    [SerializeField] private CharacterStats character; // Reference to the CharacterStats script


    public void ReadyClicked()
    {
        Debug.Log("Ready button clicked!");

        // Call the GetReady() method in the CharacterStats script
        character.GetReady();

    }

}
