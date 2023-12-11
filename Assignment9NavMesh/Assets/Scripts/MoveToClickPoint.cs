using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();   

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            //vector of position where mouse was clicked
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //if hit, put in new destination
            if(Physics.Raycast(ray, out hit))
            {
                agent.destination = hit.point;
            }
            
        }
    }
}
