using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject follower;
    [SerializeField] private float speedRun;
    [SerializeField] private float speedRot;

    private bool isMove;
    private Animator animator;
    private bool isDead;

    [SerializeField] private Rigidbody[] rigidbodies;

    private float timeStart;
    [SerializeField] private float timeStartDef;

    private void Start()
    {
        animator = GetComponent<Animator>();
        follower = GameObject.FindGameObjectWithTag("Follower");
        timeStart = timeStartDef;
        for(int i = 0; i < rigidbodies.Length; i++)
        {
            rigidbodies[i].isKinematic = true;
        }
    }

    private void Update()
    {
        if (!isDead)
        {
            MoveForward();
        }
        else
        {
            animator.enabled = false;
        }
    }

    private void MoveForward()
    {
        if (isMove)
        {
            if (timeStart < 0)
            {
                animator.SetBool("isRun", true);

                transform.position = Vector3.Lerp(transform.position, follower.transform.position, Time.deltaTime * speedRun);

                Vector3 dir = follower.transform.position - transform.position;
                Quaternion rot = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, speedRot * Time.deltaTime);
            }
            else
            {
                timeStart -= Time.deltaTime;
            }
        }
    }

    public void OffMove()
    {
        isMove = false;
    }

    public void OnMove()
    {
        isMove = true;
    }

    public void Die()
    {
        isDead = true;

        for (int i = 0; i < rigidbodies.Length; i++)
        {
            rigidbodies[i].isKinematic = false;
        }
    }

    public void Victory()
    {
        OffMove();
        animator.SetBool("isVictory", true);
    }
}