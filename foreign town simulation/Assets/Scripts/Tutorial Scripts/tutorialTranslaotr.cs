using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialTranslaotr : MonoBehaviour {
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public GameObject buttonThree;

    // Use this for initialization
    void Start () {
        buttonOne.active = false;
        buttonTwo.active = false;
        buttonThree.active = false;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(tutorial.tutorialPosition == 6)
        {
            buttonOne.active = true;
            buttonTwo.active = true;
            buttonThree.active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        buttonOne.active = false;
        buttonTwo.active = false;
        buttonThree.active = false;
    }

    public void click()
    {
        tutorial.tutorialPosition = 7;
        buttonOne.active = false;
        buttonTwo.active = false;
        buttonThree.active = false;
    }

}
