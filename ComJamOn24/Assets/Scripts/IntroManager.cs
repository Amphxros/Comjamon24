using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] float timeinSecs;

    private void Update()
    {
        if (GameManager.Instance.getSceneManagment() != null)
        {

            GameManager.Instance.getSceneManagment().ChangeScene("Menu");
        }
    }
}
