using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problems : MonoBehaviour {

    private int i = 4;
    private int j;

    private Animator animator;

    public int I
    {
        get
        {
            return i;
        }

        set
        {
            i = value;
        }
    }

    public int J
    {
        get
        {
            return j;
        }

        set
        {
            j = value;
        }
    }

    public string type;
    private int vie;
    private bool alive;

    public Animator Animator
    {
        get
        {
            return animator;
        }

        set
        {
            animator = value;
        }
    }

    public int Vie
    {
        get
        {
            return vie;
        }

        set
        {
            vie = value;
        }
    }

    public bool Alive
    {
        get
        {
            return alive;
        }

        set
        {
            alive = value;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        vie = 100;
        alive = true;
    }
}
