using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject follower;
    [SerializeField] private float speed;

    private void Start()
    {
        follower = GameObject.FindGameObjectWithTag("Follower");
    }

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.position = Vector3.Lerp(transform.position, follower.transform.position, Time.deltaTime * speed);
        //transform.LookAt();
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}