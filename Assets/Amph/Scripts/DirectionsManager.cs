using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DirectionsManager : MonoBehaviour
{
    [SerializeField] GameManagerSO gM;

    [SerializeField] List<Sprite> icons;
    [SerializeField] List<RectTransform> arrows;
    [SerializeField] float radius;

    [SerializeField] Item[] items;

    float width;
    float height;

    float centerX;
    float centerY;
    private void Start()
    {
        width = Screen.width;
        height = Screen.height;

        centerX = width / 2;
        centerY = height / 2;

       
    }

    private void Update()
    {

        int n = gM.Players.Count;
        float totalX=0, totalZ=0;

        foreach (Player p in gM.Players)
        {
            totalX += p.transform.position.x;
            totalZ += p.transform.position.z;
        }

        Vector2 mid = new Vector2(totalX/n, totalZ/n);

        foreach (RectTransform r in arrows)
        {
            r.gameObject.SetActive(false);
        }
        //falta que cuando un objeto se destruya se quite de esta lista 
        for (int i= 0; i< items.Length;i++)
        {
            Vector2 item= new Vector2(items[i].transform.position.x, items[i].transform.position.z) ;
            Vector2 dir = item - mid;

            if(dir.magnitude > radius) {
                dir.Normalize();
                arrows[i].gameObject.SetActive(true);
                arrows[i].transform.up = dir;

            }

           


            
        }

        
                
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.green;
        //foreach(Player p in gM.Players)
        //{
        //  foreach(Item i in items)
        //    {
        //        Gizmos.DrawLine(i.transform.position, p.transform.position);
        //    }
        //}
    }


}
