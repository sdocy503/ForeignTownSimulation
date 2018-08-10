using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interact : MonoBehaviour {
    public Text dialogue;
    public Text cornertaskprompt;
    public bool interactable;
    public string taskItemReq;
    public Image SpeechBubble;

    public GameObject selectTaskEasyButton;
    public GameObject selectTaskHardButton;

    public GameObject mainCharacter;
    public GameObject mainScriptMan;
    dictInitialize dictInitialize;
    npcfriendship npcFriendship;
    mainCharacterVars mainCharacterVars;
    npcGiveTask giveTask;

    public bool seenNoTasks = false;
    public bool seenTaskPrompt = false;
    public string currentTaskPrompt;
    public int wordLearnCap = 10;

    Color defaultTextColor;
    static int choice;
    int rand;
    
    List<string> buttonPrompt = new List<string> {"do", " ", "you", " ", "want", " ", "an", " ", "easy", " ", "task", " ", "or", " ", "a", " ", "hard", " ", "task", "?"};

    void Awake () {
        giveTask = GetComponent<npcGiveTask>();
        mainCharacterVars = mainCharacter.GetComponent<mainCharacterVars>();
        npcFriendship = GetComponent<npcfriendship>();
        dictInitialize = mainScriptMan.GetComponent<dictInitialize>();
        SpeechBubble.enabled = false;
        selectTaskEasyButton.active = false;
        selectTaskHardButton.active = false;

        defaultTextColor = dialogue.color;
        dialogue.supportRichText = true;
    }

    void Start () {
        interactable = false;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        interactable = true;
        SpeechBubble.enabled = true;
        dialogue.text = "Press Space to talk.";
        choice = 0;
        dialogue.color = defaultTextColor;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        interactable = false;
        SpeechBubble.enabled = false;
        dialogue.text = "";
        selectTaskEasyButton.active = false;
        selectTaskHardButton.active = false;
        seenTaskPrompt = false;
        dialogue.color = defaultTextColor;
    }

    void Update () {
        if (interactable) {
            if(choice != 0) {
                if(choice == 1)
                    rand = Random.Range(0, 4);
                else if (choice == 2)
                    rand = Random.Range(0, 6);
                currentTaskPrompt = giveTask.scrambleTask(choice, rand);
                dialogue.text = currentTaskPrompt;
                cornertaskprompt.text = ("Current task:\n" + currentTaskPrompt);
                dialogue.color = Color.red;
                choice = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Space)) {
                if (mainCharacterVars.currentTask == false && giveTask.dayCount < dayNight.dayCount) {
                    if (npcFriendship.FriendLevel >= 10) {
                        selectTaskEasyButton.active = true;
                        selectTaskHardButton.active = true;
                        dialogue.color = defaultTextColor;
                        dialogue.text = dictInitialize.scramble(buttonPrompt);
                    }
                    else
                        choice = 1;
                }
                else {
                    dialogue.color = defaultTextColor;
                    dialogue.text = giveTask.getNoTask();
                    if (giveTask.completed == true)
                    {
                        cornertaskprompt.text = "Current task:\nNone";
                    }
                }
            }
        }
    }

    public void pressEasy() {
        selectTaskEasyButton.active = false;
        selectTaskHardButton.active = false;
        choice = 1;
    }

    public void pressHard() {
        selectTaskEasyButton.active = false;
        selectTaskHardButton.active = false;
        choice = 2;
    }
}
