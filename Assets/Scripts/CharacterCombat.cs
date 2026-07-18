using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public Character character;
    public int currentHealth;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = character.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
