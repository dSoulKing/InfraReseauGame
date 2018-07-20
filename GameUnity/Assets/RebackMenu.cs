using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RebackMenu : MonoBehaviour {

    private void OnMouseDown()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
