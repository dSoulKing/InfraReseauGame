﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToSetUp1 : MonoBehaviour {

    public SpriteRenderer chargement;
    public Sprite c0;
    public Sprite c12;
    public Sprite c25;
    public Sprite c37;
    public Sprite c50;
    public Sprite c62;
    public Sprite c75;
    public Sprite c87;
    public Sprite c100;

    public GameObject thisSetUp;

    private int i = 1;
    private Sprite[] spriteTab;
    private bool wPlus;

    private void Start()
    {
        spriteTab = new Sprite[] {c0, c12, c25, c37, c50, c62, c75, c87, c100};
        wPlus = true;
    }

    private void OnMouseDown()
    {
        if (i < 9)
        {
            chargement.sprite = spriteTab[i];
            i++;
        }

        if (i == 9)
        {
            if (wPlus)
            {
                GameController.w++;
                wPlus = false;
            }
            Destroy(thisSetUp, 2f);
        }
    }
}
