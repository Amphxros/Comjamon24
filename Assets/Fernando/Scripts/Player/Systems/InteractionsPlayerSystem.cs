using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsPlayerSystem : PlayerSystem
{

    [Header("Sistema de interacción")]
    [SerializeField] private Transform interactionZone;
    [SerializeField] private float interactionRadious;
    [SerializeField] private LayerMask whatIsInteractable;

    private Interactable currentInteractable;


    protected override void Awake()
    {
        base.Awake();

    }

    private void OnEnable()
    {
        mainScript.OnInteract += TriggerInteraction;
    }

    private void FixedUpdate()
    {
        DetectInteractables();
    }
    private void DetectInteractables()
    {
        Collider[] colls = Physics.OverlapSphere(interactionZone.position, interactionRadious, whatIsInteractable);
        if (colls.Length > 0)
        {
            if (colls[0].TryGetComponent(out Interactable interactuable))
            {
                Item isItem = interactuable as Item;
                if (isItem && !mainScript.HasCar) return;//Si es un item, tienes que tener carrito.

                if (currentInteractable == null)
                {
                    currentInteractable = interactuable;
                }
                else if(currentInteractable != interactuable)
                {
                    currentInteractable.ToggleInteractionState(false);
                    currentInteractable = interactuable;
                }
                currentInteractable.ToggleInteractionState(true);
            }
        }
        else if (currentInteractable != null)
        {
            currentInteractable.ToggleInteractionState(false);
            currentInteractable = null;
        }
    }

    private void TriggerInteraction()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact(mainScript); //cuidado aquí con el orden, esto lo último.
            currentInteractable = null; //dESPUÉS DE INTERACTUAR, DAMOS POR HECHO, QUE YA SE PERDERÁ.
        }
    }

    

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(interactionZone.position, interactionRadious);
    }
}
