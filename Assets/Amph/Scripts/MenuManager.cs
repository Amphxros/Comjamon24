using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private int num_players;
    [SerializeField] GameObject characterPanel;
    private CharacterData[] characterData;
    void Start()
    {
        num_players = transform.childCount;
        characterData = new CharacterData[num_players];
    }

    public void addPlayer()
    {

    }

    public void addElem()
    {
        if (num_players < 4)
        {
            Instantiate(characterPanel, this.transform);
            num_players++;
        }
    }

}
