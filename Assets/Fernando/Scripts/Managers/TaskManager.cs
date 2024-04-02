using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class TaskManager : MonoBehaviour
{
    [SerializeField]
    private GameManagerSO gM;

    [SerializeField]
    private Transform locationsHolder;

    [SerializeField]
    private Item[] itemsToSpawn;

    [SerializeField]
    private Bomb bombPrefab;

    [SerializeField]
    private int itemsToGetPerPlayer;

    [SerializeField]
    private Mesh[] meshes;

    [SerializeField]
    private Sprite[] playersIcons;


    private bool itemsRequested;
    private List<Transform> locations = new List<Transform>();


    int indice = 0;
    private void Awake()
    {
        foreach (Transform tr in locationsHolder)
        {
            locations.Add(tr);
        }
    }
    private void Start()
    {
        SpawnRandomItems();
    }

    private void OnEnable()
    {
        //gM.OnMissionStarts += SpawnRandomItems;

    }

    private void SpawnRandomItems()
    {
        if(!itemsRequested)
        {
            foreach (Player pl in gM.Players)
            {
                for (int i = 0; i <itemsToGetPerPlayer; i++)
                {
                    Item item = itemsToSpawn[Random.Range(0, itemsToSpawn.Length)];
                    item.ItemIconImage.sprite = playersIcons[indice];
                    int randomLocationIndex = Random.Range(0, locations.Count);
                    Instantiate(item, locations[randomLocationIndex].position, Quaternion.identity);

                    //Otorgarle a cada player una misión.
                    PlayerTaskSystem plTaskSystem = pl.SharedData.TaskSystem;
                    plTaskSystem.ItemsRequested.Add(item.MyData);

                    locations.RemoveAt(randomLocationIndex); //Para que no se spawneen mas de una cosa en un mismo index.
                }
                SpawnBomb();
                indice++;
            }
            itemsRequested = true;

        }
    }

    private void SpawnBomb()
    {
        int randomLocationIndex = Random.Range(0, locations.Count);
        Bomb bombClone = Instantiate(bombPrefab, locations[randomLocationIndex].position, Quaternion.identity);
        bombClone.GetComponent<MeshFilter>().sharedMesh = meshes[Random.Range(0, meshes.Length)];
        bombClone.ItemIconImage.sprite = playersIcons[indice];
    }
}
