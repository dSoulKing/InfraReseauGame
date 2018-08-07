using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickComputerRepair1 : MonoBehaviour {
    
    private Camera mainCamera;

    public GameObject directLight;

    void OnMouseDown()
    {
        mainCamera = Camera.main;

        mainCamera.orthographicSize = 10.2f;
        mainCamera.transform.position = new Vector3(464.4f, 1.4f, 9);
        mainCamera.transform.Rotate(-90, 0, 0);

        directLight.SetActive(true);

        transform.parent.gameObject.GetComponent<RepairManager>().repairStart = true;
        GameController.gamePause = true;
    }
}
