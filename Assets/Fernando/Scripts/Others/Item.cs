using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Outline))]
public class Item : MonoBehaviour, Interactable
{
    [SerializeField]
    protected GameManagerSO gM;

    [SerializeField]
    private ItemSO myData;

    [SerializeField]
    private GameObject localCanvas;

    [SerializeField]
    private Image itemIconImage;

    [SerializeField, Tooltip("Offset en y para droppear el item en carrito")]
    private float yOffset;

    protected Outline myOutline;
    protected Rigidbody rb;


    public ItemSO MyData { get => myData; }
    public Image ItemIconImage { get => itemIconImage; }

    private void Awake()
    {
        myOutline = GetComponent<Outline>();
        rb = GetComponent<Rigidbody>();
    }
    public virtual void Interact(Player myInteractor)
    {
        DropItemInInteractorCar(myInteractor);

    }

    private void DropItemInInteractorCar(Player myInteractor)
    {
        CarSystem interactorCar = myInteractor.SharedData.CarSystem;

        Vector3 dropPoint = interactorCar.transform.position + new Vector3(0, yOffset, 0);
        Quaternion randomRotation = Quaternion.Euler(Random.Range(0f, 360f),
            Random.Range(0f, 360f),
            Random.Range(0f, 360f));
        
        rb.isKinematic = false;
        transform.SetPositionAndRotation(dropPoint, randomRotation);


        ToggleInteractionState(false);
        gameObject.layer = LayerMask.NameToLayer("Player");

        localCanvas.SetActive(false);
        interactorCar.ItemsCollected.Add(this.MyData);

    }

    public void ItemFallFromCar()
    {
        gameObject.layer = LayerMask.NameToLayer("Interactable");

        localCanvas.SetActive(true);
    }
    public void ToggleInteractionState(bool state)
    {
        myOutline.enabled = state;
    }
}
