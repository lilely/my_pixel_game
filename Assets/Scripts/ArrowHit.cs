using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour
{
    public GameObject arrow;
    private PlayerInputAction controls;

    void Awake() {
        controls = new PlayerInputAction();
        controls.GamePlay.ArrowHit.started += ctx => Shoot();
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot() {
        Instantiate(arrow, transform.position, transform.rotation);
    }
}
