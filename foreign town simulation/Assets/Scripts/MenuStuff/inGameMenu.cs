using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inGameMenu : MonoBehaviour {

    public List<GameObject> npcs = new List<GameObject>();
    public GameObject menu;
    public List<Text> texts = new List<Text>();
    List<npcfriendship> friends = new List<npcfriendship>();
    public Text money;
    public Text words;
    bool inMenu = false;
    int friendValue;
    int wordCount;
    // Use this for initialization
    void Start () {
        for(int i = 0; i < npcs.Count; i++)
        {
            friends.Add(npcs[i].GetComponent<npcfriendship>()); 
        }
        wordCount = 83;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("e"))
        {
            if (inMenu)
            {
                menu.SetActive(false);
                inMenu = false;
            }
            else
            {
                for(int i = 0; i < npcs.Count; i++)
                {
                    friendValue = friends[i].FriendLevel;
                    if (friendValue >= 15)
                    {
                        texts[i].text = friendValue.ToString() + " Friendship Level";
                    }
                    else
                    {
                        texts[i].text = friendValue.ToString() + "/15 Friendship Level";
                    }
                }
                money.text = mainCharacterVars.money + " money";
                words.text = (wordCount - dictInitialize.wordsLeftToUnlock).ToString() + "/" + wordCount + " words unlocked";
                menu.SetActive(true);
                inMenu = true;
            }
        }
	}
}
