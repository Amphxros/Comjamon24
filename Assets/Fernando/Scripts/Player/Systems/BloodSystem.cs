using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSystem : PlayerSystem
{

    [SerializeField]
    private ParticleSystem bloodParticles;


    protected override void Awake()
    {
        base.Awake();

        bloodParticles = GetComponent<ParticleSystem>();

    }
    // Start is called before the first frame update
    void Start()
    {
        bloodParticles.collision.SetPlane(0, mainScript.GM.WorldPlane);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
