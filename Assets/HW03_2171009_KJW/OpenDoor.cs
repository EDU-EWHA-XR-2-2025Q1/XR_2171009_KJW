using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator Animator;
    public GameObject player;
    private OnFloor onFloorScript;

    void Start()
    {
        onFloorScript = player.GetComponent<OnFloor>();
    }

    private void OnTriggerEnter(Collider other)     // 문여는거
    {
        if ((Animator.GetInteger("status") == 4 || Animator.GetInteger("status")==5) && onFloorScript.isOnFloor1==true)
        {
            Animator.SetInteger("status", 1);
        }
        

        else if (Animator.GetInteger("status") == 2 && onFloorScript.isOnFloor1 == false)
        {
            Animator.SetInteger("status", 3);
        }

    }
    private void OnTriggerExit(Collider other)      // 문 닫는거
    {
        if (Animator.GetInteger("status") == 1 && onFloorScript.isOnFloor1 == false)
        {
            Animator.SetInteger("status", 2);

        }
        else if (Animator.GetInteger("status") == 3 && onFloorScript.isOnFloor1 == true)
        {
            Animator.SetInteger("status", 4);
        }

    }
}
