using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinQuantity : MonoBehaviour
{
    public Text coinLabel;
    public int coinQuantity;
    // Start is called before the first frame update
    private int currentCoin;
    void Start()
    {
        currentCoin = coinQuantity;
    }

    // Update is called once per frame
    void Update()
    {
        coinLabel.text = currentCoin.ToString();
    }
}
