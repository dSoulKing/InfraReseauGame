using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneRecruteur : MonoBehaviour {
    
    private void OnMouseDown()
    {
        GameObject cardClicking = GameController.cardClicking;

        try
        {
            if (cardClicking.tag == "recruteur")
            {
                Destroy(cardClicking);
                cardClicking = null;
                GameController.instance.Draw(2, 2);
            }
        }
        finally
        {
            if (GameController.instance.Occupe[0, 5])
                Debug.Log(GameController.instance.Occupe[0, 5]);
            if (GameController.instance.Occupe[1, 5])
                Debug.Log(GameController.instance.Occupe[1, 5]);
            if (GameController.instance.Occupe[2, 5])
                Debug.Log(GameController.instance.Occupe[2, 5]);
            if (GameController.instance.Occupe[3, 5])
                Debug.Log(GameController.instance.Occupe[3, 5]);
            if (GameController.instance.Occupe[4, 5])
                Debug.Log(GameController.instance.Occupe[4, 5]);
            if (GameController.instance.Occupe[5, 5])
                Debug.Log(GameController.instance.Occupe[5, 5]);
            if (GameController.instance.Occupe[6, 5])
                Debug.Log(GameController.instance.Occupe[6, 5]);
        }
    }
}
