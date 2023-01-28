using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class InitButton : MonoBehaviour
{
    private GameObject currentSelected;
    // Start is called before the first frame update
    void Start()
    {
        currentSelected =  new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.currentSelectedGameObject == null) {
            EventSystem.current.SetSelectedGameObject(currentSelected);
        } else {
            currentSelected = EventSystem.current.currentSelectedGameObject;
        }
    }
}
