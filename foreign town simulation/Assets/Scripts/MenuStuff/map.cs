using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour {
    public GameObject playerIcon;
    public GameObject cameraMain;
    public GameObject cameraMap;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("m")){
            cameraMain.active = false;
            cameraMap.active = true;
            playerIcon.active = true;
        }
        else
        {
            cameraMain.active = true;
            cameraMap.active = false;
            playerIcon.active = false;
        }
	}
}
