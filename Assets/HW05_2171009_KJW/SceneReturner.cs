using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReturner : MonoBehaviour
{
    public void GoToScene01()
    {
        SceneManager.LoadScene("Scene01");
    }
}
