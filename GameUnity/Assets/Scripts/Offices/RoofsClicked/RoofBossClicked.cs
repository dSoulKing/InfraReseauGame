using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofBossClicked : MonoBehaviour {

    public Camera mainCamera;
    public GameObject thisRoof;
    
    public static bool camBoss;

    void Start()
    {
        mainCamera.gameObject.SetActive(true);
        mainCamera.orthographic = true;
        thisRoof.SetActive(true);
        camBoss = true;
    }

    void Update()
    {
        if (camBoss == false)
        {
            thisRoof.SetActive(false);
        }
        else if (camBoss == true)
        {
            thisRoof.SetActive(true);
        }
    }

    void OnMouseDown()
    {
        if (RoofsBool.cam == true)
        {
            mainCamera.orthographicSize = 2.8f;
            mainCamera.transform.position = new Vector3(3.14f, 5.3f, 15.6f);

            camBoss = false;
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
