using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideController : MonoBehaviour
{


    //public Animator Animator;
    public VehicleAnimatorController vehicle;
    public GameObject player;

    // ridestat=1 -> room1->room2 가는 길
    // ridestat=2 -> room2->room1 가는 길
    // ridestat=3 -> room2에서 멈춰있음
    // ridestat=4 -> room1에서 멈춰있음
    // ridestat=5 -> room2로 가다 멈춤
    // ridestat=6 -> room1으로 가다 멈춤
    // 중간에 내리면 ridestat=5 or 6으로 설정

    private bool isRiding = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Vehicle" && !isRiding)
        {
            print("ride");
            isRiding = true;

            transform.SetParent(other.transform);
            transform.position = other.transform.position + Vector3.up * 2f;

            int state = vehicle.animator.GetInteger("ridestat");
            // 도착 상태일 경우 반대 방향으로 출발
            if (state == 3) // Room2에 도착함 → Room1로
            {
                vehicle.PlayToRoom1();
            }
            else if (state == 4) // Room1에 도착함 → Room2로
            {
                vehicle.PlayToRoom2();
            }

            // 이동 중 멈춤 상태였으면 → 다시 이어서
            else if (state == 5 || state == 6)
            {
                vehicle.Resume();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Vehicle" && isRiding)
        {
            isRiding = false;
            transform.SetParent(null);

            vehicle.Pause(); // 애니메이션 멈춤 + 상태 저장
        }
    }

}
