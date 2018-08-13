using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject problem1;
    public GameObject problem2;
    public GameObject problem3;

    public static GameObject cardClicking = null;

    public static bool[,] Occupe { get; set; }

    public static List<GameObject> consultantsInGame;
    private static List<GameObject> problemsInGame;

    private bool newtProbOK = true;

    private float timeMoveConsultants;
    private float timeMoveProblems;
    private float timeNewProblem;
    private float timeTestWinOrLose;
    private float timeToHit;

    private int missionPoints;
    private int lifePoints;

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

        timeMoveConsultants = 5;
        timeMoveProblems = 10;
        timeNewProblem = 5;
        timeTestWinOrLose = 1;

        missionPoints = 0;
        lifePoints = 100;
    }

    private void Update()
    {
        timeMoveConsultants -= Time.deltaTime;
        timeMoveProblems -= Time.deltaTime;
        if (newtProbOK)
            timeNewProblem -= Time.deltaTime;
        timeTestWinOrLose -= Time.deltaTime;

        if (timeMoveConsultants <= 0)
        {
            StartCoroutine(MoveConsultants());
            timeMoveConsultants = 10;
        }

        if (timeMoveProblems <= 0)
        {
            StartCoroutine(MoveProblems());
            timeMoveProblems = 10;
        }

        if (timeNewProblem <= 0)
        {
            StartCoroutine(NewProblem());
            timeNewProblem = 20;
        }

        if (timeTestWinOrLose <= 0)
        {
            StartCoroutine(TestWinConsultants());
            StartCoroutine(TestLoseProblems());
            timeTestWinOrLose = 1;
        }
        
    }

    private IEnumerator MoveConsultants()
    {
        foreach(GameObject consultant in consultantsInGame)
        {
            Consultant consultantScript = consultant.GetComponent<Consultant>();
            
            if (consultantScript.I < 4)
            {
                if (!Occupe[consultantScript.I + 1, consultantScript.J])
                {
                    consultant.transform.Translate(0, 1.38f, 0);
                    Occupe[consultantScript.I, consultantScript.J] = false;
                    consultantScript.I++;
                    Occupe[consultantScript.I, consultantScript.J] = true;
                }
                else
                {
                    foreach (GameObject problem in problemsInGame)
                    {
                        Problems problemScript = problem.GetComponent<Problems>();
                        if (problemScript.I == consultantScript.I + 1 && problemScript.J == consultantScript.J)
                        {
                            StartCoroutine(Fight(consultant, problem));
                        }
                    }
                }
            }
        }

        yield return null;
    }

    private IEnumerator TestWinConsultants()
    {
        List<GameObject> transition = new List<GameObject>();
        foreach (GameObject consultant in consultantsInGame)
        {
            Consultant consultantScript = consultant.GetComponent<Consultant>();

            if (consultantScript.I == 4)
            {
                consultantScript.Animator.SetTrigger("DisapearConsultant");
                Destroy(consultant, 1.66f);
                MissionUp();
                Occupe[consultantScript.I, consultantScript.J] = false;
            }
            else
                transition.Add(consultant);
        }
        consultantsInGame = transition;
        //Debug.Log(consultantsInGame.Count);

        yield return null;
    }

    private IEnumerator NewProblem()
    {
        newtProbOK = false;
        int randomProb = 0;
        int randomPos = 0;
        GameObject probChoice = new GameObject();
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
                    }
                } while (!doWhile);
                break;
        }
        Problems problems = probChoice.GetComponent<Problems>();
        problems.J = randomPos;
        Occupe[problems.I, problems.J] = true;
        problemsInGame.Add(probChoice);

        newtProbOK = true;

        yield return null;
    }

    private IEnumerator MoveProblems()
    {
        foreach (GameObject problem in problemsInGame)
        {
            Problems problemScript = problem.GetComponent<Problems>();

            if (problemScript.I > 0)
            {
                if (!Occupe[problemScript.I - 1, problemScript.J])
                {
                    problem.transform.Translate(0, -1.38f, 0);
                    Occupe[problemScript.I, problemScript.J] = false;
                    problemScript.I--;
                    Occupe[problemScript.I, problemScript.J] = true;
                }
                else
                {
                    foreach (GameObject consultant in consultantsInGame)
                    {
                        Problems consultantScript = consultant.GetComponent<Problems>();
                        if (consultantScript.I == problemScript.I - 1 && consultantScript.J == problemScript.J)
                        {
                            StartCoroutine(Fight(consultant, problem));
                        }
                    }
                }
            }
        }

        yield return null;
    }

    private IEnumerator TestLoseProblems()
    {
        List<GameObject> transition = new List<GameObject>();
        foreach (GameObject problem in problemsInGame)
        {
            Problems problemScript = problem.GetComponent<Problems>();

            if (problemScript.I == 0)
            {
                problemScript.Animator.SetTrigger("DisapearConsultant");
                Destroy(problem, 1.66f);
                LifeDown();
                Occupe[problemScript.I, problemScript.J] = false;
            }
            else
                transition.Add(problem);
        }
        problemsInGame = transition;
        //Debug.Log(problemsInGame.Count);

        yield return null;
    }
    

    private void MissionUp()
    {
        missionPoints = missionPoints + 10;
    }
    
    private void LifeDown()
    {
        lifePoints = lifePoints - 10;
    }

    private IEnumerator Fight(GameObject consultant, GameObject problem)
    {
        Consultant consultantScript = consultant.GetComponent<Consultant>();
        Problems problemScript = problem.GetComponent<Problems>();
        List<GameObject> transition = new List<GameObject>();
        List<GameObject> transition2 = new List<GameObject>();
        do
        {
            Debug.Log(consultantScript.Vie);
            Debug.Log(problemScript.Vie);
            if (consultantScript.type == problemScript.type)
            {
                consultantScript.Vie -= 20;
                problemScript.Vie -= 40;
            }
            else
            {
                consultantScript.Vie -= 20;
                problemScript.Vie -= 20;
            }
            yield return new WaitForSeconds(2);

        } while (consultantScript.Vie > 0 && problemScript.Vie > 0);

        if (consultantScript.Vie <= 0)
        {
            Debug.Log("if consultant dead");
            consultantScript.Alive = false;
            consultant.SetActive(false);
            Occupe[consultantScript.I, consultantScript.J] = false;

            foreach (GameObject consultantTest in consultantsInGame)
            {
                if (!consultantTest.GetComponent<Consultant>().Alive)
                    transition.Add(consultantTest);
            }
            consultantsInGame = transition;
            //Destroy(consultant);
        }
            
        if (problemScript.Vie <= 0)
        {
            Debug.Log("if problem dead");
            problemScript.Alive = false;
            problem.SetActive(false);
            Occupe[problemScript.I, problemScript.J] = false;

            foreach (GameObject problemTest in problemsInGame)
            {
                if (!problemTest.GetComponent<Consultant>().Alive)
                    transition2.Add(problemTest);
            }
            problemsInGame = transition2;
            //Destroy(problem);
        }

        yield return null;
    }
}
