using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionMenuManager : MonoBehaviour
{
    public void OnClickStart(string sceneNameToLoad)
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
