using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private List<Travel> travels;
    private List<Worker> workers;
    private bool addOrNot;

    private GameObject newProblem;

    private DateTime timeWorker = DateTime.Now;
    private DateTime timeMove = DateTime.Now;
    private DateTime timePoint = DateTime.Now;
    private DateTime timeProblem = DateTime.Now;

    private int x;

    void Start()
    {
        boolComputer1 = false;
        boolComputer2 = false;

        x = 1;

        gamePause = false;
        totalPoints = 100;
        pointText.text = "Point :\n" + totalPoints + "/100";

        boolSetUp1 = true;
        boolSetUp2 = true;
        boolSetUp3 = true;

        travels = new List<Travel>();
        Travel travelDefault1 = new Travel(1, 5);
        Travel travelDefault2 = new Travel(3, 5);
        travels.Add(travelDefault1);
        travels.Add(travelDefault2);

        workers = new List<Worker>();
    }

    void Update()
    {
        if (MenuStart.begin && !gamePause)
        {
            if ((DateTime.Now - timeWorker).TotalMilliseconds >= 14000 && travels.Count < 15)
            {
                StartCoroutine(NewWorker());
                timeWorker = DateTime.Now;
            }

            if ((DateTime.Now - timeMove).TotalMilliseconds >= 400 && travels.Count > 2)
            {
                StartCoroutine(WorkerMovement());
                timeMove = DateTime.Now;
            }

            if ((DateTime.Now - timePoint).TotalMilliseconds >= 1000 && travels.Count > 2)
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
        do
        {
            random1 = UnityEngine.Random.Range(1, 4);
            random2 = UnityEngine.Random.Range(1, 6);
            foreach (Travel travel in travels)
            {
                if (travel.NumWorker == random1 && travel.NumTravel == random2)
                {
                    addOrNot = false;
                }
                else
                    addOrNot = true;
            }
        } while (!addOrNot);
        Travel travelOk = new Travel(random1, random2);
        Worker workerOk = new Worker(random1, travelOk);
        travels.Add(travelOk);
        workers.Add(workerOk);

        travelOk.TravelLoad = Instantiate(travelOk.TravelLoad, travelOk.TravelLoad.transform.position, travelOk.TravelLoad.transform.rotation);
        travelOk.NumChildren = travelOk.TravelLoad.transform.childCount;
        workerOk.WorkerObject = Instantiate(workerOk.WorkerObject, workerOk.WorkerObject.transform.position, workerOk.WorkerObject.transform.rotation);

        workerOk.Worker1 = workerOk.WorkerObject.transform.GetChild(0).gameObject;
        workerOk.Worker2 = workerOk.WorkerObject.transform.GetChild(1).gameObject;

        workerOk.MakeTab();

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
                Debug.Log("enter in if");
                worker.TimeToPoint = 5;
                UpdateScore();
            }
        }

        yield return null;
    }

    private IEnumerator NewProblem()
    {
        if (x < 6)
        {
                newProblem = Resources.Load("Problem" + x, typeof(GameObject)) as GameObject;
                newProblem = Instantiate(newProblem, newProblem.transform.position, newProblem.transform.rotation);
        }
            
        else if (x == 6)
        {
            //BOSS is comming !
        }
        
        yield return null;
    }

    public void UpdateScore()
    {
        totalPoints--;
        pointText.text = "Point :\n" + totalPoints + "/100";
    }
}
