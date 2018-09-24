using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Like : MonoBehaviour {

    private void OnMouseDown()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
