using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof1Clicked : MonoBehaviour {

    private Camera mainCamera;
    public GameObject thisRoof;

    public static bool cam1;

    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.gameObject.SetActive(true);
        mainCamera.orthographic = true;
        thisRoof.SetActive(true);
        cam1 = true;
    }

    void Update()
    {
        if (cam1 == false)
        {
            thisRoof.SetActive(false);
        }
        else if (cam1 == true)
        {
            thisRoof.SetActive(true);
        }
    }

    void OnMouseDown()
    {
        if (RoofsBool.cam == true)
        {
            mainCamera.orthographicSize = 1.7f;
            mainCamera.transform.position = new Vector3(9f, 5.3f, 16.5f);
            //mainCamera.rect = new Rect(2f, 5f, 1, 1);
            cam1 = false;
            RoofsBool.cam = false;
        }
        else if (RoofsBool.cam == false)
        {
            GameObject groundBackObject = GameObject.Find("GroundBack");
            GroundBack groundBack = groundBackObject.GetComponent<GroundBack>();
            groundBack.SetActiveAll();

            mainCamera.orthographicSize = 9.1f;
            mainCamera.transform.position = new Vector3(12, 2.9f, 9);

            RoofsBool.cam = true;

        }
    }

}
