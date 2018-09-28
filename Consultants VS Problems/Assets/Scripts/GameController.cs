using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject popUpQuit;

    public SpriteRenderer background;

    public GameObject cerclesZone;

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
    private float timeToDraw;

    public static float timeBoostCom;

    public static int missionPoints;
    public static int lifePoints;

    private int damageBonus;

    private List<GameObject> handList;

    private string timerComString;
    public GameObject chronoCom;
    private TextMesh timerComText;

    private string lifePointsString;
    public TextMesh lifeText;

    private string missionPointsString;
    public TextMesh missionPointsText;

    public GameObject electricFightObject;

    private bool pioche1;
    private bool pioche2;

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
        timeToDraw = 6;

        timeBoostCom = 0;

        missionPoints = 0;
        lifePoints = 100;

        damageBonus = 0;

        StartCoroutine(PositionCards());

        timerComText = chronoCom.GetComponent<TextMesh>();

        pioche1 = true;
        pioche2 = true;
    }

    private void Update()
    {
        if (newProbOK)
            timeNewProblem -= Time.deltaTime;
        timeTestBloc -= Time.deltaTime;
        timeToDraw -= Time.deltaTime;

        if (timeNewProblem <= 0)
        {
            StartCoroutine(NewProblem());
            StartCoroutine(UpdateCaseLibre());
            if (missionPoints < 40)
                timeNewProblem = 5;
            else if (missionPoints < 60)
                timeNewProblem = 4.5f;
            else if (missionPoints < 80)
            {
                timeNewProblem = 4;
                if (pioche1)
                {
                    Draw(1, 1);
                    pioche1 = !pioche1;
                }
            }
            else if (missionPoints < 100)
            {
                timeNewProblem = 3.5f;
                if (pioche2)
                {
                    Draw(2, 1);
                    pioche2 = !pioche2;
                }
            }
        }

        if(timeToDraw <= 0)
        {
            Draw(1, 1);
            timeToDraw = 6;
        }

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
        missionPointsString = missionPoints.ToString("F0");
        missionPointsText.text = "Score : " + missionPointsString;
        if (missionPoints >= 100)
        {
            winText.SetActive(true);
            EndGame();
        }
    }

    public void LifeDown()
    {
        lifePoints = lifePoints - 10;
        StartCoroutine(RedFlash());
        if (lifePoints <= 0)
        {
            EndGame();
            loseText.SetActive(true);
        }
        lifePointsString = lifePoints.ToString("F0");
        lifeText.text = lifePointsString;

    }

    public void EndGame()
    {
        timeNewProblem = 50000;
        timeTestBloc = 50000;

        UpdateListProblems();
        //if (lifePoints <= 0)
        //{
        //    foreach (GameObject problem in problemsInGame)
        //        problem.GetComponent<Problems>().EndGameTimer(true);
        //    foreach (GameObject consultant in consultantsInGame)
        //        consultant.GetComponent<CardConsultant>().EndGameTimer(false);
        //}
        //else
        //{
        //    foreach (GameObject problem in problemsInGame)
        //        problem.GetComponent<Problems>().EndGameTimer(false);
        //    foreach (GameObject consultant in consultantsInGame)
        //        consultant.GetComponent<CardConsultant>().EndGameTimer(true);
        //}

        UpdateListConsultants();
        foreach (GameObject consultant in consultantsInGame)
            Destroy(consultant);
        foreach (GameObject problem in problemsInGame)
            Destroy(problem);
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

    public IEnumerator Fight(GameObject consultant, GameObject problem)
    {
        while (true)
        {
            if (consultant != null && problem != null)
            {
                CardConsultant consultantScript = consultant.GetComponent<CardConsultant>();
                Problems problemScript = problem.GetComponent<Problems>();
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
                //Destroy(consultant.GetComponent<CardConsultant>().ElectricFightObject);
                Destroy(consultant.transform.GetChild(0).gameObject);
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

    private IEnumerator RedFlash()
    {
        background.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(0.3f);
        background.color = new Color(1, 1, 1, 1);
    }


    public void ClickToQuit()
    {
        popUpQuit.SetActive(true);
    }

    public void EndGameQuit()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Like()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void DontLike()
    {
        popUpQuit.SetActive(false);
    }
    public void Rejouer()
    {
        SceneManager.LoadScene("MainScene");
    }
}
