using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    protected Player mainScript;

    protected virtual void Awake()
    {
        mainScript = transform.root.GetComponent<Player>();
    }
}
