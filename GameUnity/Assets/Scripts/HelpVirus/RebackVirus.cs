using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebackVirus : MonoBehaviour {
    
    public GameObject allVirus;

    private Camera mainCamera;

    private void OnMouseDown()
    {
        mainCamera = Camera.main;

        mainCamera.orthographicSize = 9.1f;
        mainCamera.transform.position = new Vector3(12, 2.9f, 9);
        mainCamera.transform.Rotate(90, 0, 0);

        GameObject groundBackObject = GameObject.Find("GroundBack");
        GroundBack groundBack = groundBackObject.GetComponent<GroundBack>();
        groundBack.SetActiveAll();
       
        GameController.gamePause = false;
        GameController.boolComputer1 = false;

        Destroy(allVirus);
    }
}
