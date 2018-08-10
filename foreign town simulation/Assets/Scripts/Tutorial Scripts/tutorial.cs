using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour {
    public static int tutorialPosition = 0;
    public Text tutorialText;
    public GameObject scripts;
    public GameObject doubleexlamationmarks;
    load next;
    void Start () {
        next = scripts.GetComponent<load>();
        doubleexlamationmarks.SetActive(false);
	}
	
	void Update () {
        if ((Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")) && (tutorialPosition == 0))
        {
            tutorialPosition = 1;
            tutorialText.text = "Good! Look at the NPC. The RED EXCLAMATION MARK above his head indicates that the NPC has a task for you to complete.\n\nWalk up to and talk to the NPC.";
        }
        else if (tutorialPosition == 2)
        {
            doubleexlamationmarks.SetActive(true);
            tutorialText.text = "Well Done! The NPC has given you a task. Task dialogue is indicated in RED TEXT.\n\nThere's just one problem: You can't understand him yet.\n\nIf you don't know where the NPC wants you to go, you might want to check a SIGN!";
        }
        else if (tutorialPosition == 3)
        {
            tutorialText.text = "The sign says \"amrght\". Do you recognize that from the task? This is where the NPC wants you to go!\n\nThis is useful when you don't know where an NPC wants you to go.\n\nPlaces you can complete tasks at are indicated by DOUBLE EXCLAMATION MARKS.\n\nHowever, just because there are double exclamation marks DOES NOT mean that is the right place to complete the task!";
        }
        else if (tutorialPosition == 4)
        {
            doubleexlamationmarks.SetActive(false);
            tutorialText.text = "Great! You have obtained the item required to complete your task.\n\nNow, give the item back to the NPC.\n\n\n\n(Did you notice the foreign language again?)";
        }
        else if (tutorialPosition == 5)
        {
            tutorialText.text = "Very Nice! You have completed the NPC's task. As you complete more and more tasks, you will slowly learn more words in the new language.\n\nYou will also become more friendly with NPCs, allowing you to eventually be able to do even harder tasks.\n\nOnce you have completed all the possible tasks in one day, you must sleep in your bed to advance to the next day and do more tasks. Go sleep in the bed.";
        }
        else if (tutorialPosition == 6)
        {
            tutorialText.text = "Amazing! Just remember: You can't go to sleep if you have an incomplete task.\n\nOnce per day, you can also learn a word from the translator.\n\nTry approaching him and picking a word to learn.";
        }
        else if (tutorialPosition == 7)
        {
            tutorialText.text = "You also have a map that allows you to see the entire town.\n\n Press M to use the map.";
            if (Input.GetKeyDown("m"))
            {
                tutorialPosition = 8;
            }
        }
        else if (tutorialPosition == 8)
        {
            tutorialText.text = ("Sadly, there is no map in the tutorial, but holding down the M key will allow you to look at the map during the game.\n\nPressing E will bring up a menu that shows your friendship level with an npc.\n\nWhen your friendship level with a certain NPC is greater than or equal to 15, you will begin to get harder tasks.");
            if (Input.GetKeyDown("e")){
                tutorialPosition = 9;
            }
        }
        else if (tutorialPosition == 9)
        {
            tutorialText.text = ("Once again, the friendship menu is sadly not in the tutorial but it will work when used in game.\n\nNow you've got to go out there and learn the whole language in as few days as you can!\n\nPress escape to exit the tutorial.");
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                tutorialPosition = 0;
                next.Click("main");
            }
        }
	}
}
