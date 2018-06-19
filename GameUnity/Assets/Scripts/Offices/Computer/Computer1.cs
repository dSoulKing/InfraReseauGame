using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Computer1 : MonoBehaviour {

    public GameObject allVirus;

    private Camera mainCamera;



    void OnMouseDown()
    {
        GameObject gameControllerObject = GameObject.Find("GameController");
        GameController gameController = gameControllerObject.GetComponent<GameController>();
        
        Debug.Log("PC1");
        if (GameController.boolComputer1 == true)
        {
            Destroy(gameController.exclamationPoint1);
            Roof12Clicked.eP1 = false;

            mainCamera = Camera.main;

            mainCamera.orthographicSize = 3.4f;
            mainCamera.transform.position = new Vector3(320.4f, -0.5f, 0);
            mainCamera.transform.Rotate(-90, 0, 0);
            
            Instantiate(allVirus, allVirus.transform.position, allVirus.transform.rotation);

            VirusManager.virusStart = true;
            GameController.gamePause = true;
        }
    }
}
