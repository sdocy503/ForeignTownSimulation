using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class marketbuttons : MonoBehaviour , IPointerDownHandler
{

    public string selected;
    public Button button1;
    public Button button2;
    public Button button3;


    void Awake()
    {
        selected = "";
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        selected = this.name;
    }

    public bool BrowseMarket(string Item)
    {
        switch (selected)
        {
            case "breadbutton":
                selected = "bread";
                break;
            case "meatbutton":
                selected = "meat";
                break;
            case "grapesbutton":
                selected = "grapes";
                break;
            default:
                selected = "";
                break;
        }
        Debug.Log(selected);

        if (selected == Item)
        {
            return true;
        }
        else
        {
            return false;
        }



    }
}
