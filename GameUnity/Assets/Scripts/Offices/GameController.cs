using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    
    public static bool boolComputer1;
    public static bool boolComputer2;

    public static bool boolSetUp1;
    public static bool boolSetUp2;
    public static bool boolSetUp3;
    public static bool boolSetUp4;

    public static bool gamePause;
    public static int totalPoints;
    public Text pointText;
    
    private int random1;
    private int random2;
    private ArrayList workers;
    private bool addOrNot;
    private GameObject[] travelsNo;
    private GameObject[] travelsNi;
    private GameObject[] travelsF;
    private GameObject allTravels;
    private bool workerNoOK;
    private bool workerNiOK;
    private bool workerFOK;
    private int nbNo;
    private int nbNi;
    private int nbF;

    private GameObject newProblemLoad;
    private GameObject newProblem;

    private DateTime timeWorker = DateTime.Now;
    private DateTime timeMove = DateTime.Now;
    private DateTime timePoint = DateTime.Now;
    private DateTime timeProblem = DateTime.Now;

    private int a, b;
    private int x;



    void Start()
    {
        boolComputer1 = false;
        boolComputer2 = false;

        a = b = 0;
        nbNo = 0;
        nbNi = 0;
        nbF = 0;

        x = 1;

        gamePause = false;
        totalPoints = 100;
        pointText.text = "Point :\n" + totalPoints + "/100";

        boolSetUp1 = true;
        boolSetUp2 = true;
        boolSetUp3 = true;

        allTravels = Resources.Load("AllTravels", typeof(GameObject)) as GameObject;
        allTravels = Instantiate(allTravels, allTravels.transform.position, allTravels.transform.rotation);

        travelsNo = new GameObject[4];
        travelsNi = new GameObject[5];
        travelsF = new GameObject[4];
        for (int y = 0; y < 13; y++)
        {
            if (y < 4)
                travelsF[y] = allTravels.transform.GetChild(y).gameObject;
            if (y >= 4 && y < 9)
            {
                travelsNi[a] = allTravels.transform.GetChild(y).gameObject;
                a++;
            }
            if (y >= 9)
            {
                travelsNo[b] = allTravels.transform.GetChild(y).gameObject;
                b++;
            }
        }

        workers = new ArrayList();
    }

    void Update()
    {
        if (MenuStart.begin && !gamePause)
        {
            if ((DateTime.Now - timeWorker).TotalMilliseconds >= 14000)
            {
                StartCoroutine(NewWorker());
                timeWorker = DateTime.Now;
            }

            if ((DateTime.Now - timeMove).TotalMilliseconds >= 400)
            {
                StartCoroutine(WorkerMovement());
                timeMove = DateTime.Now;
            }

            if ((DateTime.Now - timePoint).TotalMilliseconds >= 1000)
            {
                StartCoroutine(MalusTime());
                timePoint = DateTime.Now;
            }
            if ((DateTime.Now - timeProblem).TotalMilliseconds >= 30000)
            {
                StartCoroutine(NewProblem());
                timeProblem = DateTime.Now;
            }
        }
    }

    private IEnumerator NewWorker()
    {
        workerNoOK = false;
        workerNiOK = false;
        workerFOK = false;
        int random;
        do
        {
            random = UnityEngine.Random.Range(1, 4);
            switch (random)
            {
                case 1:
                    if (nbNo < 4)
                    {
                        workerNoOK = true;
                        nbNo++;
                    }
                    break;
                case 2:
                    if (nbNi < 5)
                    {
                        workerNiOK = true;
                        nbNi++;
                    }
                    break;
                case 3:
                    if (nbF < 4)
                    {
                        workerFOK = true;
                        nbF++;
                    }
                    break;
            }
        } while (!workerNoOK && !workerNiOK && !workerFOK);

        if (workerNoOK)
        {
            Worker workerOk = new Worker(random, travelsNo[nbNo - 1]);
            workerOk.WorkerObject = Instantiate(workerOk.WorkerObject, workerOk.WorkerObject.transform.position, workerOk.WorkerObject.transform.rotation);
            workers.Add(workerOk);
            travelsNo[nbNo - 1].SetActive(true);
            workerOk.MakeTab();
            workerOk.Worker1 = workerOk.WorkerObject.transform.GetChild(0).gameObject;
            workerOk.Worker2 = workerOk.WorkerObject.transform.GetChild(1).gameObject;
        }
        else if (workerNiOK)
        {
            Worker workerOk = new Worker(random, travelsNi[nbNi - 1]);
            workerOk.WorkerObject = Instantiate(workerOk.WorkerObject, workerOk.WorkerObject.transform.position, workerOk.WorkerObject.transform.rotation);
            workers.Add(workerOk);
            travelsNi[nbNi - 1].SetActive(true);
            workerOk.MakeTab();
            workerOk.Worker1 = workerOk.WorkerObject.transform.GetChild(0).gameObject;
            workerOk.Worker2 = workerOk.WorkerObject.transform.GetChild(1).gameObject;
        }
        else if (workerFOK)
        {
            Worker workerOk = new Worker(random, travelsF[nbF - 1]);
            travelsF[nbF - 1].SetActive(true);
            workerOk.WorkerObject = Instantiate(workerOk.WorkerObject, workerOk.WorkerObject.transform.position, workerOk.WorkerObject.transform.rotation);
            workers.Add(workerOk);
            travelsF[nbF - 1].SetActive(true);
            workerOk.MakeTab();
            workerOk.Worker1 = workerOk.WorkerObject.transform.GetChild(0).gameObject;
            workerOk.Worker2 = workerOk.WorkerObject.transform.GetChild(1).gameObject;
        } 

        yield return null;
    }

    private IEnumerator WorkerMovement()
    {
        foreach (Worker worker in workers)
        {
            worker.TimeToMoveUsed -= 0.4f;
            if (worker.TimeToMoveUsed <= 0)
            {
                worker.MoveWorker();
                worker.ReloadTime();
            }
        }
        yield return null;
    }

    private IEnumerator MalusTime()
    {
        foreach (Worker worker in workers)
        {
            worker.TimeToPoint -= 1;
            if (worker.TimeToPoint == 0)
            {
                worker.TimeToPoint = 5;
                UpdateScore();
            }
        }

        yield return null;
    }

    private IEnumerator NewProblem()
    {
        newProblem = Resources.Load("Problem" + x, typeof(GameObject)) as GameObject;
        newProblem = Instantiate(newProblem, newProblem.transform.position, newProblem.transform.rotation);
        
        if (x == 6)
        {
            //BOSS is comming !
        }
        x++;
        yield return null;
    }

    public void UpdateScore()
    {
        totalPoints--;
        pointText.text = "Point :\n" + totalPoints + "/100";
    }
}
