using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TwoPlayersSession : MonoBehaviour
{
    [SerializeField]
    private GameManagerSO gM;

    private void Awake()
    {
        gM.SpawnPlayer();
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
