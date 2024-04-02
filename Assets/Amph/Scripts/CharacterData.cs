using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    private int character = 0;

    private int ID; //player number
    MenuManager menuManager;

    private void OnEnable()
    {
        ID= transform.GetSiblingIndex();

        menuManager = GetComponentInParent<MenuManager>();
        menuManager.addPlayer();
        
    }


}

