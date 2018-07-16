using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickComputer : MonoBehaviour {
    
    private Camera mainCamera;

    void OnMouseDown()
    {
            mainCamera = Camera.main;

            mainCamera.orthographicSize = 3.4f;
            mainCamera.transform.position = new Vector3(320.4f, -0.5f, 0);
            mainCamera.transform.Rotate(-90, 0, 0);

            transform.parent.gameObject.GetComponent<VirusManager>().virusStart = true;
            GameController.gamePause = true;
    }
}
