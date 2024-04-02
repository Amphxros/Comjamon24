using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerSO sharedData;
    [SerializeField] private GameManagerSO gM;
    [SerializeField] private Transform carritoHolder;   
    public PlayerSO SharedData { get => sharedData;}

    private PlayerInput controls;

    public event Action<Vector2> OnMovePerformed;
    public event Action OnMoveCancelled;
    public event Action OnJump;
    public event Action OnInteract;


    private bool hasCar = true;
    public PlayerInput Controls { get => controls; set => controls = value; }
    public GameManagerSO GM { get => gM;}
    public Transform CarritoHolder { get => carritoHolder; }
    public bool HasCar { get => hasCar; set => hasCar = value; }

    private void Awake()
    {
        controls = GetComponent<PlayerInput>();

        GM.Players.Add(this);
        
    }
    private void OnEnable()
    {
        controls.currentActionMap.Enable();
        controls.actions["Move"].performed += Move_performed;
        controls.actions["Move"].canceled += Move_canceled;
        controls.actions["Jump"].started += Jump_started;
        controls.actions["Interact"].started += Interact_started;

    }

    private void Interact_started(InputAction.CallbackContext obj)
    {
        OnInteract?.Invoke();
    }

    private void Jump_started(InputAction.CallbackContext obj)
    {
        OnJump?.Invoke();
    }

    private void Move_performed(InputAction.CallbackContext obj)
    {
        OnMovePerformed?.Invoke(obj.ReadValue<Vector2>());
    }
    private void Move_canceled(InputAction.CallbackContext obj)
    {
        OnMoveCancelled?.Invoke();
    }
}
