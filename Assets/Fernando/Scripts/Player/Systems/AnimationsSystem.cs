using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsSystem : PlayerSystem
{
    private Animator anim;
    private Rigidbody rb;

    private DynamicPlayerSystem movementSystem;

    private int velocityId;
    protected override void Awake()
    {
        base.Awake();

        anim = GetComponent<Animator>();
        rb = transform.root.GetComponent<Rigidbody>();

        velocityId = Animator.StringToHash("velocity");

    }

    // Start is called before the first frame update
    void Start()
    {
        movementSystem = mainScript.SharedData.MovementSystem;
    }

    // Update is called once per frame
    void Update()
    {
        float value = Mathf.Clamp01(rb.velocity.magnitude / movementSystem.MaximumLinearVelocity);
        anim.SetFloat(velocityId, value);
    }
}
