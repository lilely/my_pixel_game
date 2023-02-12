using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class WeaponGun : MonoBehaviour
{
    public Camera cam;
    public GameObject bullet;
    public Transform shootPoint;

    private Vector3 mousePos;
    private Vector2 gunDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        gunDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
        if(Mouse.current.leftButton.wasPressedThisFrame) {
            Fire();
        }
    }

    void Fire() {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
