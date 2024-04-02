using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelve : MonoBehaviour
{
    private Rigidbody[] rbs;

    private void Awake()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
    }
    public void FallDown()
    {
        foreach (var r in rbs)
        {
            r.isKinematic = false;
        }
    }

}
