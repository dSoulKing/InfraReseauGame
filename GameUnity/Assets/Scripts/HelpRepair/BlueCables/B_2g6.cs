using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_2g6 : MonoBehaviour {

    public GameObject thisCables;
    public Sprite spriteB;
    public Sprite spriteG;

    private SpriteRenderer spriteRenderer;
    private Vector3 petit;
    private Vector3 grand;
    private int randomRotation;

    void Start()
    {
        spriteRenderer = thisCables.GetComponent<SpriteRenderer>();

        randomRotation = Random.Range(1, 4);
        switch (randomRotation)
        {
            case 2:
                transform.Rotate(0, 0, -90);
                break;
            case 3:
                transform.Rotate(0, 0, -90);
                transform.Rotate(0, 0, -90);
                break;
            case 4:
                transform.Rotate(0, 0, -90);
                transform.Rotate(0, 0, -90);
                transform.Rotate(0, 0, -90);
                break;
        }
    }

    void Update()
    {
        if (transform.localEulerAngles.z == 245.5)
        {
            if (RepairManager.B_3g2)
            {
                spriteRenderer.sprite = spriteB;
                transform.localPosition = new Vector3(-10.707f, 0.553f, 0);
                transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);

                RepairManager.B_2g6 = true;
            }
            else
            {
                spriteRenderer.sprite = spriteG;
                transform.localPosition = new Vector3(-10.63763f, 0.5566723f, 0);
                transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
                RepairManager.B_2g6 = false;
            }
        }
        else
        {
            transform.localScale = new Vector3(1.54f, 1.54f, 1.54f);
            spriteRenderer.sprite = spriteG;
            transform.localPosition = new Vector3(-10.63763f, 0.5566723f, 0);

            RepairManager.B_2g6 = false;
        }

    }

    private void OnMouseDown()
    {
        transform.Rotate(0, 0, -90);
    }
}
