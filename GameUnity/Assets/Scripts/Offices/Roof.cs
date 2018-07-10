using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Roof : MonoBehaviour {

    Camera mainCamera;

    private float camSize;
    private Vector3 camPos;
    private MeshRenderer meshRenderer;
    private GameObject selectedRoof;
    private bool boolRoof;

    void Start () {
        mainCamera = Camera.main;
        boolRoof = true;
        camSize = 9.1f;
        camPos = new Vector3(12, 2.9f, 9);
	}

    public void ClickOnRoof (GameObject roof, float sizeCam)
    {
        if (boolRoof)
        {
            mainCamera.transform.position = new Vector3(roof.transform.position.x, mainCamera.transform.position.y, roof.transform.position.z);
            roof.SetActive(false);
            boolRoof = false;
            selectedRoof = roof;
            mainCamera.orthographicSize = sizeCam;
        }
    }
    
    public void GroundClicked()
    {
        if (!boolRoof)
        {
            mainCamera.orthographicSize = camSize;
            mainCamera.transform.position = camPos;
            selectedRoof.SetActive(true);
            selectedRoof = null;
            boolRoof = true;
        }
    }
}
