using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class translator : MonoBehaviour {
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public GameObject buttonThree;
    public Image textBox;
    public Text dialogue;
    public Text wordTextOne;
    public Text wordTextTwo;
    public Text wordTextThree;
    Word wordInfoOne;
    Word wordInfoTwo;
    Word wordInfoThree;
    public dictInitialize dict;
    List<string> none;
    string wordOne;
    string wordTwo;
    string wordThree;
    public int dayCount = 0;
    int wordsLeft;

    // Use this for initialization
    void Start () {

        if (dictInitialize.previousdict)
        {
            dayCount = LoadGame.translatordaycount;
        }

        buttonOne.active = false;
        buttonTwo.active = false;
        buttonThree.active = false;
        wordsLeft = dictInitialize.wordsLeftToUnlock;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(dayCount + 1 < dayNight.dayCount)
        {
            dayCount = dayNight.dayCount - 1;
        }
        else if (dayCount > dayNight.dayCount)
        {
            dayCount = dayNight.dayCount;
        }
        if (dayCount >= dayNight.dayCount)
        {
            textBox.enabled = true;
            dialogue.text = "Sorry, i can only help you once per day.";
        }
        else
        {
            textBox.enabled = true;
            dialogue.text = "Hello, I'm a translator, pick a word and I can teach you how to say it.";
            if (dictInitialize.wordsLeftToUnlock >= 3)
            {
                if (wordOne == null || wordTwo == null || wordThree == null || wordsLeft != dictInitialize.wordsLeftToUnlock)
                {
                    //Debug.Log("Refresh");
                    wordInfoOne = dictInitialize.gameDict[Random.Range(12, dictInitialize.gameDict.Count)];
                    wordInfoTwo = dictInitialize.gameDict[Random.Range(12, dictInitialize.gameDict.Count)];
                    wordInfoThree = dictInitialize.gameDict[Random.Range(12, dictInitialize.gameDict.Count)];
                    wordOne = wordInfoOne.engWord;
                    wordTwo = wordInfoTwo.engWord;
                    wordThree = wordInfoThree.engWord;
                    while (wordOne == wordTwo || wordOne == wordThree || wordTwo == wordThree || wordInfoOne.unlocked >= 100 || wordInfoTwo.unlocked >= 100 || wordInfoThree.unlocked >= 100)
                    {
                        wordInfoOne = dictInitialize.gameDict[Random.Range(12, dictInitialize.gameDict.Count)];
                        wordInfoTwo = dictInitialize.gameDict[Random.Range(12, dictInitialize.gameDict.Count)];
                        wordInfoThree = dictInitialize.gameDict[Random.Range(12, dictInitialize.gameDict.Count)];
                        wordOne = wordInfoOne.engWord;
                        wordTwo = wordInfoTwo.engWord;
                        wordThree = wordInfoThree.engWord;
                    }
                    wordsLeft = dictInitialize.wordsLeftToUnlock;
                }
                wordTextOne.text = wordOne;
                wordTextTwo.text = wordTwo;
                wordTextThree.text = wordThree;
                buttonOne.active = true;
                buttonTwo.active = true;
                buttonThree.active = true;
            }
            else if (dictInitialize.wordsLeftToUnlock == 2)
            {
                if (wordOne == null || wordTwo == null || wordsLeft != dictInitialize.wordsLeftToUnlock)
                {
                    wordInfoOne = dictInitialize.gameDict[Random.Range(12, dictInitialize.gameDict.Count)];
                    wordInfoTwo = dictInitialize.gameDict[Random.Range(12, dictInitialize.gameDict.Count)];
                    wordOne = wordInfoOne.engWord;
                    wordTwo = wordInfoTwo.engWord;
                    while (wordOne == wordTwo || wordInfoOne.unlocked >= 100 || wordInfoTwo.unlocked >= 100)
                    {
                        wordInfoOne = dictInitialize.gameDict[Random.Range(12, dictInitialize.gameDict.Count)];
                        wordInfoTwo = dictInitialize.gameDict[Random.Range(12, dictInitialize.gameDict.Count)];
                        wordOne = wordInfoOne.engWord;
                        wordTwo = wordInfoTwo.engWord;
                    }
                    wordsLeft = dictInitialize.wordsLeftToUnlock;
                }
                wordTextOne.text = wordOne;
                wordTextTwo.text = wordTwo;
                buttonOne.active = true;
                buttonTwo.active = true;
            }
            else if (dictInitialize.wordsLeftToUnlock == 1)
            {
                if (wordOne == null || wordsLeft != dictInitialize.wordsLeftToUnlock)
                {
                    wordInfoOne = dictInitialize.gameDict[Random.Range(12, dictInitialize.gameDict.Count)];
                    wordOne = wordInfoOne.engWord;
                    while (wordInfoOne.unlocked >= 100)
                    {
                        wordInfoOne = dictInitialize.gameDict[Random.Range(12, dictInitialize.gameDict.Count)];
                        wordOne = wordInfoOne.engWord;
                    }
                    wordsLeft = dictInitialize.wordsLeftToUnlock;
                }
                wordOne = wordInfoOne.engWord;
                wordTextOne.text = wordOne;
                buttonOne.active = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        buttonOne.active = false;
        buttonTwo.active = false;
        buttonThree.active = false;
        wordTextOne.text = "";
        wordTextTwo.text = "";
        wordTextThree.text = "";
        textBox.enabled = false;
        dialogue.text = "";
    }

    public void pressOne()
    {
        dict.learnWord(wordOne, "?", none, 100);
        //wordInfoOne.unlocked = 100;
        wordOne = null;
        wordInfoOne = null;
        wordTwo = null;
        wordInfoTwo = null;
        wordThree = null;
        wordInfoThree = null;
        buttonOne.active = false;
        buttonTwo.active = false;
        buttonThree.active = false;
        textBox.enabled = false;
        dialogue.text = "";
        dayCount++;
        wordsLeft = dictInitialize.wordsLeftToUnlock;
    }

    public void pressTwo()
    {
        dict.learnWord(wordTwo, "?", none, 100);
        //wordInfoTwo.unlocked = 100;
        wordOne = null;
        wordInfoOne = null;
        wordTwo = null;
        wordInfoTwo = null;
        wordThree = null;
        wordInfoThree = null;
        buttonOne.active = false;
        buttonTwo.active = false;
        buttonThree.active = false;
        textBox.enabled = false;
        dialogue.text = "";
        dayCount++;
        wordsLeft = dictInitialize.wordsLeftToUnlock;
    }

    public void pressThree()
    {
        dict.learnWord(wordThree, "?", none, 100);
        //wordInfoThree.unlocked = 100;
        wordOne = null;
        wordInfoOne = null;
        wordTwo = null;
        wordInfoTwo = null;
        wordThree = null;
        wordInfoThree = null;
        buttonOne.active = false;
        buttonTwo.active = false;
        buttonThree.active = false;
        textBox.enabled = false;
        dialogue.text = "";
        dayCount++;
        wordsLeft = dictInitialize.wordsLeftToUnlock;
    }
}
