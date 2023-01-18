using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float smoothing;
    public float offsetX;
    public float offsetY;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        GlobalObject.cameraShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
    }

    void LateUpdate() {
        if(target != null) {
            if(transform.position != target.position) {
                Vector3 targetPos = target.position;
                targetPos.x += offsetX;
                targetPos.y += offsetY;
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
