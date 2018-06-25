using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject worker;
    public GameObject exclamationPoint1;
    public GameObject exclamationPoint2;

    public static bool boolComputer1;
    public static bool boolComputer2;

    public static bool boolSetUp1;
    public static bool boolSetUp2;
    public static bool boolSetUp3;
    public static bool boolSetUp4;

    public static bool gamePause;
    public static int totalPoints;
    public Text pointText;

    private float newWorkerTime;

    void Start()
    {
        newWorkerTime = 5;

        boolComputer1 = false;
        boolComputer2 = false;

        gamePause = false;
        totalPoints = 100;
        pointText.text = "Point :\n" + totalPoints + "/100";

        boolSetUp1 = true;
        boolSetUp2 = true;
        boolSetUp3 = true;
    }

    void Update()
    {
        newWorkerTime -= Time.deltaTime;
        if (newWorkerTime < 0)
        {
            Debug.Log("if enter");
            Instantiate(worker, worker.transform.position, worker.transform.rotation);
            newWorkerTime = 5;
        }
    }

    public void updateScore()
    {
        totalPoints--;
        pointText.text = "Point :\n" + totalPoints + "/100";
    }
}
