using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tasktimer : MonoBehaviour {

    public bool taskcomplete;
    public bool taskdonefast;
    public bool taskstart;
    public npcfriendship friend;
    public npcGiveTask npctask;
    bool notcompletedintime;
    bool donecorrectly;
    public bool wrongitem;

    public float targetTime;

    void Start()
    {
        targetTime = 60.0f;
        taskcomplete = false;
        taskdonefast = false;
        taskstart = false;
        notcompletedintime = false;
        donecorrectly = false;
        wrongitem = false;
    }


    void Update()
    {
        if (taskstart)//is task started, if not this doesnt execute
        {
            targetTime -= Time.deltaTime; //counts down in seconds

            taskcomplete = npctask.completed; //sets a value for task completed

            if (taskcomplete)
            {
                if (dayNight.dayCount == 1) {
                    if (wrongitem)
                    {
                        taskdonefast = false;
                        donecorrectly = false;
                        targetTime = 60.0f;
                        timerEnded();
                    }
                    else
                    {
                        taskdonefast = true;
                        donecorrectly = true;
                        targetTime = 60.0f;
                        timerEnded();
                    }
                }
                else if (targetTime >= 30.0f)
                {
                    if (wrongitem)
                    {
                        taskdonefast = false;
                        donecorrectly = false;
                        timerEnded();
                    }
                    else
                    {
                        taskdonefast = true;
                        donecorrectly = true;
                        timerEnded();
                    }
                }
                else if (targetTime <= 0.0f)
                {
                    timerEnded();
                }
                else if (targetTime > 0.0f && targetTime < 30.0f)
                {
                    donecorrectly = true;
                    timerEnded();
                }
            }
        }
    }

    public void timerEnded()//updates friend level and resets vars
    {
        friend.UpdateFriendLevel(donecorrectly, taskdonefast);
        taskstart = false;
        taskcomplete = false;
        taskdonefast = false;
        donecorrectly = false;
        wrongitem = false;
        targetTime = 60.0f;
    }
}

