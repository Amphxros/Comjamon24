using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskLocations : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        foreach(Transform tr in transform)
        {
            Gizmos.DrawSphere(tr.position, 0.2f);
        }
    }
}
