﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public void ChoiceScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
