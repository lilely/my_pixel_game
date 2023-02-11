using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatDestroy : MonoBehaviour
{
    public int destoryTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        EasterEgg.password += destoryTag.ToString();
    }
}
