using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationCard : MonoBehaviour {

    public float scale;
    public GameObject parent;

    [SerializeField]
    private int i;
    [SerializeField]
    private int j;
    

    private void OnMouseDown()
    {
        GameController.cardClicking.GetComponent<Cards>().InHand = false;
        if (gameObject.name == "RecruteurZone")
        {
            GameObject cardClicking = GameController.cardClicking;

            Destroy(cardClicking);

            cardClicking = null;
        }
        else if (gameObject.name == "CommercialZone")
        {
            GameObject cardClicking = GameController.cardClicking;

            Destroy(cardClicking);
            GameController.timeBoostCom = 15;

            cardClicking = null;
        }
        else if (!GameController.Occupe[i,j])
        {
            GameObject cardClicking = GameController.cardClicking;
            Consultant consultant = cardClicking.GetComponent<Consultant>();

            cardClicking.transform.position = gameObject.transform.position;
            cardClicking.transform.localScale = new Vector2(0.15f, 0.15f);
            cardClicking.GetComponent<Cards>().InGame = true;

            consultant.gameObject.transform.parent = GameController.instance.listConsultants.transform;
            consultant.J = j;
            GameController.consultantsInGame.Add(cardClicking);

            cardClicking = null;
            parent.SetActive(false);
            GameController.Occupe[i,j] = true;
        }
    }
}
