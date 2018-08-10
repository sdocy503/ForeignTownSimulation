using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialNPCBehavior : MonoBehaviour {
    public bool interactable;
    public string taskItemReq;
    public Image speechbubble;
    public Text dialogue;
    public GameObject task;
    public GameObject waiting;
    public GameObject happy;
    Color defaultTextColor;

    void Start() {
        interactable = false;
        speechbubble.enabled = false;
        waiting.active = false;
        happy.active = false;
        defaultTextColor = dialogue.color;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (tutorial.tutorialPosition == 1 || tutorial.tutorialPosition == 4) {
            interactable = true;
            speechbubble.enabled = true;
            dialogue.text = "Press Space to interact.";
            dialogue.color = defaultTextColor;
        }
    }
    void OnTriggerExit2D(Collider2D col) {
        interactable = false;
        speechbubble.enabled = false;
        dialogue.text = "";
        dialogue.color = defaultTextColor;
    }

    void Update() {
        if (interactable) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (tutorial.tutorialPosition == 1) {
                    task.active = false;
                    waiting.active = true;
                    tutorial.tutorialPosition = 2;
                    dialogue.color = Color.red;
                    dialogue.text = "I ehgc iehrs rodk sjd amrght";
                }
                else if (tutorial.tutorialPosition == 4) {
                    waiting.active = false;
                    happy.active = true;
                    tutorial.tutorialPosition = 5;
                    dialogue.text = "skdoa hes";
                }
            }
        }
    }
}
