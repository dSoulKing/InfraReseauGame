using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutoScript : MonoBehaviour
{

    Image m_image;

    public Sprite page1;
    public Sprite page2;
    public Sprite page3;
    public Sprite page4;

    public GameObject backButton;
    public GameObject nextButton;
    public GameObject playButton;

    private int pageTutoNb;

    void Start()
    {
        pageTutoNb = 1;
        m_image = GetComponent<Image>();
    }

    void Update()
    {
        if (pageTutoNb == 1)
        {
            m_image.sprite = page1;
            backButton.SetActive(false);
        }
        else if (pageTutoNb == 2)
        {
            m_image.sprite = page2;
            backButton.SetActive(true);
        }
        else if (pageTutoNb == 3)
        {
            m_image.sprite = page3;
            nextButton.SetActive(true);
            playButton.SetActive(false);
        }
        else if (pageTutoNb == 4)
        {
            m_image.sprite = page4;
            nextButton.SetActive(false);
            playButton.SetActive(true);
        }
    }

    public void NextButton()
    {
        if (pageTutoNb < 4)
            pageTutoNb++;
    }

    public void BackButton()
    {
        if (pageTutoNb > 1)
            pageTutoNb--;
    }

    public void changeMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void changePlayScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}

