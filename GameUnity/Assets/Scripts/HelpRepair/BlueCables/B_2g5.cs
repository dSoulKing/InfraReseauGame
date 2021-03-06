﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_2g5 : MonoBehaviour {

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
        if (angle == 114.5)
        {
            if (RepairManager.B_3g2)
            {
                spriteRenderer.sprite = spriteB;
                transform.localPosition = new Vector3(-8.95f, 4.413f, 0);
                transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);

                RepairManager.B_2g5 = true;
            }
            else
            {
                spriteRenderer.sprite = spriteG;
                transform.localPosition = new Vector3(-8.906647f, 4.363672f, 0);
                transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);

                RepairManager.B_2g5 = false;
            }
        }
        else
        {
            transform.localScale = new Vector3(1.54f, 1.54f, 1.54f);
            spriteRenderer.sprite = spriteG;
            transform.localPosition = new Vector3(-8.906647f, 4.363672f, 0);

            RepairManager.B_2g5 = false;
        }

    }

    private void OnMouseDown()
    {
        transform.Rotate(0, 0, 90);
        angle = transform.localEulerAngles.z;
        angle = Math.Round(angle, 1);
    }
}
