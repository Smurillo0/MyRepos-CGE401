using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyy : MonoBehaviour
{
    [SerializeField] private string enemyName;
    [SerializeField] private float moveSpeed;
    private float healthpts;
    [SerializeField] private float maxHealthPoint;

    private Transform target;
    [SerializeField] private float distance;

    private void Start()
    {
        healthpts = maxHealthPoint;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
        Intro();
    }

    private void Update()
    {
        Move();
    }

    private void Intro()
    {
        Debug.Log("The name is " + enemyName + ", HP: " + healthpts + ", moveSpeed: " + moveSpeed);
    }

    private void Move()
    {
        if (Vector2.Distance(transform.position, target.position) < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed + Time.deltaTime);
        }
    }
}
