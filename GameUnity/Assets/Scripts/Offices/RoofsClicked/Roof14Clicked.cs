using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof14Clicked : MonoBehaviour {

    public Camera mainCamera;
    public GameObject thisRoof;

    public static bool cam14;

    void Start()
    {
        mainCamera.gameObject.SetActive(true);
        mainCamera.orthographic = true;
        thisRoof.SetActive(true);
        cam14 = true;
    }

    void Update()
    {
        if (cam14 == false)
        {
            thisRoof.SetActive(false);
        }
        else if (cam14 == true)
        {
            thisRoof.SetActive(true);
        }
    }

    void OnMouseDown()
    {
        if (RoofsBool.cam == true)
        {
            mainCamera.orthographicSize = 1.8f;
            mainCamera.transform.position = new Vector3(7.97f, 5.3f, 11.55f);
            //mainCamera.rect = new Rect(2f, 5f, 1, 1);
            cam14 = false;
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
