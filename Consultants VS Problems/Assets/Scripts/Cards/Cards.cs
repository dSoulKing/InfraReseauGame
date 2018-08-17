using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour {

    public GameObject zone;
    public int typeCard;

    private bool inGame = false;
    private bool inHand = true;

    public bool InGame
    {
        get
        {
            return inGame;
        }

        set
        {
            inGame = value;
        }
    }

    public bool InHand
    {
        get
        {
            return inHand;
        }

        set
        {
            inHand = value;
        }
    }

    private void Start()
    {
        //if (typeCard == 1)
        //    zone = GameController.instance.zoneCons;
        //else if (typeCard == 2)
        //    zone = GameController.instance.zoneCom;
        //else if (typeCard == 3)
        //    zone = GameController.instance.zoneRc;
    }

    private void OnMouseDown()
    {
        if (!inGame)
        {
            if (GameController.cardClicking != null)
                //GameController.cardClicking.GetComponent<Cards>().zone.SetActive(false);
                GameObject.Find("Cercles").SetActive(false);

            if (GameController.cardClicking == null)
            {
                gameObject.transform.localScale = new Vector2(0.3f, 0.3f);
                GameController.cardClicking = gameObject;
            }
            else if (GameController.cardClicking == gameObject)
            {
                gameObject.transform.localScale = new Vector2(0.19f, 0.19f);
                GameController.cardClicking = null;
            }
            else
            {
                GameController.cardClicking.transform.localScale = new Vector2(0.19f, 0.19f);
                gameObject.transform.localScale = new Vector2(0.3f, 0.3f);
                GameController.cardClicking = gameObject;
            }


            if (GameController.cardClicking != null)
            {
                GameObject.Find("Cercles").SetActive(true);
            }
            else
                GameObject.Find("Cercles").SetActive(false);
        }
    }
}
