using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

                                                          //UPDATE THE FILEPATH IF YOU WANT YOURS TO WORK!!!!!!!
public class SaveGame : MonoBehaviour {

    mainCharacterVars characterVars;
    public GameObject maincharacter;
    public GameObject npc1; npcfriendship friend1; npcGiveTask daycount1;
    public GameObject npc2; npcfriendship friend2; npcGiveTask daycount2;
    public GameObject npc3; npcfriendship friend3; npcGiveTask daycount3;
    public GameObject npc4; npcfriendship friend4; npcGiveTask daycount4;

    public GameObject Translator; translator translate;

    public Text message;

    public void onclick()
    {
        message.text = savegame();
    }


    string savedirectory;
    string fname = "\\savegame.fts";


    //need to eventually make program auto detect game filepath to work on other computers.
    string filepath;

    // Use this for initialization
    void Start () {
        characterVars = maincharacter.GetComponent<mainCharacterVars>();
        friend1 = npc1.GetComponent<npcfriendship>(); daycount1 = npc1.GetComponent<npcGiveTask>();
        friend2 = npc2.GetComponent<npcfriendship>(); daycount2 = npc2.GetComponent<npcGiveTask>();
        friend3 = npc3.GetComponent<npcfriendship>(); daycount3 = npc3.GetComponent<npcGiveTask>();
        friend4 = npc4.GetComponent<npcfriendship>(); daycount4 = npc4.GetComponent<npcGiveTask>();
        translate = Translator.GetComponent<translator>();
        

    }

    public string savegame()
    {
        savedirectory = Directory.GetCurrentDirectory();

        filepath = savedirectory + fname;
        Debug.Log(filepath);
        if (characterVars.currentTask)
        {
            return "You cannot save while doing a task.";
        }
        


        //check if savegame already exists, if it does, old savegame is deleted and a new one is created.
        if (System.IO.File.Exists(filepath))
        {
            System.IO.File.Delete(filepath);
        }


        FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write, FileShare.Write);
        StreamWriter sw = new StreamWriter(fs);

        //saving player stats (lines 1-3)

        sw.WriteLine(dayNight.dayCount.ToString());//line 1 is daycount
        sw.WriteLine(mainCharacterVars.taskXP.ToString());//line 2 is taskXP
        sw.WriteLine(mainCharacterVars.money.ToString());//line 3 is money

        //saving npc friendship (lines 4-7)

        sw.WriteLine(friend1.FriendLevel.ToString());//friendlevel
        sw.WriteLine(friend2.FriendLevel.ToString());
        sw.WriteLine(friend3.FriendLevel.ToString());
        sw.WriteLine(friend4.FriendLevel.ToString());

        //saving npc daycount (lines 8 - 11)

        sw.WriteLine(daycount1.dayCount.ToString()); sw.WriteLine(daycount2.dayCount.ToString());
        sw.WriteLine(daycount3.dayCount.ToString()); sw.WriteLine(daycount4.dayCount.ToString());

        //saving words left to unlock (line 12)

        sw.WriteLine(dictInitialize.wordsLeftToUnlock.ToString()); //words left

        //saving translator daycount (line 13)

        sw.WriteLine(translate.dayCount);

        //saving each word in dictionary (lines 14- 307)

        foreach (Word word in dictInitialize.gameDict)
        {
            sw.WriteLine(word.engWord);//english word, then scrambled word, then % unlocked
            sw.WriteLine(word.scrambledWord);
            sw.WriteLine(word.unlocked.ToString());
        }
        sw.Close();
        fs.Close();

        return "Game Saved.";
        
        


    }



    


}
