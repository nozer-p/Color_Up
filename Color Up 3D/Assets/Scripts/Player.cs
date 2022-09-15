using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject follower;
    [SerializeField] private float speedRun;
    [SerializeField] private float speedRot;

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
        transform.position = Vector3.Lerp(transform.position, follower.transform.position, Time.deltaTime * speedRun);

        Vector3 dir = follower.transform.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, speedRot * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}