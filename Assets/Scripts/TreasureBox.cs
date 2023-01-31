using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    public GameObject Item;
    public float gainDelayTime;

    private Animator anim;
    private bool canOpenBox;
    private bool opened;
    // Start is called before the first frame update
    void Start()
    {
        canOpenBox = false;
        opened = false;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canOpenBox && !opened) {
            if(Input.GetKeyDown(KeyCode.I)) {
                opened = true;
                anim.SetTrigger("opening");
                Invoke("GainItem", gainDelayTime);
            }
        }
    }

    void GainItem() {
        Instantiate(Item, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            canOpenBox = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            canOpenBox = false;
        }
    }
}
