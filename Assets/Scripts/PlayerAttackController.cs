using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public float damage;
    public float attckInterval;
    public float prepareInterval;
    private Animator anim;
    private PolygonCollider2D myCollider;
    private PlayerInputAction controls;

    void Awake() {
        controls = new PlayerInputAction();
        controls.GamePlay.Attack.started += ctx => Attack();
    }

    void OnEnable() {
        controls.GamePlay.Enable();
    }

    void OnDisable() {
        controls.GamePlay.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        myCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Attack();
    }

    void Attack()
    {
        // if(Input.GetButtonDown("Attack") && GlobalObject.isGameAlive == true) {
            Debug.Log("Begin attack");
            anim.SetTrigger("attack");
            StartCoroutine(enableHitBox());
        // }
    }

    IEnumerator enableHitBox() 
    {
        yield return new WaitForSeconds(prepareInterval);
        myCollider.enabled = true;
        StartCoroutine(disableHitBox());
    }

    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(attckInterval);
        myCollider.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Trigger player attack collider");
        if(other.gameObject.CompareTag("Enemy")) {
            Debug.Log("Hit an enemy");
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
