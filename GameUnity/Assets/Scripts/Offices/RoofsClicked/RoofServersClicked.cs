using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofServersClicked : MonoBehaviour {

    public Camera mainCamera;
    public GameObject thisRoof;

    public static bool camServers;

    void Start()
    {
        mainCamera.gameObject.SetActive(true);
        mainCamera.orthographic = true;
        thisRoof.SetActive(true);
        camServers = true;
    }

    void Update()
    {
        if (camServers == false)
        {
            thisRoof.SetActive(false);
        }
        else if (camServers == true)
        {
            thisRoof.SetActive(true);
        }
    }

    void OnMouseDown()
    {
        if (RoofsBool.cam == true)
        {
            mainCamera.orthographicSize = 4.2f;
            mainCamera.transform.position = new Vector3(15.96f, 5.3f, 9);
            //mainCamera.rect = new Rect(2f, 5f, 1, 1);

            camServers = false;
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
