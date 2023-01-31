using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SikleHit : MonoBehaviour
{
    public GameObject sickle;
    public int maxAmmCount;

    private int ammCount;
    private PlayerInputAction controls;

    void Awake() {
        controls = new PlayerInputAction();
        controls.GamePlay.SpecalAttack.started += ctx => Attack();
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
        ammCount = maxAmmCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U) && ammCount > 0) {
            Instantiate(sickle, transform.position, transform.rotation);
            ammCount -= 1;
        }
    }

    void Attack() {
        if(ammCount > 0) {
            Instantiate(sickle, transform.position, transform.rotation);
            ammCount -= 1;
        }
    }

    public void restoreAmm() {
        ammCount += 1;
        Debug.Log("Amm Restored!!");
    }
}
