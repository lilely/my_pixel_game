using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public string easterEggPassword;
    public static string password;

    public GameObject item;
    public int quantity;
    public float jetInterval;
    public float coinUpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        password = "";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("password is now: " + password);
        if(password == easterEggPassword) {
            Debug.Log("触发彩蛋");
            password = "";
            StartCoroutine(GenCoins());
        }
    }

    IEnumerator GenCoins() {
        WaitForSeconds wait = new WaitForSeconds(jetInterval);
        for(int i = 0; i < quantity;i++) {
            GameObject gb = Instantiate(item, transform.position, Quaternion.identity);
            Vector2 randomDirection = new Vector2(Random.Range(-0.3f, 0.3f), 1.0f);
            gb.GetComponent<Rigidbody2D>().velocity = randomDirection * coinUpSpeed;
            yield return wait;
        }
    }
}
