using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class interactWith : MonoBehaviour {
    public Text dialogue;
    public bool interactable;
    public bool taskmode;
    public GameObject mainScriptMan;
    public GameObject mainCharacter;
    mainCharacterVars mainCharacterVars;
    dictInitialize dictInitialize;
    npcConversation npcConversation;
    public string whatYouNeed;
    public List<string> afterInteract;
    public List<string> placeholder;
    public Image SpeechBubble;

    public GameObject confusedemote;
    public GameObject tasklocationemote;

    public GameObject meatbutton;
    public GameObject breadbutton;
    public GameObject grapesbutton;
    public GameObject olivebutton;
    public GameObject tomatobutton;

    public bool ismarket;
    public bool ispizza;
    public string selected;

    public int wordLearnCap = 10;
    void Start()
    {
        dictInitialize = mainScriptMan.GetComponent<dictInitialize>();
        mainCharacterVars = mainCharacter.GetComponent<mainCharacterVars>();
        npcConversation = GetComponent<npcConversation>();
        interactable = false;
        taskmode = false;
        whatYouNeed = "";
        selected = "";
        meatbutton.SetActive(false); breadbutton.SetActive(false); grapesbutton.SetActive(false); olivebutton.SetActive(false); tomatobutton.SetActive(false); confusedemote.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        interactable = true;
        SpeechBubble.enabled = true;
        dialogue.text = "Press Space to talk.";
    }
    void OnTriggerExit2D(Collider2D col)
    {
        interactable = false;
        SpeechBubble.enabled = false;
        dialogue.text = "";
        meatbutton.SetActive(false); breadbutton.SetActive(false); grapesbutton.SetActive(false); olivebutton.SetActive(false); tomatobutton.SetActive(false); confusedemote.SetActive(false);
    }
    void Update()
    {
        if (mainCharacterVars.currentTask)
        {
            tasklocationemote.SetActive(true);
        }
        else
        {
            tasklocationemote.SetActive(false);
        }

        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.Space) || selected != "")
            {
                if (taskmode)
                {
                    if (ismarket || ispizza)
                    {
                        //if (mainCharacterVars.taskItem == "")
                        //{
                            if (ismarket) {
                                dialogue.text = "Click on what you would like to buy from the market.";
                                breadbutton.SetActive(true);
                                grapesbutton.SetActive(true);
                            }
                            else if (ispizza) {
                                dialogue.text = "Click on what you want on your pizza!";
                                olivebutton.SetActive(true);
                                tomatobutton.SetActive(true);
                            }
                            meatbutton.SetActive(true);
                        //}
                        if (selected != "")
                        {
                            if (Browse(whatYouNeed))
                            {
                                mainCharacterVars.taskItem = whatYouNeed;
                                for (int i = 0; i < afterInteract.Count; i++) { placeholder.Add(afterInteract[i]); }
                                placeholder.Add(whatYouNeed);
                                dialogue.text = dictInitialize.scramble(placeholder);
                                placeholder.Clear();
                                selected = "";

                                mainCharacterVars.almostdone = true;
                            }
                            else if (!Browse(whatYouNeed) && selected != "")
                            {
                                mainCharacterVars.taskItem = selected;
                                for (int i = 0; i < afterInteract.Count; i++) { placeholder.Add(afterInteract[i]); }
                                placeholder.Add(whatYouNeed);
                                dialogue.text = dictInitialize.scramble(placeholder);
                                placeholder.Clear();
                                selected = "";

                                mainCharacterVars.almostdone = true;
                            }
                        }
                        else
                        {
                            if (ismarket)
                                dialogue.text = "Click on what you would like to buy from the market.";
                            else if (ispizza)
                                dialogue.text = "Click on what you want on your pizza!";
                        }
                    }
                    else if (!ismarket && !ispizza)
                    {
                        mainCharacterVars.taskItem = whatYouNeed;
                        for (int i = 0; i < afterInteract.Count; i++) { placeholder.Add(afterInteract[i]); }
                        placeholder.Add(whatYouNeed);
                        dialogue.text = dictInitialize.scramble(placeholder);
                        placeholder.Clear();                        
                        selected = "";

                        mainCharacterVars.almostdone = true;
                    }
                }
                else if (!taskmode)
                {
                    if (mainCharacterVars.currentTask)
                    {
                        confusedemote.SetActive(true);
                    }
                    dialogue.text = npcConversation.makeConversation(false);
                }
            }
        }
    }
    public bool Browse(string Item) {
        if (selected == Item) {
            return true;
        }
        else {
            return false;
        }
    }
    public void setselected(Button button) {
        selected = button.name;
        switch (selected) {
            case "breadbutton":
                selected = "bread";
                break;
            case "meatbutton":
                selected = "meat";
                break;
            case "grapesbutton":
                selected = "grape";
                break;
            case "olivebutton":
                selected = "olive";
                break;
            case "tomatobutton":
                selected = "tomato";
                break;
            default:
                selected = "";
                break;
        }
    }
}
