using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickComputerRepair2 : MonoBehaviour {

    private Camera mainCamera;

    void OnMouseDown()
    {
        mainCamera = Camera.main;

        mainCamera.orthographicSize = 10.2f;
        mainCamera.transform.position = new Vector3(464.4f, 1.4f, 9);
        mainCamera.transform.Rotate(-90, 0, 0);

        transform.parent.gameObject.GetComponent<RepairManager>().repairStart = true;
        GameController.gamePause = true;
    }
}
