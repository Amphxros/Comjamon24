using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSystem : PlayerSystem
{
    [SerializeField]
    private float defaultVelocity;

    [SerializeField]
    private float smoothRotationFactor;

    [SerializeField, Tooltip("Para simular que hay aceleración y desaceleración.")]
    private float smoothMovementFactor;


    private Vector3 inputsVector;
    private Vector3 dampingMovement;
    private CharacterController controller;


    //Sólo lectura.
    private float rotationVelocity;
    private Vector3 movementVelocity;

    private float currentVelocity;

    protected override void Awake()
    {
        base.Awake();
        controller = GetComponent<CharacterController>();

        currentVelocity = defaultVelocity;
    }

    private void OnEnable()
    {
        mainScript.OnMovePerformed += Move;
        mainScript.OnMoveCancelled += StopMoving;
    }
    private void Move(Vector2 obj)
    {
        inputsVector = new Vector3(obj.x, 0, obj.y);
    }

    private void StopMoving()
    {
        inputsVector = Vector3.zero;
    }
    private void Update()
    {
        dampingMovement = Vector3.SmoothDamp(dampingMovement, inputsVector, ref movementVelocity, smoothMovementFactor);
        if (inputsVector.sqrMagnitude > 0 )
        {
            float targetAngle = DirectionToAngle();
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationVelocity, smoothRotationFactor);
            transform.eulerAngles = new Vector3(0, smoothAngle, 0);
        }
        controller.Move(dampingMovement * dampingMovement.magnitude * currentVelocity * Time.deltaTime);
    }


    private float DirectionToAngle()
    {
        float angle = Mathf.Atan2(inputsVector.x, inputsVector.z) * Mathf.Rad2Deg;
        return angle;
    }

}
