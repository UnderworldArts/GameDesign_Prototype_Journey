using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterStats : MonoBehaviour
{
    public Character[] characters;
    public Character chosenCharacter;


    [SerializeField]private SpriteRenderer spriteRenderer;

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

    [Header("Damage Test Info")]
    public int damage;
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
    public GameObject charSelectUI; // Reference to the character selection UI

    // for actions script
    public bool CanAbility = true;
    public int IndexList;
    [SerializeField] Actions actions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isReady = false;
        charSelectUI.gameObject.SetActive(true);

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
        charSelectUI.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        GetDropdownValue();

        CharacterHealthText.text = currentHealth + "/" + maxHealth;

        if (currentHealth <= 0)
        {
            Die();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(damage);
        }

        if (!isReady)
        {
            SetStats();
        }
    }


    // This method retrieves the selected value from the dropdown and logs it to the console
    public void GetDropdownValue()
    {
        int pickedEntryIndex = dropdown.value;
        string selectedOption = dropdown.options[pickedEntryIndex].text;

        classText.text = "Class: " + selectedOption;
        //Debug.Log("Selected Class: " + selectedOption);
    }

    public void SetStats()
    {
        //Assign class from dropdown
        chosenCharacter = characters[dropdown.value];

        //Assign sprite from dropdown
        spriteRenderer.sprite = chosenCharacter.classSprite;

        //Assign stats based on chosen class
        maxHealth = chosenCharacter.maxHealth;
        currentHealth = maxHealth;
        muscle = chosenCharacter.muscle;
        relfex = chosenCharacter.reflex;
        smarts = chosenCharacter.smarts;
        magics = chosenCharacter.magics;
        characterClass = chosenCharacter.name;


        //Update stat visuals for dev purposes
        muscleText.text = "Muscle: " + muscle;
        reflexText.text = "Reflex: " + relfex;
        smartsText.text = "Smarts: " + smarts;
        magicsText.text = "Magics: " + magics;
    }

    void Die()
    {
        Debug.Log(chosenCharacter + "has died.");
        actions.RemoveDeadCharacter(chosenCharacter, IndexList);
    }

    // Method to reduce health when the character takes damage
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Character took damage. Current health: " + currentHealth);

        // Update the health bar to reflect the new health value
        healthbar.SetHealth(currentHealth);

        StartCoroutine(DamageFlash());

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


