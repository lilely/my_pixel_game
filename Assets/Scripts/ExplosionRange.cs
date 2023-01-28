using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRange : MonoBehaviour
{
    public float damage;
    public float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("boom triggered!!!!");
        if(other.gameObject.CompareTag("Player")) {
            Debug.Log("Boom hit an enemy");
            other.GetComponent<PlayerHealth>().DamagePlayer(damage);
        }
        if(other.gameObject.CompareTag("Enemy")) {
            Debug.Log("Boom Hit an enemy");
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

}
