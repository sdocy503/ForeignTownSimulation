using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMenu : MonoBehaviour {
    public GameObject menuBox;
	// Use this for initialization
	void Start () {
        menuBox.active = false;
	}

    public Text hinttext; public Text savegametext;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            menuBox.active = true;
        }
	}
    public void buttonPress()
    {
        savegametext.text = "Save Game";
        hinttext.text = "";
        menuBox.active = false;

    }
}
