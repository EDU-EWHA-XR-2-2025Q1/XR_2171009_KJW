using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawnrOnTarget : MonoBehaviour
{
    public GameObject heartPrefab;
    public Transform parentTransform;
    public Vector3 basePosition = new Vector3(0, 0.05f, 0);
    public float spacing = 0.0025f;

    void Start()
    {
        Debug.Log("ItemSpawner Start() �����");

        for (int i = 0; i < 10; i++)
        {
            if (!GameManager.Instance.pickedStatus[i])
            {
                Vector3 pos = basePosition + new Vector3(i * spacing, 0, 0);
                GameObject heart = Instantiate(heartPrefab, pos, Quaternion.identity, parentTransform);
                heart.GetComponent<HeartItem>().SetIndex(i);
                Debug.Log($"��Ʈ ����: �ε��� {i}");
            }
        }
    }

}
