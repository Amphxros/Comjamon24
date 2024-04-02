using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CarSystem : PlayerSystem, Interactable
{

    private List<ItemSO> itemsCollected = new List<ItemSO>();


    private Rigidbody carRb;
    [SerializeField] private Outline myOutline;

    [SerializeField]
    private Transform carritoHolder;


    [SerializeField, Tooltip("Tiempo a partir del cual el carrito vuelve a ser interactuable")]
    private float timeToMakeCarInteractable;

    private PlayerSO sharedData;

    public List<ItemSO> ItemsCollected { get => itemsCollected; }

    protected override void Awake()
    {
        base.Awake();

        sharedData = mainScript.SharedData;

        sharedData.CarSystem = this;
    }

    private void OnEnable()
    {
        //sharedData.OnPlayerHardImpact += DetachCar;
    }

    public void DetachCar()
    {
        transform.SetParent(null);
        
        //Para que no lo haga cuando nos golpeamos sin carrito.
        if(carRb == null) 
        { 
            carRb = transform.AddComponent<Rigidbody>();
            carRb.isKinematic = false;
            carRb.AddForce(new Vector3(Random.Range(-1f,  1f), 3f, Random.Range(-1f, 1f)), ForceMode.Impulse);
            Invoke(nameof(ChangeLayer), timeToMakeCarInteractable);

        }
    }

    private void ChangeLayer()
    {
        gameObject.layer = LayerMask.NameToLayer("Interactable");
    }
  

    public void Interact(Player myInteractor)
    {
        myInteractor.HasCar = true;

        gameObject.layer = LayerMask.NameToLayer("Player");
        ToggleInteractionState(false);

        Destroy(carRb);

        transform.SetPositionAndRotation(myInteractor.CarritoHolder.position, myInteractor.CarritoHolder.rotation);

        //Podemos robarle el carrito al otro.
        transform.SetParent(myInteractor.CarritoHolder);
        
        myInteractor.SharedData.CarSystem = this;


    }
    public void ToggleInteractionState(bool state)
    {
        myOutline.enabled = state;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out Item item))
        {
            item.ItemFallFromCar();
            itemsCollected.Remove(item.MyData);
        }
    }


}
