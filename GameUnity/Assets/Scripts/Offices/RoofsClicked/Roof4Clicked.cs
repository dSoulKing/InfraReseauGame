using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof4Clicked : MonoBehaviour {

    private Camera mainCamera;
    public GameObject thisRoof;

    public static bool cam4;

    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.gameObject.SetActive(true);
        mainCamera.orthographic = true;
        thisRoof.SetActive(true);
        cam4 = true;
    }

    void Update()
    {
        if (cam4 == false)
        {
            thisRoof.SetActive(false);
        }
        else if (cam4 == true)
        {
            thisRoof.SetActive(true);
        }
    }

    void OnMouseDown()
    {
        if (RoofsBool.cam == true)
        {
            mainCamera.orthographicSize = 2.6f;
            mainCamera.transform.position = new Vector3(22.44f, 5.3f, 15.46f);
            //mainCamera.rect = new Rect(2f, 5f, 1, 1);
            cam4 = false;
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
