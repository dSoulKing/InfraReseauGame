using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance;

    public GameObject problem1;
    public GameObject problem2;
    public GameObject problem3;

    public GameObject MOE;
    public GameObject AMOA;
    public GameObject Infra;
    public GameObject Commercial;
    public GameObject Recruteur;

    public GameObject winText;
    public GameObject loseText;

    //public GameObject zoneCons;
    //public GameObject zoneCom;
    //public GameObject zoneRc;

    public GameObject locations;
    public GameObject hand;

    public GameObject listProblems;
    public GameObject listConsultants;

    public static GameObject cardClicking = null;

    public bool[,] Occupe { get; set; }

    public static List<GameObject> consultantsInGame;
    private static List<GameObject> problemsInGame;

    private bool newProbOK = true;
    
    private float timeNewProblem;
    private float timeTestBloc;

    public static float timeBoostCom;

    public static int missionPoints;
    public static int lifePoints;

    private int damageBonus;

    private List<GameObject> handList;

    private string timerComString;
    public GameObject chronoCom;
    private TextMesh timerComText;

    void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
    }

    void Start () {
        Occupe = new bool[7, 6];
        for(int i = 0; i < 7; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                Occupe[i, j] = false;
            }
        }
        

        handList = new List<GameObject>();
        Draw(2, 1);

        consultantsInGame = new List<GameObject>();
        problemsInGame = new List<GameObject>();
        
        timeNewProblem = 5;
        timeTestBloc = 2;

        timeBoostCom = 0;

        missionPoints = 0;
        lifePoints = 100;

        damageBonus = 0;

        StartCoroutine(PositionCards());

        timerComText = chronoCom.GetComponent<TextMesh>();
    }

    private void Update()
    {
        //if(Occupe[6, 0])
        //    Debug.Log(Occupe[6, 0]);
        //if (Occupe[6, 1])
        //    Debug.Log(Occupe[6, 1]);
        //if (Occupe[6, 2])
        //    Debug.Log(Occupe[6, 2]);
        //if (Occupe[6, 3])
        //    Debug.Log(Occupe[6, 3]);
        //if (Occupe[6, 4])
        //    Debug.Log(Occupe[6, 4]);
        //if (Occupe[6, 5])
        //    Debug.Log(Occupe[6, 5]);

        if (newProbOK /*&& problemsInGame.Count < 6*/)
            timeNewProblem -= Time.deltaTime;
        timeTestBloc -= Time.deltaTime;

        if (timeNewProblem <= 0)
        {
            StartCoroutine(NewProblem());
            StartCoroutine(UpdateCaseLibre());
            timeNewProblem = 8;
            Draw(1, 1);
        }

        //if (timeTestBloc <= 0)
        //{
        //    StartCoroutine(TestConsultantsBloc());
        //    timeTestBloc = 2;
        //}

        if (timeBoostCom > 0)
        {
            timeBoostCom -= Time.deltaTime;
            timerComString = timeBoostCom.ToString("F0");
            timerComText.text = timerComString;
            damageBonus = 10;
        }
        else
            damageBonus = 0;
    }
    

    private IEnumerator NewProblem()
    {
        newProbOK = false;
        int randomProb = 0;
        int randomPos = 0;
        GameObject probChoice = null;
        randomProb = UnityEngine.Random.Range(1, 4);
        bool doWhile = false;
        switch (randomProb)
        {
            case 1:
                probChoice = problem1;
                do
                {
                    randomPos = UnityEngine.Random.Range(0, 6);
                    if (!Occupe[6, randomPos])
                    {
                        float xPos = 0;
                        doWhile = true;
                        switch (randomPos)
                        {
                            case 0:
                                xPos = -2.59f;
                                break;
                            case 1:
                                xPos = -1.55f;
                                break;
                            case 2:
                                xPos = -0.51f;
                                break;
                            case 3:
                                xPos = 0.53f;
                                break;
                            case 4:
                                xPos = 1.57f;
                                break;
                            case 5:
                                xPos = 2.61f;
                                break;
                        }
                        probChoice = Instantiate(probChoice, new Vector2(xPos, 4.46f), probChoice.transform.rotation);
                        probChoice.transform.parent = listProblems.transform;
                    }
                } while (!doWhile);
                break;
            case 2:
                probChoice = problem2;
                do
                {
                    randomPos = UnityEngine.Random.Range(0, 6);
                    if (!Occupe[6, randomPos])
                    {
                        float xPos = 0;
                        doWhile = true;
                        switch (randomPos)
                        {
                            case 0:
                                xPos = -2.59f;
                                break;
                            case 1:
                                xPos = -1.55f;
                                break;
                            case 2:
                                xPos = -0.51f;
                                break;
                            case 3:
                                xPos = 0.53f;
                                break;
                            case 4:
                                xPos = 1.57f;
                                break;
                            case 5:
                                xPos = 2.61f;
                                break;
                        }
                        probChoice = Instantiate(probChoice, new Vector2(xPos, 4.46f), probChoice.transform.rotation);
                        probChoice.transform.parent = listProblems.transform;
                    }
                } while (!doWhile);
                break;
            case 3:
                probChoice = problem3;
                do
                {
                    randomPos = UnityEngine.Random.Range(0, 6);
                    if (!Occupe[6, randomPos])
                    {
                        float xPos = 0;
                        doWhile = true;
                        switch (randomPos)
                        {
                            case 0:
                                xPos = -2.59f;
                                break;
                            case 1:
                                xPos = -1.55f;
                                break;
                            case 2:
                                xPos = -0.51f;
                                break;
                            case 3:
                                xPos = 0.53f;
                                break;
                            case 4:
                                xPos = 1.57f;
                                break;
                            case 5:
                                xPos = 2.61f;
                                break;
                        }
                        probChoice = Instantiate(probChoice, new Vector2(xPos, 4.46f), probChoice.transform.rotation);
                        probChoice.transform.parent = listProblems.transform;
                    }
                } while (!doWhile);
                break;
        }
        Problems problems = probChoice.GetComponent<Problems>();
        problems.J = randomPos;
        Occupe[problems.I, problems.J] = true;
        problemsInGame.Add(probChoice);

        newProbOK = true;

        UpdateListProblems();

        yield break;
    }

    public void UpdateListConsultants()
    {
        List<GameObject> transition = new List<GameObject>();

        for (int i = 0; i < listConsultants.transform.childCount; i++)
            transition.Add(listConsultants.transform.GetChild(i).gameObject);

        consultantsInGame = transition;
    }

    public void UpdateListProblems()
    {
        List<GameObject> transition = new List<GameObject>();

        for (int i = 0; i < listProblems.transform.childCount; i++)
            transition.Add(listProblems.transform.GetChild(i).gameObject);

        problemsInGame = transition;
    }

    private void UpdateListHand()
    {
        List<GameObject> transition = new List<GameObject>();
        for (int i = 0; i < hand.transform.childCount; i++)
        {
            transition.Add(hand.transform.GetChild(i).gameObject);
        }
        handList = transition;
    }

    public void MissionUp()
    {
        missionPoints = missionPoints + 10;
        if (missionPoints >= 100)
        {
            EndGame();
            winText.SetActive(true);
        }
        Debug.Log(missionPoints);
    }

    public void LifeDown()
    {
        lifePoints = lifePoints - 10;
        if (lifePoints <= 0)
        {
            EndGame();
            loseText.SetActive(true);
        }
        Debug.Log(lifePoints);
    }

    public void EndGame()
    {
        timeNewProblem = 50000;
        timeTestBloc = 50000;

        UpdateListProblems();
        if (lifePoints <= 0)
        {
            foreach (GameObject problem in problemsInGame)
                problem.GetComponent<Problems>().EndGameTimer();

            foreach (GameObject consultant in consultantsInGame)
            {
                consultant.GetComponent<CardConsultant>().EndGameTimer();
                consultant.GetComponent<CardConsultant>().Lose();
            }
        }
        else
        {
            foreach (GameObject problem in problemsInGame)
            {
                problem.GetComponent<Problems>().EndGameTimer();
                problem.GetComponent<Problems>().Lose();
            }

            foreach (GameObject consultant in consultantsInGame)
                consultant.GetComponent<CardConsultant>().EndGameTimer();
        }

        UpdateListConsultants();
    }

    public GameObject TestToFight(int i, int j)
    {
        GameObject problemFight = null;
        foreach(GameObject problem in problemsInGame)
        {
            Problems script = problem.GetComponent<Problems>();
            if (script.I == i + 1 && script.J == j)
                problemFight = problem;
        }

        return problemFight;
    }

    //private IEnumerator TestConsultantsBloc()
    //{
    //    foreach (GameObject consultant in consultantsInGame)
    //        if (consultant.GetComponent<CardConsultant>().Bloc)
    //        {
    //            StartCoroutine(Fight(consultant, consultant.GetComponent<CardConsultant>().ProblemFight));
    //            consultant.GetComponent<CardConsultant>().Bloc = false;
    //        }

    //    yield break;
    //}

    public IEnumerator Fight(GameObject consultant, GameObject problem)
    {
        while (true)
        {
            if (consultant != null && problem != null)
            {
                CardConsultant consultantScript = consultant.GetComponent<CardConsultant>();
                //Debug.Log(consultantScript.Vie);
                Problems problemScript = problem.GetComponent<Problems>();
                //Debug.Log(problemScript.Vie);
                if (consultantScript.type == problemScript.type)
                {
                    consultantScript.Vie -= 10;
                    problemScript.Vie -= (20 + damageBonus);
                }
                else
                {
                    consultantScript.Vie -= 20;
                    problemScript.Vie -= (20 + damageBonus);
                }
                yield return new WaitForSeconds(1);
            }
            else
            {
                UpdateListConsultants();
                UpdateListProblems();
                yield break;
            }
        }
    }

    public void Draw(int nbCards, int typeOfDraw)
    {
        if (handList.Count <= 5)
            for (int i = 0; i < nbCards; i++)
            {
                int random = 0;
                GameObject newCard = null;
                if (typeOfDraw == 1)
                    random = Random.Range(0, 5);
                else if (typeOfDraw == 2)
                    random = Random.Range(0, 3);
                switch (random)
                {
                    case 0:
                        newCard = Instantiate(Infra, Infra.transform.position, Infra.transform.rotation);
                        newCard.transform.parent = hand.transform;
                        handList.Add(newCard);
                        break;
                    case 1:
                        newCard = Instantiate(MOE, MOE.transform.position, MOE.transform.rotation);
                        newCard.transform.parent = hand.transform;
                        handList.Add(newCard);
                        break;
                    case 2:
                        newCard = Instantiate(AMOA, AMOA.transform.position, AMOA.transform.rotation);
                        newCard.transform.parent = hand.transform;
                        handList.Add(newCard);
                        break;
                    case 3:
                        newCard = Instantiate(Commercial, Commercial.transform.position, Commercial.transform.rotation);
                        newCard.transform.parent = hand.transform;
                        handList.Add(newCard);
                        break;
                    case 4:
                        newCard = Instantiate(Recruteur, Recruteur.transform.position, Recruteur.transform.rotation);
                        newCard.transform.parent = hand.transform;
                        handList.Add(newCard);
                        break;
                }
            }
    }

    private IEnumerator PositionCards()
    {
        while (true)
        {
            UpdateListHand();
            int i = 0;
            foreach (GameObject card in handList)
            {
                card.transform.position = locations.transform.GetChild(i).transform.position;
                i++;
            }

            yield return new WaitForSeconds(1);
        }
    }
    
    private IEnumerator UpdateCaseLibre()
    {
        UpdateListProblems();
        for (int j = 0; j < 6; j++)
        {
            bool occupe = false;

            foreach (GameObject problem in problemsInGame)
                if (problem.GetComponent<Problems>().I == 6 && problem.GetComponent<Problems>().J == j)
                    occupe = true;
            if (!occupe)
                Occupe[6, j] = false;
        }

        UpdateListConsultants();
        for (int j = 0; j < 6; j++)
        {
            bool occupe = false;

            foreach (GameObject consultant in consultantsInGame)
                if (consultant.GetComponent<CardConsultant>().I == 0 && consultant.GetComponent<CardConsultant>().J == j)
                    occupe = true;
            if (!occupe)
                Occupe[6, j] = false;
        }

        yield break;
    }


}
