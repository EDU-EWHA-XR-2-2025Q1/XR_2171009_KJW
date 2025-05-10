using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{
    void OnMouseDown()
    {
        gameObject.SetActive(false); // heart 사라짐
        GameManager.Instance.PickItem(); // Pick Count 증가
    }
}
