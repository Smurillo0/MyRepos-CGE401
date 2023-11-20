using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseClick : MonoBehaviour
{
    private EventTest eventTest;


    // Start is called before the first frame update
    void Start()
    {
        eventTest = GameObject.FindObjectOfType<EventTest>();
    }


    private void OnMouseDown()
    {
        eventTest.myEvent.Invoke();
    }
}
