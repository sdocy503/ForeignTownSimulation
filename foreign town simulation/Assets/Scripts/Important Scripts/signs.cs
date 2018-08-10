using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class signs : MonoBehaviour {
    public Image textBox;
    public Text dialogue;
    public string wordDisplay;
	// Use this for initialization
	void Start () {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        displayWord(wordDisplay);
        dayNight.enteredasign = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textBox.enabled = false;
        dialogue.text = "";
        dayNight.enteredasign = false;
    }

    void displayWord(string word)
    {
        string languageWord = "";
        bool foundWord = false;

        textBox.enabled = true;
        for(int i = 0; i < dictInitialize.gameDict.Count; i++)
        {
            if(dictInitialize.gameDict[i].engWord == word)
            {
                if(dictInitialize.gameDict[i].unlocked < 100)
                {
                    languageWord = dictInitialize.gameDict[i].scrambledWord;
                }
                else
                {
                    languageWord = dictInitialize.gameDict[i].engWord;
                }
                foundWord = true;
                break;
            }
        }
        textBox.enabled = true;
        if (!foundWord){
            dialogue.text = "Error, word not found";
        }
        else
        {
            dialogue.text = "Sign says: " + languageWord;
            
        }
    }
}
