using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour {
    //public string a;
 
	// Use this for initialization
	void Start () {
		
	}

    public void Click(string a)
    {
        dictInitialize.gameDict = new List<Word>();
        SceneManager.LoadScene(a);
    }

    public void ClickYes(string a)
    {
        dayNight.selectedtutorial = true;
        dictInitialize.gameDict = new List<Word>();
        SceneManager.LoadScene(a);
    }
    public void ClickNo(string a)
    {
        dayNight.selectedtutorial = false;
        dictInitialize.gameDict = new List<Word>();
        SceneManager.LoadScene(a);
    }
}
