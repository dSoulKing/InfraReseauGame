﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_7g1 : MonoBehaviour {

    public GameObject thisCables;
    public Sprite spriteB;
    public Sprite spriteG;

    private SpriteRenderer spriteRenderer;
    private Vector3 petit;
    private Vector3 grand;
    private int randomRotation;
    private double angle;

    void Start()
    {
        spriteRenderer = thisCables.GetComponent<SpriteRenderer>();

        randomRotation = UnityEngine.Random.Range(1, 4);
        switch (randomRotation)
        {
            case 2:
                transform.Rotate(0, 0, 90);
                break;
            case 3:
                transform.Rotate(0, 0, 90);
                transform.Rotate(0, 0, 90);
                break;
            case 4:
                transform.Rotate(0, 0, 90);
                transform.Rotate(0, 0, 90);
                transform.Rotate(0, 0, 90);
                break;
        }

        angle = transform.localEulerAngles.z;
        angle = Math.Round(angle, 1);
    }

    void Update()
    {
        if (angle == 245.5f)
        {
            if (RepairManager.B_2g1 && RepairManager.B_1g1 && RepairManager.B_2g4)
            {
                spriteRenderer.sprite = spriteB;
                transform.localPosition = new Vector3(-5.379f, 0.496f, 0);
                transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);

                RepairManager.B_7g1 = true;
            }
            else
            {
                spriteRenderer.sprite = spriteG;
                transform.localPosition = new Vector3(-5.528656f, 0.4906723f, 0);
                transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
                RepairManager.B_7g1 = false;
            }
        }
        else
        {
            transform.localScale = new Vector3(1.54f, 1.54f, 1.54f);
            spriteRenderer.sprite = spriteG;
            transform.localPosition = new Vector3(-5.528656f, 0.4906723f, 0);

            RepairManager.B_7g1 = false;
        }

    }

    private void OnMouseDown()
    {
        transform.Rotate(0, 0, 90);
        angle = transform.localEulerAngles.z;
        angle = Math.Round(angle, 1);
    }
}
