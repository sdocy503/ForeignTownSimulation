using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        messagetext.text = "";
	}

    //used for saying if theres no save file.
    public Text messagetext; 
    
    //Holds saved dictionary.
    public static List<Word> tempdict = new List<Word>();
    public static int tempwordstounlock;
    //Holds saved friendship values.
    public static int npc1friendlevel; public static int npc2friendlevel;
    public static int npc3friendlevel; public static int npc4friendlevel;
    //Holds NPC data
    public static int npc1daycount; public static int npc2daycount;
    public static int npc3daycount; public static int npc4daycount;
    //holds translator daycount
    public static int translatordaycount;

    //need to eventually make program auto detect game filepath to work on other computers.


    public void onclick(string a)
    {
        savedirectory = Directory.GetCurrentDirectory();
        filepath = savedirectory + fname;

        if (!File.Exists(filepath))
        {
            messagetext.text = "No save file found.";
        }
        else
        {
            messagetext.text = "";
            dictInitialize.previousdict = true;
            loadgamedata();
            SceneManager.LoadScene(a);
        }
    }

    string savedirectory; string filepath;
    string fname = "\\savegame.fts";


    public void loadgamedata()
    {
        Word tempword = new Word();

        

        int dictCounter = 1;

        FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
        StreamReader sr = new StreamReader(fs);

        for (int i = 1; i <= 120; i++)
        {
            string temp = sr.ReadLine();

            if (i == 1)
            {
                dayNight.dayCount = Convert.ToInt32(temp);
            }
            else if (i == 2)
            {
                mainCharacterVars.taskXP = Convert.ToInt32(temp);
            }
            else if (i == 3)
            {
                mainCharacterVars.money = Convert.ToInt32(temp);
            }
            else if (i >= 4 && i <= 7)
            {
                switch (i)
                {
                    case 4:
                        npc1friendlevel = Convert.ToInt32(temp);
                        break;
                    case 5:
                        npc2friendlevel = Convert.ToInt32(temp);
                        break;
                    case 6:
                        npc3friendlevel = Convert.ToInt32(temp);
                        break;
                    case 7:
                        npc4friendlevel = Convert.ToInt32(temp);
                        break;
                }

            }
            else if (i >= 8 && i <= 11)
            {
                switch (i)
                {
                    case 8:
                        npc1daycount = Convert.ToInt32(temp);
                        break;
                    case 9:
                        npc2daycount = Convert.ToInt32(temp);
                        break;
                    case 10:
                        npc3daycount = Convert.ToInt32(temp);
                        break;
                    case 11:
                        npc4daycount = Convert.ToInt32(temp);
                        break;
                }

            }
            else if (i == 12)
            {
                tempwordstounlock = Convert.ToInt32(temp);
            }
            else if (i == 13)
            {
                translatordaycount = Convert.ToInt32(temp);
            }
            else
            {             
               for (int j = 0; j < 3; j++)
                {
                    switch (dictCounter)
                    {
                        case 1:
                            tempword = new Word();
                            tempword.engWord = temp;
                            dictCounter++;
                            break;
                        case 2:
                            temp = sr.ReadLine();
                            tempword.scrambledWord = temp;
                            dictCounter++;
                            break;
                        case 3:
                            temp = sr.ReadLine();
                            tempword.unlocked = Convert.ToInt32(temp);
                            tempdict.Add(tempword);
                            dictCounter = 1;
                            break;
                    }
                }
                
            }          
        }

        sr.Close();
        fs.Close();


    }
}
