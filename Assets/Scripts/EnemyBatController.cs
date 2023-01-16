using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBatController : Enemy
{
    public Transform leftDownPos;
    public Transform rightUpPos;
    public Transform movePos;
    public float speed;
    public float waitTimeInterval;

    private float waitTime;
    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        waitTime = waitTimeInterval;
        movePos.position = GetRandomPos();
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, movePos.position) < 0.1f) {
            if(waitTime <= 0.1) {
                movePos.position = GetRandomPos();
                waitTime = waitTimeInterval;
            } else {
                waitTime -= Time.deltaTime;
            }
        }

    }

    Vector2 GetRandomPos()
    {
        Vector2 newPos = new Vector2(Random.Range(leftDownPos.position.x,rightUpPos.position.x),Random.Range(leftDownPos.position.y,rightUpPos.position.y));
        return newPos;
    }
}
