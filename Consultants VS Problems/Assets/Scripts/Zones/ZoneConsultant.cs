using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneConsultant : MonoBehaviour {
    
    public GameObject parent;

    [SerializeField]
    private int i;
    [SerializeField]
    private int j;


    private void OnMouseDown()
    {
        GameObject cardClicking = GameController.cardClicking;
        CardConsultant scriptCons = cardClicking.GetComponent<CardConsultant>();

        if (scriptCons.type == "Infra" || scriptCons.type == "AMOA" || scriptCons.type == "MOE")
            if (!GameController.instance.Occupe[i,j])
            {
                CardConsultant consultant = cardClicking.GetComponent<CardConsultant>();

                cardClicking.transform.position = gameObject.transform.position;
                cardClicking.transform.localScale = new Vector2(0.15f, 0.15f);
                cardClicking.GetComponent<CardConsultant>().InGame = true;

                consultant.gameObject.transform.parent = GameController.instance.listConsultants.transform;
                consultant.J = j;
                GameController.consultantsInGame.Add(cardClicking);
                GameController.instance.Occupe[i, j] = true;

                cardClicking = null;
                for (i = 0; i < parent.transform.childCount; i++)
                {
                    parent.transform.GetChild(i).gameObject.SetActive(false);
                }
                Debug.Log(cardClicking);
            }
    }
}
