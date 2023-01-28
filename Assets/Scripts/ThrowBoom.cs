using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBoom : MonoBehaviour
{
    public GameObject Boom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)) {
            Instantiate(Boom, transform.position, transform.rotation);
        }
    }
}
