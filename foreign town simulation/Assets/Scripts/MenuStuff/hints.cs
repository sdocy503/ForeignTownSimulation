using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hints : MonoBehaviour {

	// Use this for initialization
	void Start () {
        lasthint = "";
	}
    public Text buttontext;
    public string lasthint;  
    public int index;

    public void onclick()
    {
        string[] listofhints = { "Places you can get the item required to complete a task are marked with double exclamation points!", "To get a task, talk to a person with a red exclamation mark above their head!", "Once an NPC tells you your task, he will make random conversation with you until you go away.", "When you've obtained the item necessary for the task, a star will appear above the NPC who gave you the task.", "Sleeping lets you learn a word from the translator, but also lowers your score!", "Check the label in the top right corner to see if you currently have a task.", "Look for similarities in your task prompt and the signs around the town to find out where to go to complete your task!", "If one of the workers at the locations around town seem confused, it probably isn't where you need to be!", "If you finish a task in less than half of the time limit, you will receive bonus friendship points!", "Just because there are double exclamation marks above a location DOES NOT mean that is the right place to complete the task!" };

        index = Random.Range(0, listofhints.Length);

        string currentmessage;
                           
        if (lasthint == "")//makes sure two hints don't appear in a row.
        {
            lasthint = listofhints[index];
            buttontext.text = lasthint;
        }
        else
        {
            bool same = false;

            index = Random.Range(0, listofhints.Length);
            currentmessage = listofhints[index];
            if (currentmessage == lasthint)
            {
                same = true;
            }
            while (same)
            {
                index = Random.Range(0, listofhints.Length);

                currentmessage = listofhints[index];

                if (currentmessage != lasthint)
                {
                    same = false;
                }
            }

            buttontext.text = currentmessage;
            lasthint = currentmessage;
        }        
    }
}
