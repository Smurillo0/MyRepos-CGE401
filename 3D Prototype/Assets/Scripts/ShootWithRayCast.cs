/*
 * Sarahi Murillo
 * 3D Prototype 
 * Using ratcast, if button is pressed then it triggers the shoot method which calls on Raycast to shoot.
 * Added ParticleSyetem obj to attach muzzleFlash 
 * added a force when objects are hit
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ShootWithRayCast : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera cam;

    // adding a reference 
    public ParticleSystem muzzleFlash;

    //Adding variable
    public float hitForce = 10f;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // calling on muzzleFlash obj to play 

        muzzleFlash.Play();

        RaycastHit hitInfo;

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range ))
        {
            Debug.Log(hitInfo.transform.gameObject.name);

            //Get Target script off the hit object 
            Target target = hitInfo.transform.gameObject.GetComponent<Target>();    

            //if target script found, make target take damage 
            if(target != null ) 
            {
                target.TakeDamage(damage);

                //if you want to have it be true for all rigidbodies, move if-statement outside of if(target != null)
                //if shot hits the rigidbody, apply force
                if(hitInfo.rigidbody != null)
                { 
                    hitInfo.rigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
                }
            }

        }
    }
}
