using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayCanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameManagerSO gM;

    [SerializeField]
    private GameObject endGamePanel;

    private void OnEnable()
    {
        gM.OnGameEnds += ShowPanel;
    }

    private void ShowPanel()
    {
        endGamePanel.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
