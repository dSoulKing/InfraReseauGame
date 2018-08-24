using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCommercial : MonoBehaviour {
    
    private bool inHand = true;

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
    
    private void OnMouseDown()
    {
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
    }
}
