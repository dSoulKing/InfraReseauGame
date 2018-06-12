﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_1g1 : MonoBehaviour {

    public GameObject thisCables;
    public Sprite spriteR;
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
        if (angle == 245.5)
        {
            if (RepairManager.R_2g1)
            {
                spriteRenderer.sprite = spriteR;
                transform.localPosition = new Vector3(-2.963f, 2.026f, 0);
                transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);

                RepairManager.R_1g1 = true;
            }
            else
            {
                spriteRenderer.sprite = spriteG;
                transform.localPosition = new Vector3(-2.891144f, 2.124877f, 0);
                transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
                RepairManager.R_1g1 = false;
            }
        }
        else
        {
            transform.localScale = new Vector3(1.45f, 1.45f, 1.45f);
            spriteRenderer.sprite = spriteG;
            transform.localPosition = new Vector3(-2.891144f, 2.124877f, 0);

            RepairManager.R_1g1 = false;
        }

    }

    private void OnMouseDown()
    {
        transform.Rotate(0, 0, 90);
        angle = transform.localEulerAngles.z;
        angle = Math.Round(angle, 1);
    }
}