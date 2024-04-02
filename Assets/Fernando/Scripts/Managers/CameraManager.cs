using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private GameManagerSO gM;

    [SerializeField]
    private CinemachineTargetGroup targetGroup;
    
    [SerializeField]
    private float shakeForce;

    [SerializeField]
    private Camera perspectiveCamera;

    [SerializeField]
    private Camera ortographicCamera;




    private CinemachineImpulseSource impulsesSource;
    private void Awake()
    {
        impulsesSource = GetComponent<CinemachineImpulseSource>();

        gM.MainCamera = perspectiveCamera;
        gM.UiCamera = ortographicCamera;
    }
    private void OnEnable()
    {
        gM.OnPlayerHardImpact += CameraShake;
        gM.OnNewPlayerSpawned += AddPlayerToTargetGroup;
    }

    private void AddPlayerToTargetGroup(Transform newPlayerTransform)
    {
        targetGroup.AddMember(newPlayerTransform, 1, 0);
    }

    private void CameraShake()
    {
        Vector3 shakeVector = new Vector3(Random.Range(-shakeForce, shakeForce),
            Random.Range(-shakeForce, shakeForce), 
            Random.Range(-shakeForce, shakeForce));

        impulsesSource.GenerateImpulse(shakeVector);
    }

    private void OnDisable()
    {
        gM.OnPlayerHardImpact -= CameraShake;
        gM.OnNewPlayerSpawned -= AddPlayerToTargetGroup;
    }
}
