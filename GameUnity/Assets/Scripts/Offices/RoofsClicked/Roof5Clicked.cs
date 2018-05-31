using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof5Clicked : MonoBehaviour {

    public Camera mainCamera;
    public GameObject thisRoof;

    public static bool cam5;
    public static bool eP2;

    void Start()
    {
        eP2 = true;
        mainCamera.gameObject.SetActive(true);
        mainCamera.orthographic = true;
        thisRoof.SetActive(true);
        cam5 = true;
    }

    void Update()
    {
        GameObject gameControllerObject = GameObject.Find("GameController");
        GameController gameController = gameControllerObject.GetComponent<GameController>();

        if (cam5 == false)
        {
            thisRoof.SetActive(false);
            if(eP2)
                gameController.exclamationPoint2.SetActive(false);
        }
        else if (cam5 == true)
        {
            thisRoof.SetActive(true);
            if(eP2)
                gameController.exclamationPoint2.SetActive(true);
        }
    }

    void OnMouseDown()
    {
        if (RoofsBool.cam == true)
        {
            mainCamera.orthographicSize = 2.6f;
            mainCamera.transform.position = new Vector3(22.39f, 5.3f, 10.52f);
            //mainCamera.rect = new Rect(2f, 5f, 1, 1);
            cam5 = false;
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
