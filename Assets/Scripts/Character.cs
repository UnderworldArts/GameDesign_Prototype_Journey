using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Create Character")]
public class Character : ScriptableObject
{
    //Character Sprites
    public Sprite classSprite;

    //Class stats
    public int maxHealth;
    public int muscle;
    public int reflex;
    public int smarts;
    public int magics;

    

    
}
