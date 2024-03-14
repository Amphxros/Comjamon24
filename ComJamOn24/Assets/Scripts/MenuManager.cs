using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    [SerializeField] RectTransform creditsPanel;
    [SerializeField] RectTransform controlsPanel;

    public void GoToGame()
    {
        GameManager.Instance.getSceneManagment().ChangeScene("SampleScene");
    }

    public void openCredits()
    {
        creditsPanel.gameObject.SetActive(true);
        controlsPanel.gameObject.SetActive(false);
    }

    public void openControls()
    {
        creditsPanel.gameObject.SetActive(false);
        controlsPanel.gameObject.SetActive(true);
    }

}
