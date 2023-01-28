using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorToNextScene : MonoBehaviour
{
    private bool canOpenDoor;
    // Start is called before the first frame update
    void Start()
    {
        canOpenDoor = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(canOpenDoor) {
            if(Input.GetKeyDown(KeyCode.I)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") &&  other.GetType().ToString() == "UnityEngine.CapsuleCollider2D") {
            canOpenDoor = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") &&  other.GetType().ToString() == "UnityEngine.CapsuleCollider2D") {
            canOpenDoor = false;
        }
    }
}
