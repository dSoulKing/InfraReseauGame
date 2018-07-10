using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour {

    public static bool begin;

    public void ChangeMenuScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        begin = true;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
