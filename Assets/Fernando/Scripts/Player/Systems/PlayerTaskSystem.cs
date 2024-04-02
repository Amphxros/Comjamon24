using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerTaskSystem : PlayerSystem
{
    [SerializeField]
    private LayerMask whatIsExit;

    private List<ItemSO> itemsRequested = new List<ItemSO>();

    public List<ItemSO> ItemsRequested { get => itemsRequested; }



    protected override void Awake()
    {
        base.Awake();

        mainScript.SharedData.TaskSystem = this;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(itemsRequested.Count == 0) return;

        CarSystem currentCarSystem = mainScript.SharedData.CarSystem;
        if (((1 << other.gameObject.layer) & whatIsExit) != 0)
        {
            if(itemsRequested.All(currentCarSystem.ItemsCollected.Contains))
            {
                mainScript.GM.FinDePartida();
            }
        }
    }
}
