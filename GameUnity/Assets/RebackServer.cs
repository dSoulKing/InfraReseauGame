using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebackServer : MonoBehaviour {
    
    private Camera mainCamera;

    private void OnMouseDown()
    {
        mainCamera = Camera.main;

        mainCamera.orthographicSize = 9.1f;
        mainCamera.transform.position = new Vector3(12, 2.9f, 9);
        mainCamera.transform.Rotate(90, 0, 0);

        InputManager.inputON = false;

        GameObject groundBackObject = GameObject.Find("GroundBack");
        GroundBack groundBack = groundBackObject.GetComponent<GroundBack>();
        groundBack.SetActiveAll();


        GameController.gamePause = false;
    }
}
