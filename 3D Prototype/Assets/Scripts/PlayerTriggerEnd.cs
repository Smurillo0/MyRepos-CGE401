using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTriggerEnd : MonoBehaviour
{
    public Text textbox;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EndZone"))
        {
            textbox.text = "You Win!";
        }
    }


}
