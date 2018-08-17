using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problems : MonoBehaviour {

    private int i = 6;
    private int j;

    private float timeMove;
    private float timeTestWin;

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
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        vie = 100;
        timeMove = 5;
        timeTestWin = 1;
    }

    private void Update()
    {
        timeMove -= Time.deltaTime;
        if (timeMove <= 0)
        {
            StartCoroutine(MoveProblem());
            timeMove = 5;
        }

        timeTestWin -= Time.deltaTime;
        if (timeTestWin <= 0)
        {
            StartCoroutine(TestLoseProblems());
            timeTestWin = 1;
        }

        if (vie <= 0)
        {
            GameController.Occupe[i, j] = false;
            Destroy(gameObject);
        }
    }

    private IEnumerator MoveProblem()
    {
        if (i > 0)
        {
            if (!GameController.Occupe[i - 1, j])
            {
                gameObject.transform.Translate(0, -1.05f, 0);
                GameController.Occupe[i, j] = false;
                i--;
                GameController.Occupe[i, j] = true;
            }
            //else
            //{
            //    foreach (GameObject consultant in consultantsInGame)
            //    {
            //        Problems consultantScript = consultant.GetComponent<Problems>();
            //        if (consultantScript.I == problemScript.I - 1 && consultantScript.J == problemScript.J)
            //        {
            //            StartCoroutine(Fight(consultant, problem));
            //        }
            //    }
            //}
        }

        yield break;
    }

    private IEnumerator TestLoseProblems()
    {
        if (i == 0)
        {
            animator.SetTrigger("DisapearConsultant");
            GameController.instance.LifeDown();
            GameController.Occupe[i, j] = false;
            GameController.instance.UpdateListProblems();
            Destroy(gameObject, 1.66f);
        }

        yield break;
    }
}
