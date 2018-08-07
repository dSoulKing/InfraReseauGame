using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Roof : MonoBehaviour {

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
        camPos = new Vector3(12, 29, 9);
	}

    public void ClickOnRoof (GameObject roof, float sizeCam)
    {
        if (roof.transform.childCount > 0)
        {
            roof.transform.CenterOnChildred();
        }
        if (boolRoof)
        {
            mainCamera.transform.position = new Vector3(roof.transform.position.x, roof.transform.position.y + 0.5f, roof.transform.position.z);
            roof.SetActive(false);
            boolRoof = false;
            selectedRoof = roof;
            mainCamera.orthographicSize = sizeCam;
            roof.GetComponent<RoofClicked>().office.SetActive(true);
        }
    }
    
    public void GroundClicked()
    {
        if (!boolRoof)
        {
            mainCamera.orthographicSize = camSize;
            mainCamera.transform.position = camPos;
            selectedRoof.SetActive(true);
            selectedRoof.GetComponent<RoofClicked>().office.SetActive(false);
            selectedRoof = null;
            boolRoof = true;
        }
    }

}
