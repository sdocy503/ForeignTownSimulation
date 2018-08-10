using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcConversation : MonoBehaviour {
    public GameObject mainScriptMan;
    public GameObject mainCharacter;
    dictInitialize dictInitialize;
    interact interact;
    interactWith interactWith;

    mainCharacterVars mainvars;

    public enum Location {Park, Bank, PostOffice, Apartment, Restaraunt, TownHall };
   
    public Location NPCLocation;

    public int oneperday;
    //generic conversations

    public List<List<string>> fillerConversations = new List<List<string>> {
        new List<string> {"it", " ", "is", " ", "my", " ", "friend", "s", " ", "birthday", " ","today", "."},
        new List<string> {"how"," ", "are", " ",  "you", " ", "today", "?"},
        new List<string> {"you", " ", "are", " ","nice", "!"},
        new List<string> {"bread", " ", "is", " ", "good", "."},
        new List<string> {"I", " ", "like", " ", "the", " ", "mayor", "." },
        new List<string> {"I", " ", "want", " ", "it", " ", "to", " ", "be", " ", "my", " ", "birthday", " ", "today", "."},
        new List<string> {"you", " ", "do", " ", "task", "s", " ", "good", "!"},
        new List<string> {"be", " ", "nice", " ", "to", " ", "my", " ", "friend", "s", " ", "too", "!"},
        new List<string> {"I", " ", "like", " ", "meat", " ", "and", " ", "grapes"}
    };


    //area-specific conversations

    public List<List<string>> parkconvos = new List<List<string>>
    {
        new List<string> {"the", " ",  "weather", " ", "is", " ", "nice", " ", "today", "."},
        new List<string> {"my", " ", "friend", " ", "is", " ", "having", " ", "a", " ", "picnic", " ", "later", "." },
        new List<string> {"the", " ", "market", " ", "is", " ", "nice", "!"},
        new List<string> {"I", " ", "like", " ", "grape", "s", "."},
    };
    public List<List<string>> bankconvos = new List<List<string>>
    {
        new List<string> {"I", " ", "like", " ", "money", "!"},
        new List<string> {"I", " ", "just", " ", "took", " ", "my", " ", "money", " ", "from", " ", "the", " ", "bank", "." },
        new List<string> {"I", " ", "have", " ", "no", " ", "more", " ", "money", "!"} ,
        new List<string> {"do", " ", "you", " ", "have", " ", "money", "?"}
    };
    public List<List<string>> postconvos = new List<List<string>>
    {
        new List<string> {"my", " ", "friend", " ", "is", " ", "the", " ", "mail", " ", "carrier", "."} ,
        new List<string> {"it", " ", "is", " ", "busy", " ", "here", "."} ,
        new List<string> {"I", " ", "have", " ", "mail", " ", "to", " ", "deliver", "."} , 
        new List<string> {"I", " ", "like", " ", "the", " ", "post office", "."}
    };
    public List<List<string>> aptconvos = new List<List<string>>
    {
        new List<string> {"I", " ", "am", " ", "tired", "."} ,
        new List<string> {"I", " ", "like", " ", "this", " ", "alley", " ", "!" },
        new List<string> {"I", " ", "like", " ", "the" , " ", "good" , "s", "."},
        new List<string> {"how", " ", "nice", " ", "is", " ", "the", " ", "restaraunt", "?"},
        new List<string> {"I", " ", "am", " ", "busy", "."}
  
    };
    public List<List<string>> restarauntconvos = new List<List<string>>
    {
        new List<string> {"the", " ", "food", " ", "here", " ", "is", " ", "good", "." } ,
        new List<string> {"do", " ", "you", " ", "think", " ", "we", " ", "live", " ", "in", " ", "a", " ", "simulation", "?"} ,
        new List<string> {"pizza", " ", "is", " ", "nice", " ", "with", " ", "olive", "s", "."} , 
        new List<string> {"I", " ", "have", " ", "no", " ", "money", " ", "for", " ", "a", " ", "pizza", " ", "."}
    };
    public List<List<string>> townhallconvos = new List<List<string>>
    {
        new List<string> {"I", " ", "am", " ", "the", " ", "town", " ", "mayor", "."} , 
        new List<string> {"this", " ", "town", " ", "is", " ", "nice", "!"} , 
        new List<string> {"I", " ", "have", " ", "document", "s", " ", "to", " ", "do", "."},
        new List<string> {"I", " ", "like", " ", "to", " ", "think", " ", "in", " ", "my", " ","town hall", "."}
    };
    public List<List<string>> YouShouldntNeedMeRightNow = new List<List<string>>
    {
        new List<string> {"is", " ", "this", " ", "where", " ", "you", " ", "need", " ", "to", " ", "be", "?"}
    };




    public string makeConversation(bool isNPC) {
        string conversation;
        int rand;

        if (oneperday == dayNight.dayCount)//you get 1 areaspecific convo per day
        {
            oneperday += 1;

            switch (NPCLocation)
            {
                case Location.Park:

                    rand = Random.Range(0, parkconvos.Count);
                    dictInitialize.learnWord("park", "market", parkconvos[rand], 50);
                    conversation = dictInitialize.scramble(parkconvos[rand]);
                    return conversation;

                case Location.Bank:
                   
                    rand = Random.Range(0, bankconvos.Count);
                    dictInitialize.learnWord("money", "bank", bankconvos[rand], 50);
                    conversation = dictInitialize.scramble(bankconvos[rand]);
                    return conversation;

                case Location.PostOffice:

                    rand = Random.Range(0, postconvos.Count);
                    dictInitialize.learnWord("mail", "deliver", postconvos[rand], 50);
                    conversation = dictInitialize.scramble(postconvos[rand]);
                    return conversation;

                case Location.Apartment:
                   
                    rand = Random.Range(0, aptconvos.Count);
                    dictInitialize.learnWord("food", "I", aptconvos[rand], 50);
                    conversation = dictInitialize.scramble(aptconvos[rand]);
                    return conversation;

                case Location.Restaraunt:
                    
                    rand = Random.Range(0, restarauntconvos.Count);
                    dictInitialize.learnWord(" ", "I", restarauntconvos[rand], 50);
                    conversation = dictInitialize.scramble(restarauntconvos[rand]);
                    return conversation;

                case Location.TownHall:
                    
                    rand = Random.Range(0, townhallconvos.Count);
                    dictInitialize.learnWord(" ", "I", townhallconvos[rand], 50);
                    conversation = dictInitialize.scramble(townhallconvos[rand]);
                    return conversation;
                default:
                    return "You should not see this.";
            }
        }
        else
        {
                rand = Random.Range(0, fillerConversations.Count);
                if (isNPC)
                {
                    dictInitialize.learnWord(" ", "I", fillerConversations[rand], interact.wordLearnCap);
                    if (interact.wordLearnCap > 0)
                        interact.wordLearnCap -= 2;
                }
                else if (!isNPC)
                {
                    if (mainvars.currentTask)
                    {
                        conversation = dictInitialize.scramble(YouShouldntNeedMeRightNow[0]);
                        return conversation;
                    }
                    else
                    {
                        dictInitialize.learnWord(" ", "I", fillerConversations[rand], interactWith.wordLearnCap);
                        if (interactWith.wordLearnCap > 0)
                            interactWith.wordLearnCap -= 2;
                    }
                }
                conversation = dictInitialize.scramble(fillerConversations[rand]);
                return conversation;
                  
        }
    }

	void Start () {
        mainvars = mainCharacter.GetComponent<mainCharacterVars>();
        dictInitialize = mainScriptMan.GetComponent<dictInitialize>();
        interact = GetComponent<interact>();
        interactWith = GetComponent<interactWith>();
        oneperday = dayNight.dayCount;
	}
}
