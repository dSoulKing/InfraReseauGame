using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusManager3 : MonoBehaviour {

    public GameObject virus;
    public Transform parent;
    public SpriteRenderer backgroundComputer;
    public GameObject rebackButtonVirus;
    public GameObject loseText;

    public bool virusStart = false;
    public static int computerLife3;
    public static bool enter;

    private Vector3 spawnVirus;
    private float timeNewVirus;
    private bool active = true;
    private int nbVirus;
    private int random;
    public static bool losePointOk = false;

    void Start()
    {
        timeNewVirus = 5f;
        computerLife3 = 5;
        enter = false;
        nbVirus = 0;

        virus.SetActive(true);
    }

    void Update()
    {
        if (enter)
            backgroundComputer.color = new Color(1F, 0.2F, 0.2F, 1F);
        else
            backgroundComputer.color = new Color(1F, 1F, 1F, 1F);

        if (virusStart)
        {
            timeNewVirus -= Time.deltaTime;
        }

        if (computerLife3 == 0)
        {
            timeNewVirus = 5000f;
            GameObject[] virus = GameObject.FindGameObjectsWithTag("virus");
            for (int i = 0; i < virus.Length; i++)
            {
                Destroy(virus[i]);
            }
            rebackButtonVirus.SetActive(true);
            losePointOk = true;
            active = false;
            loseText.SetActive(true);
        }

        if (timeNewVirus <= 0 && active && nbVirus < 30)
        {
            random = Random.Range(1, 16);

            switch (random)
            {
                case 1:
                    spawnVirus = new Vector3(317.17f, 34.25168f, 6.8f);
                    break;

                case 2:
                    spawnVirus = new Vector3(315.83f, 34.25168f, 6.8f);
                    break;

                case 3:
                    spawnVirus = new Vector3(315.83f, 33.27168f, 6.8f);
                    break;

                case 4:
                    spawnVirus = new Vector3(315.83f, 32.42168f, 6.8f);
                    break;

                case 5:
                    spawnVirus = new Vector3(315.83f, 31.35168f, 6.8f);
                    break;

                case 6:
                    spawnVirus = new Vector3(315.83f, 30.57168f, 6.8f);
                    break;

                case 7:
                    spawnVirus = new Vector3(315.83f, 29.64168f, 6.8f);
                    break;

                case 8:
                    spawnVirus = new Vector3(317.04f, 29.64168f, 6.8f);
                    break;

                case 9:
                    spawnVirus = new Vector3(323.03f, 29.64168f, 6.8f);
                    break;

                case 10:
                    spawnVirus = new Vector3(324.51f, 29.64168f, 6.8f);
                    break;

                case 11:
                    spawnVirus = new Vector3(324.51f, 30.48168f, 6.8f);
                    break;

                case 12:
                    spawnVirus = new Vector3(324.51f, 31.27168f, 6.8f);
                    break;

                case 13:
                    spawnVirus = new Vector3(324.51f, 32.22168f, 6.8f);
                    break;

                case 14:
                    spawnVirus = new Vector3(324.51f, 33.21168f, 6.8f);
                    break;

                case 15:
                    spawnVirus = new Vector3(324.51f, 34.27168f, 6.8f);
                    break;

                case 16:
                    spawnVirus = new Vector3(323.27f, 34.27168f, 6.8f);
                    break;
            }

            GameObject instance = Instantiate(virus, spawnVirus, Quaternion.identity);
            instance.transform.parent = parent;
            timeNewVirus = 0.7f;
            nbVirus++;
        }

        if (nbVirus == 30)
            rebackButtonVirus.SetActive(true);
    }
}
