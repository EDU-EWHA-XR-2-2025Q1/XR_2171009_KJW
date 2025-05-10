using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : MonoBehaviour
{
    private int index;

    public void SetIndex(int i)
    {
        index = i;
    }

    void OnMouseDown()
    {
        GameManager.Instance.PickItem(index);
        Destroy(gameObject);
    }
}
