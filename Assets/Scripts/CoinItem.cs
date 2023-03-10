using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.GetType().ToString());
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D") {
            Debug.Log("Get an coin");
            AudioManager.playPickCoinClip();
            CoinQuantity.currentCoin += 1;
            Destroy(gameObject);
        }
    }
}
