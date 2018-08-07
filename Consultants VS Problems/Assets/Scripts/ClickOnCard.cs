using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnCard : MonoBehaviour {

    public GameObject cercle1;
    public GameObject cercle2;
    public GameObject cercle3;
    public GameObject cercle4;

    public static bool cardBool = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if(GameController.cardClicking == null)
        {
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0);
            GameController.cardClicking = gameObject;
        }
        else if(GameController.cardClicking == gameObject)
        {
            gameObject.transform.localScale = new Vector3(0.25f, 0.25f, 0);
            GameController.cardClicking = null;
        }
        else
        {
            GameController.cardClicking.transform.localScale = new Vector3(0.25f, 0.25f, 0);
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0);
            GameController.cardClicking = gameObject;
        }

        if (GameController.cardClicking != null)
        {
            
            cercle1.SetActive(true);
            cercle2.SetActive(true);
            cercle3.SetActive(true);
            cercle4.SetActive(true);
        }
        else
        {
            cercle1.SetActive(false);
            cercle2.SetActive(false);
            cercle3.SetActive(false);
            cercle4.SetActive(false);
        }
    }
}
