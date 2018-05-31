using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBack : MonoBehaviour {

    public Camera mainCamera;

    public GameObject roofBoss;
    public GameObject roofEntry;
    public GameObject roofServers;
    public GameObject roofBureau1;
    public GameObject roofBureau2;
    public GameObject roofBureau3;
    public GameObject roofBureau4;
    public GameObject roofBureau5;
    public GameObject roofBureau6;
    public GameObject roofBureau7;
    public GameObject roofBureau8;
    public GameObject roofBureau9;
    public GameObject roofBureau10;
    public GameObject roofBureau11;
    public GameObject roofBureau12;
    public GameObject roofBureau13;
    public GameObject roofBureau14;
    public GameObject roofBureau15;

    void Start()
    {
        mainCamera.gameObject.SetActive(true);
        mainCamera.orthographic = true;
    }

    void OnMouseDown()
    {
        if (RoofsBool.cam == false)
        {
            mainCamera.orthographicSize = 9.1f;
            mainCamera.transform.position = new Vector3(12, 2.9f, 9);

            RoofsBool.cam = true;
            
            SetActiveAll();
        }
    }

    public void SetActiveAll ()
    {
        RoofBossClicked.camBoss = true;
        RoofEntryClicked.camEntry = true;
        RoofServersClicked.camServers = true;
        Roof1Clicked.cam1 = true;
        Roof2Clicked.cam2 = true;
        Roof3Clicked.cam3 = true;
        Roof4Clicked.cam4 = true;
        Roof5Clicked.cam5 = true;
        Roof6Clicked.cam6 = true;
        Roof7Clicked.cam7 = true;
        Roof8Clicked.cam8 = true;
        Roof9Clicked.cam9 = true;
        Roof10Clicked.cam10 = true;
        Roof11Clicked.cam11 = true;
        Roof12Clicked.cam12 = true;
        Roof13Clicked.cam13 = true;
        Roof14Clicked.cam14 = true;
        Roof15Clicked.cam15 = true;

        roofBoss.SetActive(true);
        roofEntry.SetActive(true);
        roofServers.SetActive(true);
        roofBureau1.SetActive(true);
        roofBureau2.SetActive(true);
        roofBureau3.SetActive(true);
        roofBureau4.SetActive(true);
        roofBureau5.SetActive(true);
        roofBureau6.SetActive(true);
        roofBureau7.SetActive(true);
        roofBureau8.SetActive(true);
        roofBureau9.SetActive(true);
        roofBureau10.SetActive(true);
        roofBureau11.SetActive(true);
        roofBureau12.SetActive(true);
        roofBureau13.SetActive(true);
        roofBureau14.SetActive(true);
        roofBureau15.SetActive(true);
    }
}
