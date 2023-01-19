using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public Transform[] movePoints;

    private Transform objParentTrans;
    private float time;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        time = waitTime;
        objParentTrans = GameObject.FindGameObjectWithTag("Player").transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePoints[i].position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, movePoints[i].position) < 0.1) {
            if(time <= 0.1) {
                if(i == 0) {
                    i = 1;
                } else {
                    i = 0;
                }
                time = waitTime;
            } else {
                time -= Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.GetType().ToString());
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D") {
            Debug.Log("On moving platform");
            other.transform.parent = transform;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D") {
            Debug.Log("Off moving platform");
            other.transform.parent = objParentTrans;
        }
    }
}
