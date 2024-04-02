using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPlane : MonoBehaviour
{
    [SerializeField]
    private GameManagerSO gM;


    private void Awake() => gM.WorldPlane = transform;
   
}
