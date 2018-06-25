using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWorker : MonoBehaviour {

    public GameObject worker1;
    public GameObject worker2;

    private int random;
    private float moveTime;
    private int numChildren;
    private int i = 0;
    private GameObject randomTravelLoad;
    private GameObject randomTravel;
    private bool boolTravel;
    private GameObject[] spheres;

    void Start () {
        random = Random.Range(1, 13);
        randomTravelLoad = Resources.Load("Travel" + random, typeof(GameObject)) as GameObject;
        randomTravel = Instantiate(randomTravelLoad, randomTravelLoad.transform.position, randomTravelLoad.transform.rotation);
        numChildren = randomTravelLoad.transform.childCount;
        Debug.Log(numChildren);
        moveTime = 1;
        spheres = new GameObject[numChildren];
        for (int y = 0; y < numChildren; y++)
        {
            spheres[y] = randomTravel.transform.GetChild(y).gameObject;
        }

    }
	
	void Update () {

        moveTime -= Time.deltaTime;

        if (i < numChildren && moveTime < 0)
        {
            if (i % 2 == 0)
            {
                worker1.SetActive(true);
                worker2.SetActive(false);
            }
            else if (i % 2 == 1)
            {
                worker2.SetActive(true);
                worker1.SetActive(false);
            }
            gameObject.transform.position = spheres[i].transform.position;
            Debug.Log(i);
            Destroy(spheres[i]);
            moveTime = 1;
            i++;
        }
    }
}
