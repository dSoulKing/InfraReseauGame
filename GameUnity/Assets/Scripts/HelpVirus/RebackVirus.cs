using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebackVirus : MonoBehaviour {
    
    private Camera mainCamera;

    private void OnMouseDown()
    {
        mainCamera = Camera.main;

        mainCamera.orthographicSize = 9.1f;
        mainCamera.transform.position = new Vector3(12, 2.9f, 9);
        mainCamera.transform.Rotate(90, 0, 0);
       
        GameController.gamePause = false;
        GameController.boolComputer1 = false;

        Destroy(transform.parent.gameObject);
    }
}
