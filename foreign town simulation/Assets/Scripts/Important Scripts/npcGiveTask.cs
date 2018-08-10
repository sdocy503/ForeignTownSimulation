using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class task {
    public List<string> prompt;
    public string taskID;
    public string itemRequired;
    public void construct(List<string> promptS, string taskIDS, string itemRequiredS){
        prompt = promptS;
        taskID = taskIDS;
        itemRequired = itemRequiredS;
    }
}

public class npcGiveTask : MonoBehaviour {
    //GameObjects and scripts
    public GameObject mainScriptMan;
    public GameObject mainCharacter;
    public GameObject market;
    public GameObject mailman;
    public GameObject bank;
    public GameObject pizza;
    public GameObject mayor;
    public GameObject shadyCharacter;
    public GameObject taskavailable;
    public GameObject taskinprog;
    public GameObject almostdonestar;

    dictInitialize dictRef;
    mainCharacterVars mainCharacterVars;
    interactWith interactWithMarket;
    interactWith interactWithMailman;
    interactWith interactWithBank;
    interactWith interactWithPizza;
    interactWith interactWithMayor;
    interactWith interactWithShady;
    interact interact;
    npcConversation npcConversation;
    npcfriendship friendship;
    public tasktimer timer;

    public bool taskwiththisNPC; 
    public bool completed;
    public int dayCount = 0;

    //Task prompt strings
    public List<task> easyTaskPrompts = new List<task> {new task(), new task(), new task(), new task()/*, new task(), new task()*/};
    public List<task> hardTaskPrompts = new List<task> {new task(), new task(), new task(), new task(), new task(), new task()};

    List<string> noTaskDialogue = new List<string> { "sorry", " ", "I", " ", "have", " ", "no", " ", "more", " ", "task", "s", " ", "for", " ", "you", " ", "today", "." };
    public task taskPrompt = new task();
    string taskDialogue;

    //Function, gives a task, returns NPC dialogue
    public string scrambleTask(int difficulty, int randTask){ //1 is easy, 2 is hard
        //if (mainCharacterVars.currentTask == false && dayCount < dayNight.dayCount) { //if mainCharacter has no task
        taskwiththisNPC = true;

		completed = false;
        timer.taskstart = true;
        if (dayCount + 1 < dayNight.dayCount) {
            dayCount = dayNight.dayCount - 1;
        }
        mainCharacterVars.currentTask = true;

        if (difficulty == 1) //Sets taskPrompt to a random task from the lists
            taskPrompt = easyTaskPrompts[randTask];
        else
            taskPrompt = hardTaskPrompts[randTask];
        taskDialogue = dictRef.scramble(taskPrompt.prompt);

        interact.taskItemReq = taskPrompt.itemRequired; //Sets what you need for the task in interact

        if (taskPrompt.taskID == "market") { //Turns on the correct GameObject that you need for the task
            interactWithMarket.whatYouNeed = taskPrompt.itemRequired;
            interactWithMarket.taskmode = true;
            mainCharacterVars.currentTaskIsHard = true;
        }
        else if (taskPrompt.taskID == "pizza") {
            interactWithPizza.whatYouNeed = taskPrompt.itemRequired;
            interactWithPizza.taskmode = true;
            mainCharacterVars.currentTaskIsHard = true;
        }
        else if (taskPrompt.taskID == "post office") {
           interactWithMailman.whatYouNeed = taskPrompt.itemRequired;
           interactWithMailman.taskmode = true;
        }
        else if (taskPrompt.taskID == "bank") {
            interactWithBank.whatYouNeed = taskPrompt.itemRequired;
            interactWithBank.taskmode = true;
        }
        else if (taskPrompt.taskID == "town hall") {
            interactWithMayor.whatYouNeed = taskPrompt.itemRequired;
            interactWithMayor.taskmode = true;
        }
        else if (taskPrompt.taskID == "alley") {
            interactWithShady.whatYouNeed = taskPrompt.itemRequired;
            interactWithShady.taskmode = true;
        }
        return taskDialogue;
    }
    public string getNoTask() { //Function, runs if you have a task already
        if (mainCharacterVars.taskItem == interact.taskItemReq && mainCharacterVars.taskItem != "")
        { //If mainCharacter's task is complete

            taskwiththisNPC = false;
            taskinprog.SetActive(false);

            almostdonestar.SetActive(false);
            mainCharacterVars.almostdone = false;

            interactWithBank.taskmode = false;
            interactWithMailman.taskmode = false;
            interactWithMarket.taskmode = false;
            interactWithPizza.taskmode = false;
            interactWithMayor.taskmode = false;
            interactWithShady.taskmode = false;
            completed = true;
            if (timer.targetTime > 0.0f || dayNight.dayCount == 1)
            { //If you did the task fast enough, you learn new words
                taskDialogue = dictRef.scramble(new List<string> { "thank", " ", "you" }); //or what the npc will say after the task is complete/notcomplete
                dictRef.learnWord(taskPrompt.taskID, taskPrompt.itemRequired, taskPrompt.prompt, 100);
                if (mainCharacterVars.currentTaskIsHard) { //You get money if it was a hard task
                    mainCharacterVars.money += Random.Range(friendship.FriendLevel, friendship.FriendLevel + 6);
                    dictRef.learnWord(taskPrompt.taskID, taskPrompt.itemRequired, taskPrompt.prompt, 100);
                }
            }
            else
                taskDialogue = dictRef.scramble(new List<string> { "you", " ", "took", " ", "too", " ", "long", "." }); //or what the npc will say after the task is complete/notcomplete

            dayCount++;

            mainCharacterVars.taskXP++; //taskXP is how many tasks you have done
            mainCharacterVars.currentTask = false; //Clear task-related variables
            mainCharacterVars.currentTaskIsHard = false;
            mainCharacterVars.taskItem = "";
            interact.taskItemReq = "";
            taskPrompt = default(task);
        }
        else if (interact.taskItemReq != "" && mainCharacterVars.taskItem == "" && !interact.seenTaskPrompt) { //If mainCharacter needs to see the task prompt again
            taskDialogue = interact.currentTaskPrompt;
            interact.dialogue.color = Color.red;
            interact.seenTaskPrompt = true;
        }
        else if (dayCount >= dayNight.dayCount && interact.seenNoTasks == false)
        { //If mainCharacter has reached the task limit
            taskDialogue = dictRef.scramble(noTaskDialogue);
            dictRef.learnWord("I", " ", noTaskDialogue, 10);
            interact.seenNoTasks = true;
        }
        else if (interact.taskItemReq == "" || mainCharacterVars.taskItem == "") { //If mainCharacter's task is not complete, or it is with another NPC, or mainCharacter has alread heard that the NPC is out of tasks
            taskDialogue = npcConversation.makeConversation(true);
        }
        else if (mainCharacterVars.taskItem != "" && mainCharacterVars.taskItem != interact.taskItemReq)
        { //If mainCharacter's task is complete but they got the wrong thing
            taskDialogue = dictRef.scramble(new List<string> { "that", " ", "is", " ", "not", " ", "what", " ", "I", " ", "want", "." });
            taskwiththisNPC = false;

            almostdonestar.SetActive(false);
            mainCharacterVars.almostdone = false;

            taskinprog.SetActive(false);

            timer.wrongitem = true;
            completed = true;

           

            dayCount++;

            mainCharacterVars.taskItem = "";
            interact.taskItemReq = "";
            mainCharacterVars.currentTask = false;
            taskPrompt = default(task);
        }
        else //This branch should never occur
            taskDialogue = "you should not see this";

        return taskDialogue;
    }

    void Update()
    {
        if (mainCharacterVars.currentTask)
        {
            taskavailable.SetActive(false);
            if (taskwiththisNPC)
            {
                if (mainCharacterVars.almostdone)
                {
                    almostdonestar.SetActive(true);
                }
                else
                {
                    taskinprog.SetActive(true);
                }
            }          
        }
        else if (!mainCharacterVars.currentTask && dayCount < dayNight.dayCount)
        {           
            taskavailable.SetActive(true);
        }
    }

    void Awake(){
        dictRef = mainScriptMan.GetComponent<dictInitialize>();
        mainCharacterVars = mainCharacter.GetComponent<mainCharacterVars>();
        interact = GetComponent<interact>();
        npcConversation = GetComponent<npcConversation>();
        interactWithMarket = market.GetComponent<interactWith>();
        interactWithMailman = mailman.GetComponent<interactWith>();
        interactWithBank = bank.GetComponent<interactWith>();
        interactWithPizza = pizza.GetComponent<interactWith>();
        interactWithMayor = mayor.GetComponent<interactWith>();
        interactWithShady = shadyCharacter.GetComponent<interactWith>();
        friendship = GetComponent<npcfriendship>();

        easyTaskPrompts[0].construct(new List<string> { "bring", " ", "this", " ", "mail", " ", "to", " ", "the", " ", "post office" }, "post office", "mail");
        easyTaskPrompts[1].construct(new List<string> { "bring", " ", "this", " ", "money", " ", "to", " ", "the", " ", "bank" }, "bank", "money");
        easyTaskPrompts[2].construct(new List<string> { "bring", " ", "this", " ", "document", " ", "to", " ", "the", " ", "town hall" }, "town hall", "document");
        easyTaskPrompts[3].construct(new List<string> { "bring", " ", "these", " ", "good", "s", " ", "to", " ", "the", " ", "alley" }, "alley", "good");
        
        //mediTaskPrompts[0].construct(new List<string> { "tell", " ", "me", " ", "where", " ", "you", " ", "are", " ", "from" }, "currentNPC", "whereFrom");
        hardTaskPrompts[0].construct(new List<string> { "I", " ", "need", " ", "meat", " ", "from", " ", "the", " ", "market" }, "market", "meat");
        hardTaskPrompts[1].construct(new List<string> { "I", " ", "need", " ", "bread", " ", "from", " ", "the", " ", "market" }, "market", "bread");
        hardTaskPrompts[2].construct(new List<string> { "I", " ", "need", " ", "grape", "s", " ", "from", " ", "the", " ", "market" }, "market", "grape");
        hardTaskPrompts[3].construct(new List<string> { "get", " ", "me", " ", "a", " ", "pizza", " ", "with", " ", "meat" }, "pizza", "meat");
        hardTaskPrompts[4].construct(new List<string> { "get", " ", "me", " ", "a", " ", "pizza", " ", "with", " ", "tomato" }, "pizza", "tomato");
        hardTaskPrompts[5].construct(new List<string> { "get", " ", "me", " ", "a", " ", "pizza", " ", "with", " ", "olive", "s" }, "pizza", "olive");

        //hardTaskPrompts[0].construct(new List<string> { "tell", " ", "him", " ", "to", " ", "come", " ", "over", " ", "here" }, "otherNPC", "come");
        taskavailable.SetActive(false);
        taskwiththisNPC = false;
        taskinprog.SetActive(false);
        completed = false;
        almostdonestar.SetActive(false);
    }
}