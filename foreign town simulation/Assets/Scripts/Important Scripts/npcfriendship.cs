using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcfriendship : MonoBehaviour {

    public int FriendLevel;
    public GameObject happy;
    public GameObject neutral;
    public GameObject sad;
    public float imagetime = 4.0f;
    bool needtoshowimage;

    public void UpdateFriendLevel(bool completedtask, bool fasttask)
    {
        int gained = 0;//amt gained after task.

        Debug.Log("Completed: " + completedtask.ToString() + ". Fast: " + fasttask.ToString());
        if (fasttask)
        {
            FriendLevel += 1; gained += 1;
        }
        if (completedtask)
        {
            FriendLevel += 1; gained += 1;
        }
        else if (!completedtask)
        {
            FriendLevel -= 1; gained -= 1;
        }
        if (completedtask && fasttask)
        {
            FriendLevel += 1; gained += 1;
        }

        if (gained == 0)
        {
            neutral.SetActive(true);
        }
        else if (gained > 0)
        {
            happy.SetActive(true);
        }
        else if (gained < 0)
        {
            sad.SetActive(true);
            
        }
        needtoshowimage = true;

    }
 
    // Use this for initialization
	void Awake () {
        FriendLevel = 0;
        happy.SetActive(false);
        neutral.SetActive(false);
        sad.SetActive(false);
    }
	
    void Update ()
    {
        //emoticons show for 4 seconds then disappear
        if (needtoshowimage)
        {
            imagetime -= Time.deltaTime;

            if (imagetime <= 0.0f)
            {
                happy.SetActive(false);
                neutral.SetActive(false);
                sad.SetActive(false);
                imagetime = 4.0f;
                needtoshowimage = false;
            }
        }
    }


}
