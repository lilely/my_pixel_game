using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Trigger spike");
        Debug.Log("Hit box:"+other.GetType().ToString());
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D") {
            Debug.Log("Spike hit player");
            other.GetComponent<PlayerHealth>().DamagePlayer(damage);
        }
    }
}
