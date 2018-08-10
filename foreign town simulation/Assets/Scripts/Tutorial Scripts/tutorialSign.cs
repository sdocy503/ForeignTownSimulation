using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialSign : MonoBehaviour
{
    public Image textBox;
    public Text dialogue;
    public string wordDisplay;

    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        displayWord(wordDisplay);
        if (tutorial.tutorialPosition == 2)
            tutorial.tutorialPosition = 3;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textBox.enabled = false;
        dialogue.text = "";
    }

    void displayWord(string word)
    {
        textBox.enabled = true;
        dialogue.text = "Sign says: " + wordDisplay;
    }
}
