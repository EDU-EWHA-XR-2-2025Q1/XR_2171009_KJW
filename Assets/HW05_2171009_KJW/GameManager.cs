using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int pickCount = 0;
    public int putCount = 0;
    public bool[] pickedStatus = new bool[10];

    public TMP_Text pickText;
    public TMP_Text putText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 넘어가도 파괴되지 않음
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PickItem(int index)
    {
        if (!pickedStatus[index])
        {
            pickedStatus[index] = true;
            //pickCount++;
        }
    }
    void TryFindUI()
    {
        GameManager.Instance.pickText = GameObject.Find("PickText")?.GetComponent<TMP_Text>();
        GameManager.Instance.putText = GameObject.Find("PutText")?.GetComponent<TMP_Text>();
    }
    void Update()
    {
        if ((pickText == null || putText == null) && Time.timeSinceLevelLoad > 0.2f)
        {
            TryFindUI();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            GameManager.Instance.pickText = GameObject.Find("PickText")?.GetComponent<TMP_Text>();
            GameManager.Instance.putText = GameObject.Find("PutText")?.GetComponent<TMP_Text>();
            Debug.Log("수동 UI 연결 시도됨");
        }

        if (pickText != null)
            pickText.text = "Pick Count: " + pickCount;

        if (putText != null)
            putText.text = "Put Count: " + putCount;
    }
    public void PickItem()
    {
        pickCount++;
    }

    public void PutItem()
    {
        putCount++;
        pickCount--;
    }
}
