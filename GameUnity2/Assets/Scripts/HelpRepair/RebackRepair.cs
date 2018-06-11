using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebackRepair : MonoBehaviour {

    public GameObject allRepair;

    private Camera mainCamera;

    public void OnMouseDown()
    {
        mainCamera = Camera.main;

        mainCamera.orthographicSize = 9.1f;
        mainCamera.transform.position = new Vector3(12, 2.9f, 9);
        mainCamera.transform.Rotate(90, 0, 0);
        
        GameObject groundBackObject = GameObject.Find("GroundBack");
        GroundBack groundBack = groundBackObject.GetComponent<GroundBack>();
        groundBack.SetActiveAll();

        GameController.gamePause = false;
        GameController.boolComputer2 = false;
        RepairManager.repairStart = false;

        Destroy(allRepair);
    }
}
