using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : Item, Interactable
{
    [SerializeField]
    private float explosionRadious;

    [SerializeField]
    private float explosionForce;

    [SerializeField]
    private float explosionUpModifier;

    [SerializeField]
    private LayerMask whatIsDamagable;

    public override void Interact(Player myInteractor)
    {

        Collider[] colls = Physics.OverlapSphere(transform.position, explosionRadious, whatIsDamagable);
        
        foreach (Collider coll in colls)
        {
            if(coll.TryGetComponent(out Rigidbody otherRb))
            {
                otherRb.isKinematic = false;
                if(otherRb.TryGetComponent(out Player player))
                {
                    player.SharedData.FallingSystem.Fall(); //Para hacer a los personajes cercanos detach de su carro.
                }
                gM.PlayerHardImpact(); //para camara shake.
                otherRb.AddExplosionForce(explosionForce, transform.position, explosionRadious, explosionRadious, ForceMode.Impulse);
            }
            Destroy(this.gameObject);
        }
    }


}
