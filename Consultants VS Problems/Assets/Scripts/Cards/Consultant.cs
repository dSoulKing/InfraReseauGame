using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consultant : Cards {

    private int i = 0;
    private int j;

    private float timeMove;
    private float timeTestWin;

    private bool bloc;
    private GameObject problemFight;

    private Animator animator;

    public string type;
    private int vie;

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

    public bool Bloc
    {
        get
        {
            return bloc;
        }

        set
        {
            bloc = value;
        }
    }

    public GameObject ProblemFight
    {
        get
        {
            return problemFight;
        }

        set
        {
            problemFight = value;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        vie = 100;
        timeMove = 10;
        timeTestWin = 1;
        bloc = false;
    }

    private void Update()
    {
        if (InGame)
        {
            timeMove -= Time.deltaTime;
            if (timeMove <= 0)
            {
                StartCoroutine(MoveConsultants());
                timeMove = 5;
            }

            timeTestWin -= Time.deltaTime;
            if (timeTestWin <= 0)
            {
                StartCoroutine(TestWinConsultants());
                timeTestWin = 1;
            }

            if (vie <= 0)
            {
                GameController.Occupe[i, j] = false;
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator MoveConsultants()
    {
        if (i < 6)
        {
            if (!GameController.Occupe[i + 1, j])
            {
                gameObject.transform.Translate(0, 1.05f, 0);
                GameController.Occupe[i, j] = false;
                i++;
                GameController.Occupe[i, j] = true;
            }
            else
            {
                GameObject problemFightTest = GameController.instance.TestToFight(i, j);
                if (problemFightTest != null)
                {
                    bloc = true;
                    problemFight = problemFightTest;
                }
            }
        }

        yield break;
    }

    private IEnumerator TestWinConsultants()
    {
        if (i == 6)
        {
            animator.SetTrigger("DisapearConsultant");
            GameController.instance.MissionUp();
            GameController.Occupe[i, j] = false;
            GameController.instance.UpdateListConsultants();
            Destroy(gameObject, 1.66f);
        }

        yield break;
    }

}
