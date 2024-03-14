using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.createSceneManagment(this);
        DontDestroyOnLoad(gameObject);
        transform.parent = GameManager.Instance.gameObject.transform;
    }
    public void ChangeScene(string name)
    {

        SceneManager.LoadScene(name);
        
    }

    public void GoBack()
    {
        

    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
