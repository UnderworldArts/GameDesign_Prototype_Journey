using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterStats : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    //Set character's max health and current health
    [Header("Health Stats")]
    public int maxHealth = 10;
    public int currentHealth;

    //Health UI
    [Header("Health UI")]
    [SerializeField] TextMeshProUGUI CharacterHealthText;
    [SerializeField] GameObject menuUI;
    // Reference to the Healthbar script to update the UI
    public Healthbar healthbar;


    //Visualises the character taking damage
    [SerializeField] private float hurtDuration;
    [SerializeField] private int numberOfFlashes;


    //Set character's class and stats
    [Header("Character Stats")]
    public string characterClass;
    public int muscle;
    public int relfex;
    public int smarts;
    public int magics;


    //Class UI
    [Header("Class UI")]
    public TMP_Dropdown dropdown;
    [SerializeField] TextMeshProUGUI classText;
    [SerializeField] TextMeshProUGUI muscleText;
    [SerializeField] TextMeshProUGUI reflexText;
    [SerializeField] TextMeshProUGUI smartsText;
    [SerializeField] TextMeshProUGUI magicsText;

    //Temporary start menu UI
    bool isReady = false;
    [SerializeField] UnityEngine.UI.Button readyButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isReady = false;
        readyButton.gameObject.SetActive(true);

        // Initialize current health to max health at the start
        currentHealth = maxHealth;
        CharacterHealthText.text = currentHealth + "/" + maxHealth;


        // Set the health bar to reflect the max health
        healthbar.SetMaxHealth(maxHealth);

        Color healthColor = Color.green; // Default color for full health
    }

    public void GetReady()
    {
       isReady = true;
    }


    // Update is called once per frame
    void Update()
    {

        GetDropdownValue();
        SetStats();

        CharacterHealthText.text = currentHealth + "/" + maxHealth;

        // For testing purposes, reduce health when the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }

        if(readyButton.gameObject.activeSelf && isReady)
        {
            readyButton.gameObject.SetActive(false);
            menuUI.SetActive(false);
        }
    }


    // This method retrieves the selected value from the dropdown and logs it to the console
    public void GetDropdownValue()
    {
        int pickedEntryIndex = dropdown.value;
        string selectedOption = dropdown.options[pickedEntryIndex].text;

        classText.text = "Class: " + selectedOption;
        Debug.Log("Selected Class: " + selectedOption);
    }

    public void SetStats()
    {
        if (dropdown.value == 0)//Fighter
        {
            maxHealth = 10;
            muscle = 10;
            relfex = 5;
            smarts = 3;
            magics = 1;
        }
        else if (dropdown.value == 1)//Mage
        {
            maxHealth = 5;
            muscle = 1;
            relfex = 5;
            smarts = 10;
            magics = 10;
        }
        else if (dropdown.value == 2)//Rogue
        {
            maxHealth = 8;
            muscle = 5;
            relfex = 10;
            smarts = 5;
            magics = 3;
        }
        else if (dropdown.value == 3)//Tank
        {
            maxHealth = 20;
            muscle = 8;
            relfex = 3;
            smarts = 3;
            magics = 3;
        }
        else if (dropdown.value == 4)//Priest
        {
            maxHealth = 15;
            muscle = 3;
            relfex = 3;
            smarts = 8;
            magics = 10;
        }
        else if (dropdown.value == 5)//Average Joe
        {
            maxHealth = 10;
            muscle = 5;
            relfex = 5;
            smarts = 5;
            magics = 5;
        }


        //Update stat visuals for dev purposes
        muscleText.text = "Muscle: " + muscle;
        reflexText.text = "Reflex: " + relfex;
        smartsText.text = "Smarts: " + smarts;
        magicsText.text = "Magics: " + magics;
    }

        // Method to reduce health when the character takes damage
        void TakeDamage(int damage)
        {
        currentHealth -= damage;
        Debug.Log("Character took damage. Current health: " + currentHealth);

        // Update the health bar to reflect the new health value
        healthbar.SetHealth(currentHealth);

        StartCoroutine(DamageFlash());

        // Check if the character's health has dropped to zero or below
        if (currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        Debug.Log("Character died.");
        // Add death logic here (e.g., respawn, game over, etc.)
    }


    // Coroutine to handle the damage flash effect
    private IEnumerator DamageFlash()
    {
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(hurtDuration / (numberOfFlashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(hurtDuration / (numberOfFlashes * 2));
        }
    }
}


