using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class Health : MonoBehaviour
{
    public Text healthText;
    public static float healthCurrent;
    public static float healthMax;

    private Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        Debug.Log("Current Health" + healthMax);
        healthCurrent = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Current health: " + healthCurrent);
        healthBar.fillAmount = (float)healthCurrent / (float)healthMax;
        healthText.text = healthCurrent.ToString() + "/" + healthMax.ToString();
    }
}
