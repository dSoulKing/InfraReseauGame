﻿using System;
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

    private void Start()
    {
    }

    private void OnMouseDown()
    {
        if(gameObject.name == "RecruteurZone" || gameObject.name == "CommercialZone")
        {
            GameObject cardClicking = GameController.cardClicking;

            cardClicking.transform.position = gameObject.transform.position;
            cardClicking.transform.localScale = new Vector2(0.2f, 0.2f);
            cardClicking.GetComponent<Cards>().InGame = true;

            cardClicking = null;
            parent.SetActive(false);
        }
        else if (!GameController.Occupe[i,j])
        {
            GameObject cardClicking = GameController.cardClicking;
            Consultant consultant = cardClicking.GetComponent<Consultant>();

            cardClicking.transform.position = gameObject.transform.position;
            cardClicking.transform.localScale = new Vector2(0.25f, 0.25f);
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
