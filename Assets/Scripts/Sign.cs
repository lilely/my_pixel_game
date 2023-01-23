using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public Text signLabel;
    public String text;

    private bool isInDialog;
    // Start is called before the first frame update
    void Start()
    {
        signLabel.text = text;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInDialog) {
            dialogBox.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered Sign");
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D") {
            Debug.Log("Get an sign");
            isInDialog = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D") {
            Debug.Log("Out of an sign");
            isInDialog = false;
            dialogBox.SetActive(false);
        }
    }
}
