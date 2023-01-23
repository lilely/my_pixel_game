using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CameraFollower : MonoBehaviour
{
    public float smoothing;
    public float offsetX;
    public float offsetY;
    public Vector2 minPosition;
    public Vector2 maxPosition;
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
                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }

    void SetLimitPosition(Vector2 minPos, Vector2 maxPos) {
        minPosition = minPos;
        maxPosition = maxPos;
    }
}
