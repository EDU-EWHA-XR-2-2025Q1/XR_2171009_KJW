using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutRepoMover : MonoBehaviour
{
    public Vector3 center = Vector3.zero; 
    public float range = 0.2f;             

    void Start()
    {
        StartCoroutine(MoveRandomly());
    }

    IEnumerator MoveRandomly()
    {
        while (true)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-range, range),
                0,
                Random.Range(-range, range)
            );

            transform.localPosition = center + randomOffset;

            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        }
    }
}
