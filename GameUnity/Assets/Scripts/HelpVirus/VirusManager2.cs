using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusManager2 : MonoBehaviour {

    public GameObject virus;
    public Transform parent;
    public SpriteRenderer backgroundComputer;
    public GameObject rebackButtonVirus;
    public GameObject loseText;
    public GameObject winText;
    public TextMesh computerLifeText;

    public bool virusStart = false;
    public static int computerLife2;
    public static bool enter;
    public static int nbVirusDestroy;

    private Vector3 spawnVirus;
    private float timeNewVirus;
    private bool active = true;
    private int nbVirus;
    private int random;
    public static bool losePointOk = false;

    void Start()
    {
        timeNewVirus = 5f;
        computerLife2 = 5;
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

        if (computerLife2 == 0)
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
        else
            computerLifeText.text = "Vies restantes : " + computerLife2;

        if (timeNewVirus <= 0 && active && nbVirus < 30)
        {
            random = Random.Range(1, 16);

            switch (random)
            {
                case 1:
                    spawnVirus = new Vector3(317.17f, 18.868001f, 6.8f);
                    break;

                case 2:
                    spawnVirus = new Vector3(315.83f, 18.868001f, 6.8f);
                    break;

                case 3:
                    spawnVirus = new Vector3(315.83f, 17.888001f, 6.8f);
                    break;

                case 4:
                    spawnVirus = new Vector3(315.83f, 17.038001f, 6.8f);
                    break;

                case 5:
                    spawnVirus = new Vector3(315.83f, 15.968001f, 6.8f);
                    break;

                case 6:
                    spawnVirus = new Vector3(315.83f, 15.188001f, 6.8f);
                    break;

                case 7:
                    spawnVirus = new Vector3(315.83f, 14.258001f, 6.8f);
                    break;

                case 8:
                    spawnVirus = new Vector3(317.04f, 14.258001f, 6.8f);
                    break;

                case 9:
                    spawnVirus = new Vector3(323.03f, 14.258001f, 6.8f);
                    break;

                case 10:
                    spawnVirus = new Vector3(324.51f, 14.258001f, 6.8f);
                    break;

                case 11:
                    spawnVirus = new Vector3(324.51f, 15.098001f, 6.8f);
                    break;

                case 12:
                    spawnVirus = new Vector3(324.51f, 15.888001f, 6.8f);
                    break;

                case 13:
                    spawnVirus = new Vector3(324.51f, 16.838001f, 6.8f);
                    break;

                case 14:
                    spawnVirus = new Vector3(324.51f, 17.828001f, 6.8f);
                    break;

                case 15:
                    spawnVirus = new Vector3(324.51f, 18.888001f, 6.8f);
                    break;

                case 16:
                    spawnVirus = new Vector3(323.27f, 18.888001f, 6.8f);
                    break;
            }

            GameObject instance = Instantiate(virus, spawnVirus, Quaternion.identity);
            instance.transform.parent = parent;
            timeNewVirus = 0.7f;
            nbVirus++;
        }

        if (nbVirusDestroy == 30)
        {
            rebackButtonVirus.SetActive(true);
            winText.SetActive(true);
        }
    }
}
