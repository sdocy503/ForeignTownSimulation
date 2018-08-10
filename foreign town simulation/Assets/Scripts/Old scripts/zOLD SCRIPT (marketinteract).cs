using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class marketinteraction : MonoBehaviour
{
    public Text dialogue;
    public bool interactable;
    public bool taskmode;
    public mainCharacterVars mainCharacter;
    public string whichFood;
    void Start()
    {
        interactable = false;
        taskmode = false;
        whichFood = "";
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        interactable = true;
        dialogue.text = "Press Space to browse the market.";

    }
    void OnTriggerExit2D(Collider2D col)
    {
        interactable = false;
        dialogue.text = "";

    }

    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (taskmode)
                {
                    if (mainCharacter.taskItem == "") {
                        mainCharacter.taskItem = whichFood;
                        dialogue.text = "Got the " + whichFood;
                    }
                    //dialogue.text = "Got the food.";
                    /*if(whichFood == "grapes") {
                        dialogue.text = "Got the grapes";
                        
                    }
                    else if(whichFood == "meat") {
                        dialogue.text = "Got the meat";
                    }
                    else if(whichFood == "bread") {
                        dialogue.text = "Got the bread";
                    }
                    else {
                        dialogue.text = "You should never see this message.";
                    }*/
                    //npc1.taskalmostcomplete = true; //true after task objective is complete.
                }
                else if (!taskmode)
                {
                    dialogue.text = "The market is closed. Come back later.";
                }
            }
        }
    }
}