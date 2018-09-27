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
        timeMove = 4;
        timeTestWin = 1;
    }

    private void Update()
    {
        timeMove -= Time.deltaTime;
        if (timeMove <= 0)
        {
            StartCoroutine(MoveProblem());
            if (GameController.missionPoints < 40)
                timeMove = 4;
            else if (GameController.missionPoints < 60)
                timeMove = 3;
            else if (GameController.missionPoints < 80)
                timeMove = 2;
            else if (GameController.missionPoints < 100)
                timeMove = 1;
        }

        timeTestWin -= Time.deltaTime;
        if (timeTestWin <= 0)
        {
            StartCoroutine(TestLoseProblems());
            timeTestWin = 1;
        }

        if (vie <= 0)
        {
            GameController.instance.Occupe[i, j] = false;
            Destroy(gameObject);
        }

        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.01f * vie, 0.01f * vie, 0.01f * vie, 1f);
    }

    private IEnumerator MoveProblem()
    {
        if (i > 0 && !GameController.instance.Occupe[i - 1, j])
        {
            gameObject.transform.Translate(0, -1.05f, 0);
            GameController.instance.Occupe[i, j] = false;
            i--;
            GameController.instance.Occupe[i, j] = true;
        }
        else
            yield break;
    }

    private IEnumerator TestLoseProblems()
    {
        if (i == 0)
        {
            animator.SetTrigger("explosionProblem");
            GameController.instance.LifeDown();
            GameController.instance.Occupe[i, j] = false;
            GameController.instance.UpdateListProblems();
            Destroy(gameObject,0.35f);
        }
        else
            yield break;
    }

    public void EndGameTimer(bool win)
    {
        timeMove = 50000;
        timeTestWin = 50000;
        if (win)
        {
            animator.SetTrigger("DisapearProblem");
            Destroy(gameObject, 1.66f);
        }
        else
        {
            animator.SetTrigger("explosionProblem");
            Destroy(gameObject, 0.35f);
        }
    }
}
