using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject worker1;
    public GameObject worker2;
    public GameObject worker3;
    public GameObject helpBubble;
    public GameObject exclamationPoint1;
    public GameObject exclamationPoint2;
    public GameObject clickToSetUp1;
    public GameObject clickToSetUp2;

    public GameObject timerTextObject;
    public Text timerText;

    public static bool boolComputer1;
    public static bool boolComputer2;

    public static bool boolSetUp1;
    public static bool boolSetUp2;
    public static bool boolSetUp3;

    public static bool gamePause;
    public static int totalPoints;
    public Text pointText;

    private Vector3 positionWorker;
    private Vector3 positionExclamationPoint;
    private Vector3 positionHelpBubble;

    private float timeNewWorker;
    private float timeNewHelp;
    private int numberWorker;
    private int numberExclamationPoint;
    private float eP1Malus;
    private float eP2Malus;


    void Start()
    {
        boolSetUp1 = true;
        boolSetUp2 = true;
        boolSetUp3 = true;
        timeNewWorker = 5f;
        timeNewHelp = 15f;
        eP1Malus = 5;
        eP2Malus = 5;

        gamePause = false;
        totalPoints = 100;
        pointText.text = "Point :\n" + totalPoints + "/100";

        numberWorker = 0;
        numberExclamationPoint = 0;

        positionWorker = new Vector3(8.699707f, 4.293945f, 11.82227f);
        positionExclamationPoint = new Vector3(1.5f, 2.22f, 7);
        positionHelpBubble = new Vector3(1.735f, 1, 8.752f);

        boolComputer1 = false;
        boolComputer2 = false;
    }

    void Update()
    {
        if (MenuStart.begin && !gamePause)
        {
            timeNewWorker -= Time.deltaTime;
            timeNewHelp -= Time.deltaTime;
        }

        if (timeNewWorker <= 0)
        {
            numberWorker++;
            if (numberWorker == 1)
            {
                Instantiate(worker1, positionWorker, Quaternion.identity);
                timeNewWorker = 25f;

                Instantiate(clickToSetUp1, clickToSetUp1.transform.position, clickToSetUp1.transform.rotation);
            }
            else if (numberWorker == 2)
            {
                Instantiate(worker2, positionWorker, Quaternion.identity);
                timeNewWorker = 15f;

                Instantiate(clickToSetUp2, clickToSetUp2.transform.position, clickToSetUp2.transform.rotation);
            }
            else if (numberWorker == 3)
            {
                Instantiate(worker3, positionWorker, Quaternion.identity);
                timeNewWorker = 5000f;
            }
        }

        if (timeNewHelp <= 0)
        {
            numberExclamationPoint++;
            if (numberExclamationPoint == 1)
            {
                exclamationPoint1 = (GameObject) Instantiate(exclamationPoint1, positionExclamationPoint, exclamationPoint1.transform.rotation);
                Instantiate(helpBubble, positionHelpBubble, helpBubble.transform.rotation);

                timeNewHelp = 20f;
                positionExclamationPoint = new Vector3(22.5f, 2.22f, 10.5f);
                positionHelpBubble = new Vector3(22.397f, 1, 12.773f);

                boolComputer1 = true;
            }
            else if (numberExclamationPoint == 2)
            {
                exclamationPoint2 = (GameObject) Instantiate(exclamationPoint2, positionExclamationPoint, exclamationPoint2.transform.rotation);
                Instantiate(helpBubble, positionHelpBubble, helpBubble.transform.rotation);

                timeNewHelp = 20f;
                positionExclamationPoint = new Vector3(7f, 2.22f, 1.5f);
                
                boolComputer2 = true;
            }
        }

        if (boolComputer1 && !VirusManager.virusStart)
            eP1Malus -= Time.deltaTime;
        if (boolComputer2 && !RepairManager.repairStart)
            eP2Malus -= Time.deltaTime;
        if (eP1Malus <= 0)
        {
            updateScore();
            eP1Malus = 5;
        }
        if (eP2Malus <= 0)
        {
            updateScore();
            eP2Malus = 5;
        }

        if (!boolComputer2)
            timerTextObject.SetActive(false);
        else
        {
            timerTextObject.SetActive(true);
            timerText.text = RepairManager.timerText;
        }
    }

    public void updateScore()
    {
        totalPoints--;
        pointText.text = "Point :\n" + totalPoints + "/100";
    }
}
