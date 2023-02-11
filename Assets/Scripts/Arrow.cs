using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float damage;
    public float disappearDistance;
    public float speed;

    private Vector3 startPos;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (transform.position - startPos).sqrMagnitude;
        if(distance > disappearDistance) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy")) {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
