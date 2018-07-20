using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairManager : MonoBehaviour {

    public GameObject rebackButtonRepair;
    public GameObject computerCore;

    public GameObject electricPowerBlue;
    public GameObject electricPowerRed;
    public GameObject electricPowerYellow;
    public GameObject electricPowerGreen;

    public GameObject objectChronoText;

    public static bool B_1g1;
    public static bool B_1g2;
    public static bool B_1g3;
    public static bool B_2g1;
    public static bool B_2g2;
    public static bool B_2g3;
    public static bool B_2g4;
    public static bool B_2g5;
    public static bool B_2g6;
    public static bool B_3g1;
    public static bool B_3g2;
    public static bool B_7g1;

    public static bool R_1g1;
    public static bool R_1g2;
    public static bool R_2g1;
    public static bool R_2g2;
    public static bool R_2g3;
    public static bool R_2g4;
    public static bool R_2g5;
    public static bool R_2g6;
    public static bool R_5g1;
    public static bool R_6g1;
    
    public static bool Y_2g1;
    public static bool Y_2g2;
    public static bool Y_2g3;
    public static bool Y_2g4;
    public static bool Y_4g1;
    public static bool Y_4g2;
    public static bool Y_5g1;
    public static bool Y_5g2;
    public static bool Y_8g1;

    public static bool G_1g1;
    public static bool G_1g2;
    public static bool G_2g1;
    public static bool G_2g2;
    public static bool G_2g3;
    public static bool G_2g4;

    public bool repairStart = false;

    

    private GameObject[] electricPowerBTab;
    private GameObject[] electricPowerRTab;
    private GameObject[] electricPowerYTab;
    private GameObject[] electricPowerGTab;
    private float electricTimeB;
    private float electricTimeR;
    private float electricTimeY;
    private float electricTimeG;
    private int i;
    private int y;
    private int w;
    private int z;
    private bool repairOK;
    private double timer;
    private string timerString;
    private TextMesh timerText;

    private void Start()
    {
        B_1g1 = false;
        B_1g2 = false;
        B_1g3 = false;
        B_2g1 = false;
        B_2g2 = false;
        B_2g3 = false;
        B_2g4 = false;
        B_2g5 = false;
        B_2g6 = false;
        B_3g1 = false;
        B_3g2 = false;
        B_7g1 = false;

        R_1g1 = false;
        R_1g2 = false;
        R_2g1 = false;
        R_2g2 = false;
        R_2g3 = false;
        R_2g4 = false;
        R_2g5 = false;
        R_2g6 = false;
        R_5g1 = false;
        R_6g1 = false;

        Y_2g1 = false;
        Y_2g2 = false;
        Y_2g3 = false;
        Y_2g4 = false;
        Y_4g1 = false;
        Y_4g2 = false;
        Y_5g1 = false;
        Y_5g2 = false;
        Y_8g1 = false;

        G_1g1 = false;
        G_1g2 = false;
        G_2g1 = false;
        G_2g2 = false;
        G_2g3 = false;
        G_2g4 = false;

        electricPowerBTab = new GameObject[17];

        electricPowerRTab = new GameObject[17];

        electricPowerYTab = new GameObject[17];

        electricPowerGTab = new GameObject[13];

        i = 0;
        y = 0;
        w = 0;
        z = 0;
        electricTimeB = 1f;
        electricTimeR = 1f;
        electricTimeY = 1f;
        electricTimeG = 1f;
        
        for (int o = 0; o < 17; o++)
        {
            electricPowerBTab[o] = electricPowerBlue.transform.GetChild(o).gameObject;
            electricPowerBTab[o].SetActive(false);
        }
        for (int p = 0; p < 17; p++)
        {
            electricPowerRTab[p] = electricPowerRed.transform.GetChild(p).gameObject;
            electricPowerRTab[p].SetActive(false);
        }
        for (int q = 0; q < 17; q++)
        {
            electricPowerYTab[q] = electricPowerYellow.transform.GetChild(q).gameObject;
            electricPowerYTab[q].SetActive(false);
        }
        for (int r = 0; r < 13; r++)
        {
            electricPowerGTab[r] = electricPowerGreen.transform.GetChild(r).gameObject;
            electricPowerGTab[r].SetActive(false);
        }

        timer = 60;
        repairOK = false;
        
        timerText = objectChronoText.GetComponent<TextMesh>();

    }

    private void Update()
    {
        if (repairStart && timer >= 0 && !repairOK)
        {
            timer -= Time.deltaTime;
            timerString = timer.ToString("F1");
            timerText.text = timerString;
        }

        if (B_7g1 && R_1g1 && Y_4g1 && G_1g1)
        {
            repairOK = true;
        }

        if (B_7g1)
        {
            electricTimeB -= Time.deltaTime;
            if (electricTimeB <= 0 && i < 17)
            {
                electricPowerBTab[i].SetActive(true);
                i++;
                electricTimeB = 0.5f;
            }
        }

        if (R_1g1)
        {
            electricTimeR -= Time.deltaTime;
            if (electricTimeR <= 0 && y < 17)
            {
                electricPowerRTab[y].SetActive(true);
                y++;
                electricTimeR = 0.5f;
            }
        }

        if (Y_4g1)
        {
            electricTimeY -= Time.deltaTime;
            if (electricTimeY <= 0 && w < 17)
            {
                electricPowerYTab[w].SetActive(true);
                w++;
                electricTimeY = 0.5f;
            }
        }

        if (G_1g1)
        {
            electricTimeG -= Time.deltaTime;
            if (electricTimeG <= 0 && z < 13)
            {
                electricPowerGTab[z].SetActive(true);
                z++;
                electricTimeG = 0.5f;
            }
        }

        if (i == 17 && y == 17 && w == 17 && z == 13)
        {
            rebackButtonRepair.SetActive(true);
            computerCore.SetActive(true);
        }
        if (timer <= 0)
        {
            GameController.totalPoints -= 10;
            RebackRepair rebackRepair = rebackButtonRepair.GetComponent<RebackRepair>();
            rebackRepair.OnMouseDown();
        }
    }
}
