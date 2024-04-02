using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelector : MonoBehaviour
{
    [SerializeField]
    private GameManagerSO gM;

    [SerializeField]
    private Texture[] textures;

    [SerializeField]
    private GameObject dummyBody;

    [SerializeField]
    private GameObject dummyCarrito;

    private Material dummyMaterial, carritoMaterial;

    private int bodyTextureIndex, carTextureIndex;

    private void Awake()
    {
        dummyMaterial = dummyBody.GetComponent<MeshRenderer>().sharedMaterial;
        carritoMaterial = dummyCarrito.GetComponent<MeshRenderer>().sharedMaterial;
    }
    public void BodyLeftArrow()
    {
        bodyTextureIndex--;
        bodyTextureIndex = (bodyTextureIndex + textures.Length) % textures.Length;
        dummyMaterial.mainTexture = textures[bodyTextureIndex];
    }
    public void BodyRightArrow()
    {
        bodyTextureIndex++;
        bodyTextureIndex = bodyTextureIndex % textures.Length;
        dummyMaterial.mainTexture = textures[bodyTextureIndex];
    }


    public void CarLeftArrow()
    {
        carTextureIndex--;
        carTextureIndex = (carTextureIndex + textures.Length) % textures.Length;
        Debug.Log("Ahora: " + carTextureIndex);
        carritoMaterial.mainTexture = textures[carTextureIndex];
    }

    public void CarRightArrow()
    {
        carTextureIndex++;
        carTextureIndex = carTextureIndex % textures.Length;
        carritoMaterial.mainTexture = textures[carTextureIndex];
    }

}
