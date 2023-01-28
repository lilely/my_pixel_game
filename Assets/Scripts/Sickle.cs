using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickle : MonoBehaviour
{
    public float speed;
    public float damage;
    public float rotateSpeed;
    public float tunning;
    
    private Rigidbody2D rb2d;
    private Transform playerTransform;
    private Transform sickleTransform;
    private Vector2 startSpeed;
    private int sign;

    private CameraShake camShake;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * speed;
        sign = 1;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sickleTransform = GetComponent<Transform>();
        startSpeed = rb2d.velocity;
        camShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed);
        float y = Mathf.Lerp(transform.position.y, playerTransform.position.y, tunning);
        if(startSpeed.x > 0) {
            sign = transform.position.x > playerTransform.position.x ? 1 : -1;
        } else {
            sign = transform.position.x > playerTransform.position.x ? -1 : 1;
        }
        
        rb2d.velocity = rb2d.velocity - Time.deltaTime * startSpeed * sign;
        transform.position = new Vector3(transform.position.x, y, 0);
        var heading = playerTransform.position - transform.position;
        if(Mathf.Abs(heading.magnitude) < 0.5) {
            Destroy(gameObject);
            playerTransform.Find("SickleHit").gameObject.GetComponent<SikleHit>().restoreAmm();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy")) {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
