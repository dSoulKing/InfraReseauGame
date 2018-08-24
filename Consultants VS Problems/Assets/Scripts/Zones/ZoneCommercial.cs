using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCommercial : MonoBehaviour {

    private void OnMouseDown()
    {
        GameObject cardClicking = GameController.cardClicking;

        try
        {
            if (cardClicking.tag == "commercial")
            {
                Destroy(cardClicking);
                GameController.timeBoostCom = 15;
                cardClicking = null;
            }
        }
        catch { }
    }
}
