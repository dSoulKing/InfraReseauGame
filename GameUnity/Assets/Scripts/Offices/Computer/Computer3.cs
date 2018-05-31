using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Computer3 : MonoBehaviour {

    private Camera mainCamera;

    void OnMouseDown()
    {
        Debug.Log("PC3");

        mainCamera = Camera.main;

        mainCamera.orthographicSize = 9.3f;
        mainCamera.transform.position = new Vector3(186f, 1.6f, -38.7f);
        mainCamera.transform.Rotate(-90, 0, 0);

        InputManager.inputON = true;
        GameController.gamePause = true;
    }

    
}