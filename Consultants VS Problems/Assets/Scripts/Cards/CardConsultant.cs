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

    private GameObject electricFightObject;

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

    public GameObject ElectricFightObject
    {
        get
        {
            return electricFightObject;
        }

        set
        {
            electricFightObject = value;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        vie = 100;
        timeMove = 4;
        timeTestWin = 1;
        bloc = false;

        zoneParent = GameController.instance.cerclesZone;/*GameObject.FindWithTag("Cercles");*/
        //zone = zoneParent.GetComponentsInChildren<Transform>(true);
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
                zoneParent.SetActive(true);/*foreach (Transform cercle in zone)
                    cercle.gameObject.SetActive(true);*/
            else
                zoneParent.SetActive(false);/*foreach (Transform cercle in zone)
                    cercle.gameObject.SetActive(false);*/
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
                timeMove = 3;
            }

            if (timeTestWin <= 0)
            {
                StartCoroutine(TestWinConsultants());
                timeTestWin = 1;
            }

            if (vie <= 0)
            {
                GameController.instance.Occupe[i, j] = false;
                Destroy(electricFightObject); 
                Destroy(gameObject);
            }
        }
        
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.01f * vie, 0.01f * vie, 0.01f * vie, 1f);
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

                if (gameObject.transform.childCount != 0)
                    Destroy(gameObject.transform.GetChild(0).gameObject);             
            }
            else
            {
                GameController.instance.UpdateListProblems();
                GameObject problemFightTest = GameController.instance.TestToFight(i, j);
                electricFightObject = GameController.instance.electricFightObject;
                if (problemFightTest != null)
                {
                    electricFightObject = Instantiate(electricFightObject, gameObject.transform.position + new Vector3(0, 0.54f, 0), electricFightObject.transform.rotation);
                    electricFightObject.transform.parent = gameObject.transform;
                    StartCoroutine(GameController.instance.Fight(gameObject, problemFightTest));
                }
            }
        }
        else
            yield break;
    }

    private IEnumerator TestWinConsultants()
    {
        if (i == 6)
        {
            GameController.instance.Occupe[i, j] = false;
            animator.SetTrigger("disapearConsultant");
            GameController.instance.MissionUp();
            GameController.instance.UpdateListConsultants();
            Destroy(gameObject, 1.66f);
            i++;
        }
        else
            yield break;
    }
}
