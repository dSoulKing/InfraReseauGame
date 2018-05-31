using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofEntryClicked : MonoBehaviour {

    public Camera mainCamera;
    public GameObject thisRoof;

    public static bool camEntry;

    void Start()
    {
        mainCamera.gameObject.SetActive(true);
        mainCamera.orthographic = true;
        thisRoof.SetActive(true);
        camEntry = true;
    }

    void Update()
    {
        if (camEntry == false)
        {
            thisRoof.SetActive(false);
        }
        else if (camEntry == true)
        {
            thisRoof.SetActive(true);
        }
    }

    void OnMouseDown()
    {
        if (RoofsBool.cam == true)
        {
            mainCamera.orthographicSize = 2.8f;
            mainCamera.transform.position = new Vector3(8.06f, 5.3f, 7.47f);
            //mainCamera.rect = new Rect(2f, 5f, 1, 1);

            camEntry = false;
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
