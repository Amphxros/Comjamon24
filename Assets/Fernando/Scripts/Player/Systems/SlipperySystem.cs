using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperySystem : PlayerSystem
{
    [SerializeField]
    private Material prueba;

    Material materialDefecto;
    MeshRenderer mr;


    [SerializeField] 
    private PhysicMaterial slipperyMaterial;

    [SerializeField, Tooltip("Tiempo minimo de resbalar")]
    private float slipperingTime;

    [Header("Afecta movimiento")]
    [SerializeField, Tooltip("Fuerza con la que nos movemos mientras resbalamos (Mejor que sea baja)")]
    private float slipperingMovementForce;

    [SerializeField]
    private float slipperingRotationVelocity;

    [SerializeField]
    private float slipperingMaximumVelocity;

    private PhysicMaterial defaultPhysicsMaterial;

    private bool slippering;
    private float timer;

    #region Otros componentes
    private CapsuleCollider coll;
    private Rigidbody rb;
    private DynamicPlayerSystem movementSystem;
    private FallingPlayerSystem fallingSystem;
    #endregion

    protected override void Awake()
    {
        base.Awake();

        coll = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();

        defaultPhysicsMaterial = coll.sharedMaterial;






        #region Prueba
        mr = GetComponentInChildren<MeshRenderer>();

        materialDefecto = mr.sharedMaterial;
        #endregion

    }
    private void Start()
    {
        movementSystem = mainScript.SharedData.MovementSystem;
        fallingSystem = mainScript.SharedData.FallingSystem;
    }
    private void Update()
    {
        if(slippering)
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime;
        if (timer >= slipperingTime)
        {
            StopSlippering();
        }
    }
    private void StartSlippering()
    {
        #region Prueba

        mr.sharedMaterial = prueba;
        #endregion

        slippering = true;
        timer = 0;
        rb.angularDrag = 0f;
        movementSystem.CurrentForce = slipperingMovementForce;
        movementSystem.CurrentRotationVelocity = slipperingRotationVelocity;
        movementSystem.CurrentMaximumLinearVelocity = slipperingMaximumVelocity;
        
        coll.sharedMaterial = slipperyMaterial;
    }

    private void StopSlippering()
    {
        #region
        mr.sharedMaterial = materialDefecto;
        #endregion
        slippering = false;
        timer = 0;
        rb.angularDrag = Mathf.Infinity;

        movementSystem.CurrentForce = movementSystem.DefaultMovementForce;
        movementSystem.CurrentRotationVelocity = movementSystem.RotationVelocity ;
        movementSystem.CurrentMaximumLinearVelocity = movementSystem.MaximumLinearVelocity;

        coll.sharedMaterial = defaultPhysicsMaterial;
    }

    private void OnParticleCollision(GameObject other)
    {
        if(!fallingSystem.Falling) //Para dar prioridad a los golpes.
        {
            StartSlippering();
        }
    }

}
