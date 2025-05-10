using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutTarget : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Heart"))
        {
            Destroy(other.gameObject);  // heart 제거
            GameManager.Instance.putCount++;  // count 처리
            Debug.Log("heart put 완료");
        }
    }
}
