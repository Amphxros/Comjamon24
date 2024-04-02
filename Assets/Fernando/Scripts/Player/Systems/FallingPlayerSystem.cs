using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class FallingPlayerSystem : PlayerSystem
{
    [SerializeField]
    private Material prueba;


    Material materialDefecto;
    MeshRenderer mr;


    [SerializeField]
    private float forceForFalling;

    [SerializeField]
    private float timeToRecover;

    [SerializeField]
    private float timeToStandUp;

    [SerializeField]
    private PhysicMaterial fallingMaterial;


    [SerializeField]
    private LayerMask whatIsRecoverSurface;


    private Rigidbody rb;

    private float lastYRotation;

    private PhysicMaterial defaultPhysicsMaterial;


    private bool falling;

    private bool onSurface;

    private CapsuleCollider coll;

    public bool Falling { get => falling; }

    protected override void Awake()
    {
        base.Awake();

        rb = GetComponent<Rigidbody>();
        coll = GetComponent<CapsuleCollider>();

        defaultPhysicsMaterial = coll.sharedMaterial;

        mainScript.SharedData.FallingSystem = this;



        #region Prueba
        mr = GetComponentInChildren<MeshRenderer>();

        materialDefecto = mr.sharedMaterial;
        #endregion
    }
    private void Update()
    {
 
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Vector3 horizontalVelocityMagnitude = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;
        if (collision.relativeVelocity.magnitude > forceForFalling)
        {
            mainScript.GM.PlayerHardImpact(); //Para sonidos, camera shake...
            if(!falling)
            {
                Fall();
            }
        }
        if (((1 << collision.gameObject.layer) & whatIsRecoverSurface) != 0)
        {
            onSurface = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & whatIsRecoverSurface) != 0)
        {
            onSurface = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & whatIsRecoverSurface) != 0)
        {
            onSurface = false;
        }
    }

    public void Fall()
    {
        #region Prueba
        mr.sharedMaterial = prueba;
        #endregion

        falling = true;
        mainScript.HasCar = false;
        mainScript.SharedData.PlayerHardImpact(); //Para mis otros componentes.

        lastYRotation = transform.eulerAngles.y;
        coll.sharedMaterial = fallingMaterial;
        rb.angularDrag = 0f;
        rb.constraints = RigidbodyConstraints.None;
        mainScript.Controls.currentActionMap.Disable();

        StartCoroutine(Recover());
    }

    private IEnumerator Recover()
    {
        yield return new WaitForSeconds(timeToRecover);

        //Para asegurarnos que estemos sobre una superficie para recuperarnos.
        yield return new WaitUntil(() => onSurface);

        rb.isKinematic = true;

        //Se puede modificar el "Ease.     " a otro tipo (PROBEMOS)
        transform.DORotate(new Vector3(0, lastYRotation, 0), timeToStandUp).SetEase(Ease.OutBounce).OnComplete(OnRecoverCompleted);
    }
    private void OnRecoverCompleted()
    {
        #region Prueba
        Debug.Log("Me recupero!!!");

        mr.sharedMaterial = materialDefecto;
        #endregion


        coll.sharedMaterial = defaultPhysicsMaterial;

        rb.angularDrag = Mathf.Infinity;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rb.isKinematic = false;
        mainScript.Controls.currentActionMap.Enable();

        falling = false;
    }

}
