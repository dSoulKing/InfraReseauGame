using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWorker2 : MonoBehaviour
{

    public GameObject workerMove1;
    public GameObject workerMove2;
    public Material bigHead;

    public GameObject warning;

    public GameObject travel2;

    private Renderer spriteWorker1;
    private Renderer spriteWorker2;
    private GameObject[] spheres;
    private int i;
    private float timeToMove;
    private float timeToTilt;

    void Start()
    {
        spriteWorker1 = workerMove1.GetComponent<Renderer>();
        spriteWorker2 = workerMove2.GetComponent<Renderer>();

        i = 0;
        timeToMove = 0.3f;
        timeToTilt = 0f;
        spheres = new GameObject[27];

        workerMove1.SetActive(false);
        workerMove1.transform.Rotate(0, -90, 0, Space.World);
        workerMove2.transform.Rotate(0, -90, 0, Space.World);

        for (int y = 0; y < 27; y++)
        {
            spheres[y] = travel2.transform.GetChild(y).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.gamePause)
            timeToMove -= Time.deltaTime;

        if (timeToMove <= 0 && i < spheres.Length)
        {
            if (i == 12)
            {
                workerMove1.transform.Rotate(0, -90, 0, Space.World);
                workerMove2.transform.Rotate(0, -90, 0, Space.World);
            }
            else if (i == 21)
            {
                workerMove1.transform.Rotate(0, 90, 0, Space.World);
                workerMove2.transform.Rotate(0, 90, 0, Space.World);
            }
            else if (i == 22)
            {
                spriteWorker1.material = bigHead;
                spriteWorker2.material = bigHead;
            }
            else if (i == 23)
            {
                workerMove1.transform.Rotate(0, -90, 0, Space.World);
                workerMove2.transform.Rotate(0, -90, 0, Space.World);
            }
            else if (i == 25)
            {
                workerMove1.transform.Rotate(0, 90, 0, Space.World);
                workerMove2.transform.Rotate(0, 90, 0, Space.World);
            }
            else if (i == 26)
            {
                workerMove1.transform.Rotate(0, 90, 0, Space.World);
                workerMove2.transform.Rotate(0, 90, 0, Space.World);
            }

            if (i % 2 == 0)
            {
                workerMove1.SetActive(true);
                workerMove1.transform.position = spheres[i].transform.position;
                Destroy(spheres[i]);
                workerMove2.SetActive(false);
                timeToMove = 0.3f;
            }
            else if (i % 2 == 1)
            {
                workerMove2.SetActive(true);
                workerMove2.transform.position = spheres[i].transform.position;
                Destroy(spheres[i]);
                workerMove1.SetActive(false);
                timeToMove = 0.3f;
            }
            i++;
        }

        if (i == spheres.Length && GameController.boolSetUp2 && !GameController.gamePause)
        {
            timeToTilt -= Time.deltaTime;
            if (timeToTilt <= 0)
            {
                GameObject gameControllerObject = GameObject.Find("GameController");
                GameController gameController = gameControllerObject.GetComponent<GameController>();
                gameController.updateScore();
                timeToTilt = 5f;
            }
            warning.SetActive(true);
        }
        else
            warning.SetActive(false);
    }
}

