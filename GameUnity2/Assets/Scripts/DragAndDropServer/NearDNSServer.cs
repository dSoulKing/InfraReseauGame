using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearDNSServer : MonoBehaviour {

    public GameObject thisCircle;
    public Sprite blueCircle;
    public Sprite whiteCircle;

    public static bool nearCircle = false;
    public static bool setActiveCircle = true;
    public static Vector3 positionCircle;

    private void Start()
    {
        positionCircle = thisCircle.transform.position;
    }

    private void Update()
    {
        if (!setActiveCircle)
            Destroy(thisCircle);
        /*thisCircle.SetActive(setActiveCircle);
    else
        thisCircle.SetActive(false);*/
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger enter");
        if (other.gameObject == GameObject.Find("DNSServer"))
        {
            thisCircle.GetComponent<SpriteRenderer>().sprite = blueCircle;
            nearCircle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == GameObject.Find("DNSServer"))
        {
            thisCircle.GetComponent<SpriteRenderer>().sprite = whiteCircle;
            nearCircle = false;
        }
    }
}
