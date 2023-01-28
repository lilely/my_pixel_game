using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SikleHit : MonoBehaviour
{
    public GameObject sickle;
    public int maxAmmCount;

    private int ammCount;
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

    public void restoreAmm() {
        ammCount += 1;
        Debug.Log("Amm Restored!!");
    }
}
