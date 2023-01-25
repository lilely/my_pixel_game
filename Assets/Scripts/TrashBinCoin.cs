using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashBinCoin : MonoBehaviour
{
    // Start is called before the first frame update
    public Text coinNumber;
    public int maxTrashBinCoin;
    static public int currentTrashBinCoin;
    void Start()
    {
        currentTrashBinCoin = 0;
        maxTrashBinCoin = 99;
    }

    // Update is called once per frame
    void Update()
    {
        coinNumber.text = currentTrashBinCoin.ToString() + "/" + maxTrashBinCoin.ToString();
    }

}
