using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartAction() {
        SceneManager.LoadScene(1);
    }

    public void QuitAction() {
        Application.Quit();
    }
}
