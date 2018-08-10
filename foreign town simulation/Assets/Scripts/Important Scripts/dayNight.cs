using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dayNight : MonoBehaviour {
    public static int dayCount = 1;
    public static bool inBed = false;

    public Text day2timelimitnoti;
    public float day2notitimer;

    public static bool enteredasign;
    public static bool lockmovement;

    public GameObject mainchar;
    mainCharacterVars charactervars;

    public GameObject npc1;
    public GameObject npc2;
    public GameObject npc3;
    public GameObject npc4;
    public GameObject market;
    public GameObject mailman;
    public GameObject bank;
    public GameObject pizza;
    interact interact1;
    interact interact2;
    interact interact3;
    interact interact4;
    npcGiveTask give1;
    npcGiveTask give2;
    npcGiveTask give3;
    npcGiveTask give4;
    interactWith interactWithMarket;
    interactWith interactWithMailman;
    interactWith interactWithBank;
    interactWith interactWithPizza;

    public static bool tutorialmode;

    //tutorial stuff
    public int tutorialpos;
    public static bool selectedtutorial;
    public GameObject tutorialbox;
    public Text tutorialtext;
   


    void Awake() {
        charactervars = mainchar.GetComponent<mainCharacterVars>();
        interact1 = npc1.GetComponent<interact>(); give1 = npc1.GetComponent<npcGiveTask>();
        interact2 = npc2.GetComponent<interact>(); give2 = npc2.GetComponent<npcGiveTask>();
        interact3 = npc3.GetComponent<interact>(); give3 = npc3.GetComponent<npcGiveTask>();
        interact4 = npc4.GetComponent<interact>(); give4 = npc4.GetComponent<npcGiveTask>();
        interactWithMarket = market.GetComponent<interactWith>();
        interactWithMailman = mailman.GetComponent<interactWith>();
        interactWithBank = bank.GetComponent<interactWith>();
        interactWithPizza = pizza.GetComponent<interactWith>();
        day2timelimitnoti.text = "";
        day2notitimer = 8.5f;

        tutorialtext.text = "";

        if (selectedtutorial)
        {
            tutorialpos = 0;
            tutorialbox.SetActive(true);
        }
        else
        {
            tutorialpos = 25;
            tutorialbox.SetActive(false);
        }
    }

    void Update () {
        if (inBed)
        {
            dayCount++;
            interact1.seenNoTasks = false;
            interact2.seenNoTasks = false;
            interact3.seenNoTasks = false;
            interact1.wordLearnCap = 10;
            interact2.wordLearnCap = 10;
            interact3.wordLearnCap = 10;
            interactWithMarket.wordLearnCap = 10;
            interactWithMailman.wordLearnCap = 10;
            interactWithBank.wordLearnCap = 10;
            interactWithPizza.wordLearnCap = 10;
            tutorialpos = 0;
            tutorialbox.SetActive(false);
            tutorialtext.text = "";

            inBed = false;
        }

        if (dayCount == 1)
        {
            tutorialmode = true;
            if (tutorialpos == 0)
            {
                lockmovement = true;
                tutorialtext.text = "Welcome, new player! This is a tutorial designed to show you how to play through the game!\n\nLANGUAGE: UNKNOWN is a game in which you find yourself in a completely foriegn town, with barely any knowledge of the local language.\n\nEvery time you start a new game, this 'language' is randomly generated.\n\nThe goal of the game is to learn the local language in the least amount of days possible.\n\nPress ENTER when you are ready to continue.";
                if (Input.GetKey(KeyCode.Return))
                {
                    tutorialpos = 1;
                    lockmovement = false;
                }
            }
            if (tutorialpos == 1)
            {
                lockmovement = true;
                tutorialtext.text = "To learn words, you need to complete tasks given to you by NPCs (Non-Player Characters).\n\nFirst we need to tell you how to move your character.\n\nTo move, you can use the W,A,S, and D keys.\n\nPress ENTER when you are ready to continue.";
                if (Input.GetKey(KeyCode.Return))
                {
                    tutorialpos = 2;
                    lockmovement = false;
                }
            }
            else if (tutorialpos == 2)
            {
                tutorialtext.text = "The goal of the game is to learn all the words of the foreign language in as little days as possible.\n\nYou learn words by completing tasks with an NPC.\n\nNPCs with tasks for you are indicated with a RED EXCLAMATION MARK.\n\nFind an NPC and talk to him.\n\n\n\nP.S: You can move now :)";
                if (charactervars.currentTask && ((give1.dayCount + give2.dayCount + give3.dayCount + give4.dayCount) == 0))
                {
                    tutorialpos = 3;
                }
            }
            else if (tutorialpos == 3)
            {
                lockmovement = true;
                tutorialtext.text = "Good job! The NPC has given you a task.\n\nThere's one problem - you can't understand what he's saying!\n\nWhen you receive a task, the box in the top right corner is updated with your task.\n\nPress ENTER when you are ready to continue.";
                if (Input.GetKey(KeyCode.Return))
                {
                    tutorialpos = 4;
                }
            }
            else if (tutorialpos == 4)
            {
                tutorialtext.text = "For now, you will only receive easy tasks.\n\nEasy tasks require you to go to a worker (indicated by the black double exclamation marks), deliver them an item, and return back to the NPC who gave you the task.\n\nTo help with tasks, you can view the entire map by pressing the M key.\n\nView the map to continue.";
                if (Input.GetKey("m"))
                {
                    tutorialpos = 5;
                    lockmovement = false;
                }
            }
            else if (tutorialpos == 5)
            {
                tutorialtext.text = "You may have been wondering: How do I know which worker to go to?\n\nThis is where SIGNS come in. Each location is marked by a sign outside of it.\n\nThe best way to find out which place you need to go to is by matching words from the 'current task box' to words on signs!\n\nGo find a sign.";
                if (enteredasign)
                {
                    tutorialpos = 6;
                }
            }
            else if (tutorialpos == 6)
            {
                tutorialtext.text = "Now, check if the word on the sign matches any words in the task prompt.\n\nIf it does, go inside and interact with the worker (Indicated by double exclamation marks), then return back to the NPC who gave you the task (Indicated by yellow star).\n\nIf it does not, try other signs until you find a sign that matches your task prompt.";
                if (!charactervars.currentTask && ((give1.dayCount + give2.dayCount + give3.dayCount + give4.dayCount) == 1))
                {
                    tutorialpos = 7;
                }
            }
            else if (tutorialpos == 7)
            {
                lockmovement = true;
                tutorialtext.text = "Wonderful. You have completed a task and increased your friendship with one NPC.\n\nYou won't be able to get any more tasks today from this NPC.\n\nPress Enter to continue.";
                if (Input.GetKey(KeyCode.Return))
                {
                    tutorialpos = 8;
                }
            }
            else if (tutorialpos == 8)
            {
                tutorialtext.text = "Nice! You can also access an in-game menu by pressing E.\n\nThis in-game menu will show you your frienship level with NPCs, words left to unlock, and your money.\n\nOpen the in-game menu to continue.";
                if (Input.GetKey("e"))
                {
                    tutorialpos = 9;
                    lockmovement = false;
                }
            }
            else if (tutorialpos == 9)
            {
                tutorialtext.text = "Great. Almost done!\n\nGet and complete tasks from all the other NPCs.\n\nYou can access hints by clicking ESC and then clicking 'Hints'.";
                if (!charactervars.currentTask && ((give1.dayCount + give2.dayCount + give3.dayCount + give4.dayCount) == 4))
                {
                    tutorialpos = 10;
                }
            }
            else if (tutorialpos == 10)
            {
                tutorialmode = false;
                tutorialtext.text = "Very well done! You have completed a day.\n\nTo unlock more tasks from NPCs, you need to sleep in the bed.\n\nHowever, everytime you sleep in a bed you lower your score.\n\nTo end the tutorial and sleep to the next day, go sleep in the bed.\n\nTomorrow and on, you will have a one-minute time limit to earn points from tasks.";
            }

        }







        if (dayCount == 2)
        {
            day2notitimer -= Time.deltaTime;

            if (day2notitimer <= 4.0f && day2notitimer >= 0.0f)
            {
                day2timelimitnoti.text = "There is a time limit on tasks starting today!\nDo your tasks quickly to earn more friendship points!";
            }
            else if (day2notitimer < 0.0f)
            {
                day2timelimitnoti.text = "";
            }
        }
    }
}
