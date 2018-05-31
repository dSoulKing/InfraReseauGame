using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof12Clicked : MonoBehaviour {

    public Camera mainCamera;
    public GameObject thisRoof;

    public static bool cam12;
    public static bool eP1;

    void Start()
    {
        eP1 = true;
        mainCamera.gameObject.SetActive(true);
        mainCamera.orthographic = true;
        thisRoof.SetActive(true);
        cam12 = true;
    }

    void Update()
    {
        GameObject gameControllerObject = GameObject.Find("GameController");
        GameController gameController = gameControllerObject.GetComponent<GameController>();

        if (cam12 == false)
        {
            thisRoof.SetActive(false);
            if (eP1)
                gameController.exclamationPoint1.SetActive(false);
        }
        else if (cam12 == true)
        {
            thisRoof.SetActive(true);
            if (eP1)
                gameController.exclamationPoint1.SetActive(true);
        }
    }

    void OnMouseDown()
    {
        if (RoofsBool.cam == true)
        {
            mainCamera.orthographicSize = 2.2f;
            mainCamera.transform.position = new Vector3(1.45f, 5.3f, 7.01f);
            //mainCamera.rect = new Rect(2f, 5f, 1, 1);
            cam12 = false;
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
