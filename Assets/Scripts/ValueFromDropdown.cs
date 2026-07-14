using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class ValueFromDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;


    // This method retrieves the selected value from the dropdown and logs it to the console
    public void GetDropdownValue()
    {
        int pickedEntryIndex = dropdown.value;
        string selectedOption = dropdown.options[pickedEntryIndex].text;
        Debug.Log("Selected Class: " + selectedOption);
    }
}
