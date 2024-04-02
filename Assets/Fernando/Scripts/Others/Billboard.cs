using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField]
    private GameManagerSO gM;

    [SerializeField] private Vector3 offsetInUnits;
    
    private Camera perspectiveCamera;
    private Camera ortographicCam;
    
    private Transform target;
    private void Awake()
    {
        perspectiveCamera = Camera.main;
        target = transform.parent;


    }
    // Start is called before the first frame update
    void Start()
    {
        perspectiveCamera = gM.MainCamera;
        ortographicCam = gM.UiCamera;
    }

    // Update is called once per frame
    void Update()
    {
        //Calcular posici�n en c�mara (perspectiva) del padre.
        Vector3 parentScreenPos = perspectiveCamera.WorldToViewportPoint(target.position + offsetInUnits);
        // Vector3 billboardScreenPos = parentScreenPos + pixelsOffset; //px

        //Dicho punto, consider�ndolo en ortogr�fico, lo pasamos a una posici�n del World.
        transform.position = ortographicCam.ViewportToWorldPoint(parentScreenPos);

        //Miramos a la c�mara ortogr�fica.
        transform.rotation = ortographicCam.transform.rotation;
    }
}
