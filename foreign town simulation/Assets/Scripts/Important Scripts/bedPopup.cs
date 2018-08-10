using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bedPopup : MonoBehaviour {
    bool interact = false;
    public Image textBox;
    public Text talking;
    public bool isTutorial;
    public GameObject mainChar;
    mainCharacterVars mainCharVars;
	// Use this for initialization
	void Start () {
        textBox.enabled = false;
        mainCharVars = mainChar.GetComponent<mainCharacterVars>();
	}
	
	// Update is called once per frame
	void Update () {
        if (interact)
        {
            if (Input.GetKeyDown(KeyCode.Space)){
                if (isTutorial && tutorial.tutorialPosition == 5)
                {
                    tutorial.tutorialPosition = 6;
                }
                else if (isTutorial)
                {

                }
                else if (mainCharVars.currentTask)
                {

                }
                else if (dayNight.tutorialmode)
                {

                }
                else
                {
                    playerMovement.playoutofbedanim = true;
                    dayNight.inBed = true;
                    talking.text = "";
                }
            }
        }
        //Debug.Log(dayNight.dayCount);
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        interact = true;
        textBox.enabled = true;
        if (mainCharVars.currentTask)
        {
            talking.text = "Can't go to next day while you have a task.";
        }
        else if (dayNight.tutorialmode)
        {
            talking.text = "Finish the tutorial before you sleep in a bed!";
        }
        else
        {
            talking.text = "Press space to go to next day.";
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        interact = false;
        textBox.enabled = false;
        talking.text = "";
    }
}
