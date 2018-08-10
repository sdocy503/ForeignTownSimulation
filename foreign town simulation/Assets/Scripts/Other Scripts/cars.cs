using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cars : MonoBehaviour {
    public bool otherWay;
    Rigidbody2D rip;
    BoxCollider2D pir;
	// Use this for initialization
	void Start () {
        rip = gameObject.GetComponent<Rigidbody2D>();
        rip.Sleep();
        pir = gameObject.GetComponent<BoxCollider2D>();
        pir.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey("`") && Input.GetKeyDown("0")){
            rip.WakeUp();
            pir.enabled = true;
        }
        StartCoroutine(moveCars());
        if (!otherWay && gameObject.transform.position.x <= -44)
        {
            gameObject.transform.Translate(101, 0, 0);
        }
        else if(otherWay && gameObject.transform.position.x >= 57)
        {
            gameObject.transform.Translate(101, 0, 0);
        }
	}

    IEnumerator moveCars()
    {
        yield return new WaitForSeconds(.1f);
        gameObject.transform.Translate(Time.deltaTime * (-10.0f), 0, 0);
    }
}
