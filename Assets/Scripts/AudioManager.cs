using System.Runtime.Versioning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioSource audioSrc;
    public static AudioClip pickCoin;
    public static AudioClip throwCoin; 
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        pickCoin = Resources.Load<AudioClip>("PickCoin");
        throwCoin = Resources.Load<AudioClip>("ThrowCoin");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playPickCoinClip() {
        audioSrc.PlayOneShot(pickCoin);
    }

    public static void playThrowCoinClip() {
        audioSrc.PlayOneShot(throwCoin);
    }
}
