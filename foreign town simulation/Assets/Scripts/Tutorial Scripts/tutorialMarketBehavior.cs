using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialMarketBehavior : MonoBehaviour {
    public bool interactable;
    public bool taskmode;
    public Image speechbubble;
    public Text dialogue;
    public GameObject star;

    public string selected;
    void Start()
    {
        interactable = false;
        taskmode = false;
        selected = "";
        speechbubble.enabled = false;
        dialogue.text = "";
        star.active = false;
    }
    void OnTriggerEnter2D(Collider2D col) {
        if(tutorial.tutorialPosition == 3) {
            interactable = true;
            speechbubble.enabled = true;
            dialogue.text = "Press Space to interact.";
        }
    }
    void OnTriggerExit2D(Collider2D col) {
        interactable = false;
        speechbubble.enabled = false;
        dialogue.text = "";
    }

    void Update() {
        if (interactable) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (tutorial.tutorialPosition == 3) {
                    star.active = true;
                    tutorial.tutorialPosition = 4;
                    dialogue.text = "skdoa hes eor dksjil osl iehrs";
                }
            }
        }
    }
}