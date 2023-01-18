using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float time;
    public int blinks;
    public float health;
    public float dieTime;

    private Renderer myRender;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        myRender = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(float damage) {
        health -= damage;
        if(health <= 0) {
            anim.SetTrigger("dead");
            Invoke("KillPlayer", dieTime);
        } else {
            BlinkPlayer(blinks, time);
        }
        
    }

    void KillPlayer() {
        Destroy(gameObject);
    }

    void BlinkPlayer(int runBlinks, float seconds) {
        StartCoroutine(DoBlinks(runBlinks,seconds));
    }

    IEnumerator DoBlinks(int runBlinks, float seconds) {
        for(int i = 0;i < runBlinks;i++) {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
    }
}
