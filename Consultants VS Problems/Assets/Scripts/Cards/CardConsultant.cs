using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardConsultant : MonoBehaviour {

    private GameObject zoneParent;
    private Transform[] zone;

    private bool inGame = false;
    private bool inHand = true;

    public bool InGame
    {
        get
        {
            return inGame;
        }

        set
        {
            inGame = value;
        }
    }

    public bool InHand
    {
        get
        {
            return inHand;
        }

        set
        {
            inHand = value;
        }
    }


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
        
        zoneParent = GameObject.FindWithTag("Cercles");
        zone = zoneParent.GetComponentsInChildren<Transform>(true);
    }

    private void OnMouseDown()
    {
        if (!inGame)
        {
            //if (GameController.cardClicking != null)
            //    //GameController.cardClicking.GetComponent<Cards>().zone.SetActive(false);
            //    //zone.SetActive(false);

            if (GameController.cardClicking == null)
            {
                gameObject.transform.localScale = new Vector2(0.3f, 0.3f);
                GameController.cardClicking = gameObject;
            }
            else if (GameController.cardClicking == gameObject)
            {
                gameObject.transform.localScale = new Vector2(0.19f, 0.19f);
                GameController.cardClicking = null;
            }
            else
            {
                GameController.cardClicking.transform.localScale = new Vector2(0.19f, 0.19f);
                gameObject.transform.localScale = new Vector2(0.3f, 0.3f);
                GameController.cardClicking = gameObject;
            }


            if (GameController.cardClicking != null)
                foreach (Transform cercle in zone)
                    cercle.gameObject.SetActive(true);
            else
                foreach (Transform cercle in zone)
                    cercle.gameObject.SetActive(false);
        }
    }





    private void Update()
    {
        if (inGame)
        {
            timeMove -= Time.deltaTime;
            timeTestWin -= Time.deltaTime;

            if (timeMove <= 0)
            {
                StartCoroutine(MoveConsultants());
                timeMove = 5;
            }

            if (timeTestWin <= 0)
            {
                StartCoroutine(TestWinConsultants());
                timeTestWin = 1;
            }

            if (vie <= 0)
            {
                GameController.instance.Occupe[i, j] = false;
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator MoveConsultants()
    {
        if (i < 6)
        {
            if (!GameController.instance.Occupe[i + 1, j])
            {
                gameObject.transform.Translate(0, 1.05f, 0);
                GameController.instance.Occupe[i, j] = false;
                i++;
                GameController.instance.Occupe[i, j] = true;
            }
            else
            {
                GameController.instance.UpdateListProblems();
                GameObject problemFightTest = GameController.instance.TestToFight(i, j);
                if (problemFightTest != null)
                    StartCoroutine(GameController.instance.Fight(gameObject, problemFightTest));
            }
        }

        yield break;
    }

    private IEnumerator TestWinConsultants()
    {
        if (i == 6)
        {
            GameController.instance.Occupe[i, j] = false;
            animator.SetTrigger("DisapearConsultant");
            GameController.instance.MissionUp();
            GameController.instance.UpdateListConsultants();
            Destroy(gameObject, 1.66f);
        }

        yield break;
    }

    public void EndGameTimer()
    {
        timeMove = 50000;
        timeTestWin = 50000;
    }

    public void Lose()
    {
        animator.SetTrigger("explosionConsultant");
        Destroy(gameObject, 0.35f);
    }
}
