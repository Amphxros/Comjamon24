using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Item")]
public class ItemSO : ScriptableObject
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private Item prefab;
}
