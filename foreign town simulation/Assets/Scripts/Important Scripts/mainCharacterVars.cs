using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacterVars : MonoBehaviour {
    public bool currentTask = false; //Whether you have a task or not
    public bool currentTaskIsHard = false;
    public string taskItem; //Your task item
    public static int taskXP = 0; //number of tasks you have done
    public static int money = 0;
    public bool almostdone = false;
}
