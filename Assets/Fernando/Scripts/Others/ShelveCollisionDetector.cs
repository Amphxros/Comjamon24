using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelveCollisionDetector : MonoBehaviour
{
    [SerializeField]
    private Shelve shelve;

    [SerializeField]
    private float forceForFalling;

    [SerializeField]
    private LayerMask whatIsPlayer;

    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & whatIsPlayer) != 0)
        {
            if (collision.relativeVelocity.magnitude > forceForFalling)
            {
                if(shelve)
                {
                    Debug.Log("LA HE LIADO!");
                    shelve.FallDown();
                }
            }
           
        }
    }
}
