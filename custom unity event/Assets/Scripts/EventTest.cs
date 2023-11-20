using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTest : MonoBehaviour
{
    public UnityEvent myEvent;

    public List<UnityEvent> myListOfEvents;

    

    // Start is called before the first frame update
    void Start()
    {
        myEvent.AddListener(TestMethod);
        //myEvent.Invoke();

    }

    void TestMethod()
    {
        Debug.Log("Test method activated");
    }

}
