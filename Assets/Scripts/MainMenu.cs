using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Slider slider;
    public Text progressText;
    public GameObject loadingScreen;

    public void LoadLevel(int sceneIndex) {
        StartCoroutine(AsyncLoadLevel(sceneIndex));
    }

    IEnumerator AsyncLoadLevel(int sceneIndex) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while(! operation.isDone) {
            float progress = operation.progress / 0.9f;
            slider.value = progress;
            progressText.text = Mathf.FloorToInt(progress * 100f).ToString() + "%";
            yield return null;
        }
    }

    public void QuitAction() {
        Application.Quit();
    }
}
