using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    public float health;
    public float damage;
    public float flashTime;
    public GameObject bloodEffect;
    public GameObject GiftItem;
    public GameObject FloatPointBase;
    private SpriteRenderer sr;
    private Color originalColor;
    // Start is called before the first frame update
    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    // Update is called once per frame
    public void Update()
    {
        if(health <= 0) {
            Instantiate(GiftItem, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage) {
        Debug.Log("taking damage");
        GameObject floatPointBase = Instantiate(FloatPointBase, transform.position, Quaternion.identity) as GameObject;
        floatPointBase.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();
        health -= damage;
        FlashColor(flashTime);
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        GlobalObject.cameraShake.Shake();
    }

    void FlashColor(float time) {
        sr.color = Color.red;
        Invoke("ResetColor",time);
    }

    void ResetColor()
    {
        sr.color = originalColor;
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Trigger enemy hit collider");
        if(other.gameObject.CompareTag("Player")) {
            Debug.Log("Hit an enemy");
            other.GetComponent<PlayerHealth>().DamagePlayer(damage);
        }
    }
}
