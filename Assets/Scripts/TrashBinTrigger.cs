using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBinTrigger : MonoBehaviour
{
    private bool isNearTrashBin;
    private PlayerInputAction controls;

    void Awake() {
        controls = new PlayerInputAction();
        controls.GamePlay.Enter.started += ctx => ThrowCoin();
    }

    void OnEnable() {
        controls.GamePlay.Enable();
    }

    void OnDisable() {
        controls.GamePlay.Disable();
    }
    // Start is called before the first frame update
    void Start() {

    }
    void Update()
    {

    }

    void ThrowCoin() {
        if(isNearTrashBin) {
            if(CoinQuantity.currentCoin > 0) {
                AudioManager.playThrowCoinClip();
                TrashBinCoin.currentTrashBinCoin += 1;
                CoinQuantity.currentCoin -= 1;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D") {
            Debug.Log("Near an trashbin");
            isNearTrashBin = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D") {
            Debug.Log("Away from a trashbin");
            isNearTrashBin = false;
        }
    }
}
