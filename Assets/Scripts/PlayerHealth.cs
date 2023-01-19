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
    private ScreenFlash screenFlash;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        Health.healthMax = health;
        Health.healthCurrent = health;
        myRender = GetComponent<Renderer>();
        screenFlash = GetComponent<ScreenFlash>();
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(float damage) {
        health -= damage;
        if(health < 0) health = 0;
        Health.healthCurrent = health;
        screenFlash.FlashScreen();
        if(health <= 0) {
            GlobalObject.isGameAlive = false;
            rb2d.velocity = new Vector2(0,0);
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
