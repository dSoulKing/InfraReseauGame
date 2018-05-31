using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y_2g3 : MonoBehaviour {

    public GameObject thisCables;
    public Sprite spriteY;
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
        if (angle == 155.5)
        {
            if (RepairManager.Y_2g4)
            {
                spriteRenderer.sprite = spriteY;
                transform.localPosition = new Vector3(6.416f, -0.7f, 0);
                transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);

                RepairManager.Y_2g3 = true;
            }
            else
            {
                spriteRenderer.sprite = spriteG;
                transform.localPosition = new Vector3(6.36557f, -0.6060066f, 0);
                transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
                RepairManager.Y_2g3 = false;
            }
        }
        else
        {
            transform.localScale = new Vector3(1.45f, 1.45f, 1.45f);
            spriteRenderer.sprite = spriteG;
            transform.localPosition = new Vector3(6.36557f, -0.6060066f, 0);

            RepairManager.Y_2g3 = false;
        }

    }

    private void OnMouseDown()
    {
        transform.Rotate(0, 0, -90);
        angle = transform.localEulerAngles.z;
        angle = Math.Round(angle, 1);
        //Debug.Log(angle);
    }
}
