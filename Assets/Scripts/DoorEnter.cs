using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnter : MonoBehaviour
{
    public Transform outDoorTransform;

    private Transform playerTransform;
    private PlayerInputAction controls;
    private bool canEnter;
    void Awake() {
        controls = new PlayerInputAction();
        controls.GamePlay.Enter.started += ctx => EnterDoor();
    }

    void OnEnable() {
        controls.GamePlay.Enable();
    }

    void OnDisable() {
        controls.GamePlay.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        canEnter = false;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnterDoor() {
        if(canEnter) {
            Debug.Log("call EnterDoor");
            playerTransform.position = outDoorTransform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") &&  other.GetType().ToString() == "UnityEngine.CapsuleCollider2D") {
            canEnter = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") &&  other.GetType().ToString() == "UnityEngine.CapsuleCollider2D") {
            canEnter = false;
        }
    }

}
