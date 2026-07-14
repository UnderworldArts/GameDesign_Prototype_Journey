using TMPro;
using System.Collections;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI genText; // the text game object itself
    private Coroutine typingCoroutine; // Coroutine that types the string over the course of a few seconds
    private Coroutine clearCoroutine; // Coroutine that 
    private AudioSource source; // nickname for the text sound effect

    void Start()
    {
        source = GetComponent<AudioSource>(); // assigns as the audiosource from the game object the script is on
    }

    public void ShowText(string forTextBox) // function triggered through the other scripts passing through the string in brackets
    {
        // Stop ongoing coroutine i.e., if the player is quickly clicking through
        if (typingCoroutine != null) // != null means NOT NULL i.e., currently active
        {
            StopCoroutine(typingCoroutine);
        }

        genText.text = ""; // Clears all text in the text box
        typingCoroutine = StartCoroutine(WriteText(forTextBox)); // carries the string into the coroutine
    }

    private IEnumerator WriteText(string forTextBox)
    {
        for (int i = 0; i < forTextBox.Length; i++) // loop starts at the first letter (i) of the string, continues for all of the letters in the strings, moving on to the next letter
        {
            genText.text += forTextBox[i]; // adds whatever current letter of the string to what is already in the text box
            PlayAudio(); // function for audio
            yield return new WaitForSeconds(0.03f); // wait a couple frames; why a corountine not normal function
        }
    }

    public void PlayAudio()
    {
        if (source != null && source.clip != null) // checks if audio source was on game object and if it has an audio clip attached
        {
            source.Play();
        }
        else // debugging
        {
            Debug.LogWarning("No audio source on game object");
        }
    }
}