using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleAnimatorController : MonoBehaviour
{
    public Animator animator;
    public int direction = 0;

    public void PlayToRoom2()
    {

        direction = 1;
        animator.SetInteger("ridestat", 1);
        animator.speed = 1;
    }

    public void PlayToRoom1()
    {
        direction = 2;
        animator.SetInteger("ridestat", 2);
        animator.speed = 1;
    }

    public void Pause()
    {
        animator.speed = 0;

        // 도중 멈춤 상태값 저장
        if (direction == 1)
        {
            animator.SetInteger("ridestat", 5); // Room2로 가다 멈춤
            print("멈춤");
        }
            
        else if (direction == 2)
            animator.SetInteger("ridestat", 6); // Room1로 가다 멈춤
    }

    public void Resume()
    {
        animator.speed = 1;

        int status = animator.GetInteger("ridestat");

        if (status == 5)
            animator.SetInteger("ridestat", 1); // 다시 Room2로
        else if (status == 6)
            animator.SetInteger("ridestat", 2); // 다시 Room1로
    }
    void Update()
    {
        float currentPos = transform.position.z;
        int ridestat = animator.GetInteger("ridestat");

        // Room1 → Room2 가는 중 → Room2 위치에 도착하면
        if ((ridestat == 1 || ridestat == 5) && Mathf.Abs(currentPos - (-22.3f)) < 0.5f)
        {
            animator.SetInteger("ridestat", 3);
            animator.speed = 0;
            Debug.Log("Room2 위치 도착 → ridestat = 3");
        }

        // Room2 → Room1 가는 중 → Room1 위치에 도착하면
        else if ((ridestat == 2 || ridestat == 6) && Mathf.Abs(currentPos - 22.9f) < 0.5f)
        {
            animator.SetInteger("ridestat", 4);
            animator.speed = 0;
            Debug.Log("Room1 위치 도착 → ridestat = 4");
        }


    }
}
