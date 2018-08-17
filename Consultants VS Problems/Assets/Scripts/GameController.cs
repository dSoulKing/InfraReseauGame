using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance;

    public GameObject problem1;
    public GameObject problem2;
    public GameObject problem3;
    
    public GameObject listProblems;
    public GameObject listConsultants;

    public static GameObject cardClicking = null;

    public static bool[,] Occupe { get; set; }

    public static List<GameObject> consultantsInGame;
    private static List<GameObject> problemsInGame;

    private bool newProbOK = true;
    
    private float timeNewProblem;
    private float timeTestWinOrLose;
    private float timeToHit;
    private float timeTestBloc;

    public static int missionPoints;
    public static int lifePoints;

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
        Occupe = new bool[5, 4];
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                Occupe[i, j] = false;
            }
        }

        consultantsInGame = new List<GameObject>();
        problemsInGame = new List<GameObject>();
        
        timeNewProblem = 5;
        timeTestWinOrLose = 1;
        timeTestBloc = 2;

        missionPoints = 0;
        lifePoints = 100;

    }

    private void Update()
    {
        if (newProbOK /*&& problemsInGame.Count < 6*/)
            timeNewProblem -= Time.deltaTime;
        timeTestWinOrLose -= Time.deltaTime;
        timeTestBloc -= Time.deltaTime;

        if (timeNewProblem <= 0)
        {
            StartCoroutine(NewProblem());
            timeNewProblem = 20;
        }

        if (timeTestWinOrLose <= 0)
        {
            timeTestWinOrLose = 1;
        }

        if (timeTestBloc <= 0)
        {
            StartCoroutine(TestConsultantsBloc());
            timeTestBloc = 2;
        }
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
                    randomPos = UnityEngine.Random.Range(0, 4);
                    if (!Occupe[4, randomPos])
                    {
                        float xPos = 0;
                        doWhile = true;
                        switch (randomPos)
                        {
                            case 0:
                                xPos = -2.4f;
                                break;
                            case 1:
                                xPos = -0.8f;
                                break;
                            case 2:
                                xPos = 0.8f;
                                break;
                            case 3:
                                xPos = 2.4f;
                                break;
                        }
                        probChoice = Instantiate(probChoice, new Vector2(xPos, 4.5f), probChoice.transform.rotation);
                        probChoice.transform.parent = listProblems.transform;
                    }
                } while (!doWhile);
                break;
            case 2:
                probChoice = problem2;
                do
                {
                    randomPos = UnityEngine.Random.Range(0, 4);
                    if (!Occupe[4, randomPos])
                    {
                        float xPos = 0;
                        doWhile = true;
                        switch (randomPos)
                        {
                            case 0:
                                xPos = -2.4f;
                                break;
                            case 1:
                                xPos = -0.8f;
                                break;
                            case 2:
                                xPos = 0.8f;
                                break;
                            case 3:
                                xPos = 2.4f;
                                break;
                        }
                        probChoice = Instantiate(probChoice, new Vector2(xPos, 4.5f), probChoice.transform.rotation);
                        probChoice.transform.parent = listProblems.transform;
                    }
                } while (!doWhile);
                break;
            case 3:
                probChoice = problem3;
                do
                {
                    randomPos = UnityEngine.Random.Range(0, 4);
                    if (!Occupe[4, randomPos])
                    {
                        float xPos = 0;
                        doWhile = true;
                        switch (randomPos)
                        {
                            case 0:
                                xPos = -2.4f;
                                break;
                            case 1:
                                xPos = -0.8f;
                                break;
                            case 2:
                                xPos = 0.8f;
                                break;
                            case 3:
                                xPos = 2.4f;
                                break;
                        }
                        probChoice = Instantiate(probChoice, new Vector2(xPos, 4.5f), probChoice.transform.rotation);
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
        {
            transition.Add(listConsultants.transform.GetChild(i).gameObject);
        }
        consultantsInGame = transition;
    }

    public void UpdateListProblems()
    {
        List<GameObject> transition = new List<GameObject>();
        for (int i = 0; i < listProblems.transform.childCount; i++)
        {
            transition.Add(listProblems.transform.GetChild(i).gameObject);
        }
        problemsInGame = transition;
    }

    public void MissionUp()
    {
        missionPoints = missionPoints + 10;
    }

    public void LifeDown()
    {
        lifePoints = lifePoints - 10;
    }

    public GameObject TestToFight(int i, int j)
    {
        Debug.Log("testFight");
        GameObject problemFight = null;
        foreach(GameObject problem in problemsInGame)
        {
            Problems script = problem.GetComponent<Problems>();
            if (script.I == i + 1 && script.J == j)
                problemFight = problem;
        }

        return problemFight;
    }

    private IEnumerator TestConsultantsBloc()
    {
        foreach (GameObject consultant in consultantsInGame)
        {
            if (consultant.GetComponent<Consultant>().Bloc)
            {
                StartCoroutine(Fight(consultant, consultant.GetComponent<Consultant>().ProblemFight));
                consultant.GetComponent<Consultant>().Bloc = false;
            }
        }

        yield break;
    }

    private IEnumerator Fight(GameObject consultant, GameObject problem)
    {
        while (true)
        {
            if (consultant != null && problem != null)
            {
                Consultant consultantScript = consultant.GetComponent<Consultant>();
                Debug.Log(consultantScript.Vie);
                Problems problemScript = problem.GetComponent<Problems>();
                Debug.Log(problemScript.Vie);
                if (consultantScript.type == problemScript.type)
                {
                    consultantScript.Vie -= 10;
                    problemScript.Vie -= 20;
                }
                else
                {
                    consultantScript.Vie -= 10;
                    problemScript.Vie -= 10;
                }
                yield return new WaitForSeconds(1);
            }
            else
            {
                UpdateListConsultants();
                UpdateListProblems();
                Debug.Log("break");
                yield break;
            }
        }
    }
}
