using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour {

    public GameObject zone;

    private bool inGame = false;

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

    public GameObject Zone
    {
        get
        {
            return zone;
        }

        set
        {
            zone = value;
        }
    }
    

    private void OnMouseDown()
    {
        if (!inGame)
        {
            if (GameController.cardClicking != null)
                GameController.cardClicking.GetComponent<Cards>().Zone.SetActive(false);

            if (GameController.cardClicking == null)
            {
                gameObject.transform.localScale = new Vector2(0.3f, 0.3f);
                GameController.cardClicking = gameObject;
            }
            else if (GameController.cardClicking == gameObject)
            {
                gameObject.transform.localScale = new Vector2(0.25f, 0.25f);
                GameController.cardClicking = null;
            }
            else
            {
                GameController.cardClicking.transform.localScale = new Vector2(0.25f, 0.25f);
                gameObject.transform.localScale = new Vector2(0.3f, 0.3f);
                GameController.cardClicking = gameObject;
            }

            if (GameController.cardClicking != null)
            {
                zone.SetActive(true);
            }
            else
                zone.SetActive(false);
        }
    }
}
