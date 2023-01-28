using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float waitTime;
    public float boomTime;
    public float explordRangeTime;
    public GameObject ExpRange;
    public Vector2 startVelocity;
    
    private Vector2 originVelocity;
    private Animator anim;
    private Rigidbody2D rd2d;
    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        originVelocity = rd2d.velocity;
        rd2d.velocity = transform.right * startVelocity.x + transform.up * startVelocity.y;
        Invoke("Explord", waitTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explord() {
        anim.SetTrigger("boom");
        Invoke("ExplordRangeComeOut",explordRangeTime);
        Destroy(gameObject, boomTime);
    }

    void ExplordRangeComeOut() {
        Instantiate(ExpRange, transform.position, Quaternion.identity);
    }

}
