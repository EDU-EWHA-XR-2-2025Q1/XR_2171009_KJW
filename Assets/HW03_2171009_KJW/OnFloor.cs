using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFloor : MonoBehaviour
{
    public bool isOnFloor = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Floor")
        {
            isOnFloor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Floor")
        {
            isOnFloor = false;
        }
    } 

}
