using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerSO")]
public class PlayerSO : ScriptableObject
{
    //Punto de encuentro para los diferentes componentes AQUI.
    private DynamicPlayerSystem movementSystem;
    private FallingPlayerSystem fallingSystem;
    private CarSystem carSystem;
    private PlayerTaskSystem taskSystem;


    //public event Action OnPlayerHardImpact;
    public event Action OnPlayerJump;

    public DynamicPlayerSystem MovementSystem { get => movementSystem; set => movementSystem = value; }
    public FallingPlayerSystem FallingSystem { get => fallingSystem; set => fallingSystem = value; }
    public CarSystem CarSystem { get => carSystem; set => carSystem = value; }
    public PlayerTaskSystem TaskSystem { get => taskSystem; set => taskSystem = value; }



    #region Gameplay
    public void PlayerHardImpact()
    {
        if(carSystem)
        {
            carSystem.DetachCar();
        }
        //OnPlayerHardImpact?.Invoke();
    }

    public void PlayerJumps()
    {
        OnPlayerJump?.Invoke();
    }
    #endregion
}
