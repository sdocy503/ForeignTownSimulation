using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStatics : MonoBehaviour {

    public void Reset()
    {
        dayNight.dayCount = 1;
        dictInitialize.previousdict = false;
        mainCharacterVars.money = 0;
        mainCharacterVars.taskXP = 0;
        dayNight.selectedtutorial = false;
        dayNight.inBed = false;
        dayNight.tutorialmode = false;
        dayNight.enteredasign = false;
        dayNight.lockmovement = false;
    }
}
