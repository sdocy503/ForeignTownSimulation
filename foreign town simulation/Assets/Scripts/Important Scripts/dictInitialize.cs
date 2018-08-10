using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Word  {
    public string engWord;
    public string scrambledWord;
    public int unlocked = 0;
}
                                                                      
public class dictInitialize : MonoBehaviour {                             
    public bool unlockedAllWords = false;
    public static int wordsLeftToUnlock;
    public GameObject translator;
    public static bool previousdict;

    npcGiveTask givetask1; npcGiveTask givetask2; npcGiveTask givetask3; npcGiveTask givetask4;
    npcfriendship friend1; npcfriendship friend2; npcfriendship friend3; npcfriendship friend4;
    public GameObject npc1; public GameObject npc2; public GameObject npc3; public GameObject npc4;



    //notification variables
    public Text Wordlearned1; public Text Wordlearned2; public bool textOnScreen; float timeonscreen = 1.0f;

    public Text win;
    load mainMenu = new load();

    public static List<Word> gameDict = new List<Word>();
    public static List<char> alphabet = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

    public int searchDict(string query) {
        int toReturn = 0;
        for (int i = 0; i < gameDict.Count; i++) {
            if (gameDict[i].engWord == query) { 
                toReturn = i;
                break;
            }
        }
        return toReturn;
    }

    public string scramble(List<string> scrambleIt) {
        List<string> scrambled = new List<string> { };
        int placeInDict;
        for(int i=0; i < scrambleIt.Count; i++) {
            placeInDict = searchDict(scrambleIt[i]);
            if (gameDict[placeInDict].unlocked == 100)
                scrambled.Add(gameDict[placeInDict].engWord);
            else
                scrambled.Add(gameDict[placeInDict].scrambledWord);
        }
        string scrambledString = string.Join(string.Empty, scrambled.ToArray());
        return scrambledString;
    }

    public void learnWord(string important1, string important2, List<string> totalText, int coefOfDif) {     

        int important1Place = searchDict(important1);
        int important2Place = searchDict(important2);
        int rand;
        if (!unlockedAllWords) {
            if (gameDict[important1Place].unlocked < 100 && gameDict[important2Place].unlocked < 100) {
                wordsLeftToUnlock--;
                rand = Random.Range(0, 1);
                if (rand == 0) {
                    gameDict[important1Place].unlocked = 100;
                    wordsLeftToUnlock--;

                    Wordlearned1.enabled = true;
                    Wordlearned2.enabled = true;
                    textOnScreen = true;
                    Wordlearned2.text = gameDict[important1Place].engWord;
                }
                else {
                    gameDict[important2Place].unlocked = 100;
                    wordsLeftToUnlock--;

                    Wordlearned1.enabled = true;
                    Wordlearned2.enabled = true;
                    textOnScreen = true;
                    Wordlearned2.text = gameDict[important2Place].engWord;
                }
            }
            else if (gameDict[important1Place].unlocked < 100) {
                gameDict[important1Place].unlocked = 100;

                Wordlearned1.enabled = true;
                Wordlearned2.enabled = true;
                textOnScreen = true;
                Wordlearned2.text = gameDict[important1Place].engWord;
                wordsLeftToUnlock--;
            }
            else if (gameDict[important2Place].unlocked < 100) {
                gameDict[important2Place].unlocked = 100;
                wordsLeftToUnlock--;

                Wordlearned1.enabled = true;
                Wordlearned2.enabled = true;
                textOnScreen = true;
                Wordlearned2.text = gameDict[important2Place].engWord;
            }
            else {
                for (int i = 0; i < totalText.Count; i++) {
                    if (gameDict[searchDict(totalText[i])].unlocked < 100) {
                        gameDict[searchDict(totalText[i])].unlocked += coefOfDif;
                        if (gameDict[searchDict(totalText[i])].unlocked >= 100) {
                            gameDict[searchDict(totalText[i])].unlocked = 100;
                            wordsLeftToUnlock--;

                            Wordlearned1.enabled = true;
                            Wordlearned2.enabled = true;
                            textOnScreen = true;
                            Wordlearned2.text = gameDict[searchDict(totalText[i])].engWord;
                        }
                        break;
                    }
                }
            }
            if (gameDict[searchDict("a")].unlocked == 100 && gameDict[searchDict("an")].unlocked < 100)
                gameDict[searchDict("an")].unlocked = 100;
            else if (gameDict[searchDict("an")].unlocked == 100 && gameDict[searchDict("a")].unlocked < 100)
                gameDict[searchDict("a")].unlocked = 100;

            if (gameDict[searchDict("ing")].unlocked == 100) {
                if (gameDict[searchDict("come")].unlocked == 100 && gameDict[searchDict("coming")].unlocked < 100)
                    gameDict[searchDict("coming")].unlocked = 100;
                if (gameDict[searchDict("have")].unlocked == 100 && gameDict[searchDict("having")].unlocked < 100)
                    gameDict[searchDict("having")].unlocked = 100;
            }

            unlockedAllWords = true;
            for (int i = 0; i < gameDict.Count; i++) {
                if (gameDict[i].unlocked < 100) {
                    unlockedAllWords = false;
                    break;
                }
            }
        }
    }

    void Start(){


        int letter;
        win.enabled = false;
        Wordlearned1.enabled = false;
        textOnScreen = false;

        gameDict = new List<Word>();

        Debug.Log(previousdict.ToString());

        if (previousdict != true)
        {
            List<string> scrambling = new List<string>();

            List<string> engDict = new List<string> { " ", "task", ",", "?", "!", "market", "I", "no", "easy", "hard", ".", "more", "grape", "olive", "tomato", "money", "deliver", "or", "for", "buy", "bank", "ing", "meat", "bread", "from", "the", "need", "bring", "this", "mail", "food", "to", "carrier", "friend", "my", "picnic", "one", "up", "coming", "right", "get", "pizza", "with", "and", "me", "you", "here", "like", "thank", "sorry", "deposit", "that", "not", "what", "want", "have", "today", "weather", "nice", "it", "birthday", "are", "how", "took", "too", "long", "is", "having", "a", "an", "later", "just", "busy", "am", "tired", "do", "think", "we", "live", "in", "simulation", "town", "mayor", "post office", "apartment", "be", "these", "good", "alley", "town hall", "document", "s", "hey", "buddy", "where"};

            for (int i = 0; i < engDict.Count; i++)
            {
                Word newWord = new Word();

                newWord.engWord = engDict[i];

                for (int j = 0; j < engDict[i].Length; j++)
                {
                    letter = Random.Range(0, 25);
                    scrambling.Add(alphabet[letter].ToString());
                }
                newWord.scrambledWord = string.Join(string.Empty, scrambling.ToArray());
                newWord.unlocked = 0;
                if (newWord.scrambledWord == "fuck" || newWord.scrambledWord == "shit")
                {
                    i--;
                    newWord = null;
                    Debug.Log("profanity avoided");
                }
                else
                {
                    gameDict.Add(newWord);
                    scrambling.Clear();
                }
            }

            wordsLeftToUnlock = gameDict.Count;

            for (int i = 0; i < 12; i++)
            {
                gameDict[i].unlocked = 100;
                wordsLeftToUnlock--;
            }
        }
        else
        {
            friend1 = npc1.GetComponent<npcfriendship>(); friend2 = npc2.GetComponent<npcfriendship>(); friend3 = npc3.GetComponent<npcfriendship>(); friend4 = npc4.GetComponent<npcfriendship>();
            givetask1 = npc1.GetComponent<npcGiveTask>(); givetask2 = npc2.GetComponent<npcGiveTask>(); givetask3 = npc3.GetComponent<npcGiveTask>(); givetask4 = npc4.GetComponent<npcGiveTask>();

            friend1.FriendLevel = LoadGame.npc1friendlevel; friend2.FriendLevel = LoadGame.npc2friendlevel; friend3.FriendLevel = LoadGame.npc3friendlevel; friend4.FriendLevel = LoadGame.npc4friendlevel;
            givetask1.dayCount = LoadGame.npc1daycount; givetask2.dayCount = LoadGame.npc2daycount; givetask3.dayCount = LoadGame.npc3daycount; givetask4.dayCount = LoadGame.npc4daycount;

            gameDict.AddRange(LoadGame.tempdict);
            wordsLeftToUnlock = LoadGame.tempwordstounlock;
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.U)) {
            for (int i = 0; i < gameDict.Count; i++) { gameDict[i].unlocked = 100; }
            unlockedAllWords = false;
            wordsLeftToUnlock = 1;
            translator.SetActive(false);

        } //Unlock all words cheat
        if (textOnScreen)
        {
            timeonscreen -= Time.deltaTime;

            if (timeonscreen <= 0.0f)
            {
                textOnScreen = false;
                Wordlearned1.enabled = false;
                Wordlearned2.enabled = false;
                timeonscreen = 1.0f;

                if (unlockedAllWords)
                {
                    //calculate score
                    int timescore; int friendshipscore; int moneyscore; int totalscore;

                    timescore = (100 - dayNight.dayCount);
                    friendshipscore = (friend1.FriendLevel + friend2.FriendLevel + friend3.FriendLevel + friend4.FriendLevel);
                    moneyscore = (mainCharacterVars.money * 2);

                    totalscore = (timescore + friendshipscore + moneyscore);

                    win.enabled = true;
                    win.text += "\n\nYour score: " + totalscore.ToString();
                    if (Input.GetKey(KeyCode.Escape))
                    {
                        mainMenu.Click("menu");
                    }
                }
            }
        }
    }
}
