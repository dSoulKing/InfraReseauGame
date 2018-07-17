using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVirus1 : MonoBehaviour
{
    public Sprite fireBall;
    public Sprite explosion;
    public Transform target;
    public float speed;


    private SpriteRenderer virusRenderer;
    private bool stop;
    private GameObject thisVirus;
    private float rotationsPerMinute = 10f;

    private void Start()
    {

        thisVirus = gameObject;
        stop = true;
        virusRenderer = thisVirus.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float step1 = speed * Time.deltaTime;

        if (stop)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step1);
        }

        if (virusRenderer.sprite == fireBall)
        {
            transform.Rotate(0, 0, 6 * rotationsPerMinute * Time.deltaTime);
        }

        if (transform.position == target.position)
        {
            Destroy(thisVirus);
            VirusManager1.computerLife1--;
            VirusManager1.enter = false;
        }

    }

    private void OnMouseDown()
    {
        virusRenderer.sprite = explosion;
        stop = false;
        Destroy(thisVirus, 0.1f);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == GameObject.Find("CircleCenter"))
        {
            Debug.Log("virus enter");
            VirusManager1.enter = true;
            transform.localScale = new Vector3(0.016f, 0.016f, 0.016f);
            virusRenderer.sprite = fireBall;
            speed = speed * 2.5f;
        }
    }
}
