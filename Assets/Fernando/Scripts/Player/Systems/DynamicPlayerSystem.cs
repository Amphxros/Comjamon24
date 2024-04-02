using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPlayerSystem : PlayerSystem
{
    [SerializeField]
    private float defaultMovementForce;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float maximumLinearVelocity;

    [SerializeField]
    private float rotationVelocity;

    [Header("Ground check")]
    [SerializeField] private Transform feet;
    [SerializeField] private float radiousGroundCheck;
    [SerializeField] private LayerMask whatIsGround;



    private Vector3 inputsVector;



    private float currentForce, currentRotationVelocity, currentMaximumLinearVelocity;

    private Rigidbody rb;

    private bool isGrounded;

    public float CurrentForce { get => currentForce; set => currentForce = value; }
    public float DefaultMovementForce { get => defaultMovementForce; }
    public float MaximumLinearVelocity { get => maximumLinearVelocity; set => maximumLinearVelocity = value; }
    public float CurrentRotationVelocity { get => currentRotationVelocity; set => currentRotationVelocity = value; }
    public float RotationVelocity { get => rotationVelocity; }
    public float CurrentMaximumLinearVelocity { get => currentMaximumLinearVelocity; set => currentMaximumLinearVelocity = value; }

    protected override void Awake()
    {
        base.Awake();

        rb = GetComponent<Rigidbody>();
        currentForce = defaultMovementForce;
        currentRotationVelocity = rotationVelocity;
        currentMaximumLinearVelocity = maximumLinearVelocity;

        mainScript.SharedData.MovementSystem = this;
    }

    private void OnEnable()
    {
        mainScript.OnMovePerformed += Move;
        mainScript.OnMoveCancelled += StopMoving;
        mainScript.OnJump += Jump;
    }


    private void Move(Vector2 obj)
    {
        inputsVector = new Vector3(obj.x, 0, obj.y);
    }

    private void StopMoving()
    {
        inputsVector = Vector3.zero;
    }
    private void Jump()
    {
        if(isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            mainScript.GM.PlayerJumps();
        }

    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(!rb.isKinematic)
        {
            rb.AddForce(inputsVector * inputsVector.magnitude * currentForce, ForceMode.Force);

            ClampMaximumHorizontalVelocity();
        }

        if(inputsVector.sqrMagnitude >0)
        {
            RotateByForce();

        }

        GroundCheck();
    }

    private void RotateByForce()
    {
        Vector3 desiredRotation = new Vector3(0f, Mathf.Atan2(inputsVector.x, inputsVector.z) * Mathf.Rad2Deg, 0f);
        // Calcular la rotación actual
        Quaternion currentRotation = transform.rotation;

        // Calcular la rotación suave hacia la rotación deseada
        Quaternion targetRotation = Quaternion.RotateTowards(currentRotation, Quaternion.Euler(desiredRotation), currentRotationVelocity * Time.deltaTime);

        // Aplicar la rotación al Rigidbody
        rb.MoveRotation(targetRotation);
    }

    private void ClampMaximumHorizontalVelocity()
    {
        Vector3 movementVector = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        Vector3 clampedMovementVector = Vector3.ClampMagnitude(movementVector, currentMaximumLinearVelocity);

        rb.velocity = new Vector3(clampedMovementVector.x, rb.velocity.y, clampedMovementVector.z);
    }
    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(feet.position, radiousGroundCheck, whatIsGround);
    }

    private void OnDisable()
    {
        mainScript.OnMovePerformed -= Move;
        mainScript.OnMoveCancelled -= StopMoving;
        mainScript.OnJump -= Jump;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawSphere(feet.position, radiousGroundCheck);
    }
}
