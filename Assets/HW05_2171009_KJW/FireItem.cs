using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireItem : MonoBehaviour
{
    public GameObject heartPrefab;
    public Transform firePoint;
    public Transform aimPoint; 
    public float speed = 5f;

    public void Fire()
    {
        if (GameManager.Instance.pickCount <= 0)
        {
            Debug.Log("Pick Count ºÎÁ·");
            return;
        }

        GameObject heart = Instantiate(heartPrefab, firePoint.position, Quaternion.identity);
        Rigidbody rb = heart.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 direction = (aimPoint.position - firePoint.position).normalized;
            rb.velocity = direction * speed;
        }
        GameManager.Instance.pickCount--;
        Debug.Log("heart ¹ß»çµÊ!");
    }
}
