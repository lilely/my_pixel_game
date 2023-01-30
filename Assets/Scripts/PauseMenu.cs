using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject mainMenu;

    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Pause() {
        if(!isPaused) {
            mainMenu.SetActive(true);
            isPaused = true;
            Time.timeScale = 0.0f;
        }
    }

    public void Resume() {
        if(isPaused) {
            mainMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1.0f;
        }
    }

    public void MainMenu() {
        isPaused = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit() {
        Application.Quit();
    }
}
