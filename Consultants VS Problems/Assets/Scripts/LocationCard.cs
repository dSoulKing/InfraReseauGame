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

    private void Start()
    {
    }

    private void OnMouseDown()
    {
        if(gameObject.name == "RecruteurZone" || gameObject.name == "CommercialZone")
        {
            GameController.cardClicking.transform.position = gameObject.transform.position;
            GameController.cardClicking.transform.localScale = new Vector2(0.2f, 0.2f);
            GameController.cardClicking.GetComponent<Cards>().InGame = true;

            GameController.cardClicking = null;
            parent.SetActive(false);
        }
        else if (!GameController.Occupe[i,j])
        {
            GameController.cardClicking.transform.position = gameObject.transform.position;
            GameController.cardClicking.transform.localScale = new Vector2(0.25f, 0.25f);
            GameController.cardClicking.GetComponent<Cards>().InGame = true;

            GameController.cardClicking.GetComponent<Consultant>().J = j;
            GameController.consultantsInGame.Add(GameController.cardClicking);

            GameController.cardClicking = null;
            parent.SetActive(false);
            GameController.Occupe[i,j] = true;
        }
    }
}
