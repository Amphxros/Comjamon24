using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicSource;
    
    [SerializeField]
    private AudioSource sfxSource;


    [SerializeField] private GameManagerSO gM;

    [SerializeField]
    private AudioClip[] hardImpactClips;

    [SerializeField]
    private AudioClip[] jumpsClips;

    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        gM.OnPlayerHardImpact += PlayHardImpactClip;
        gM.OnPlayerJump += PlayJumpClip;
    }

    private void PlayJumpClip()
    {
        int randomClip = Random.Range(0, jumpsClips.Length);
        sfxSource.PlayOneShot(jumpsClips[randomClip]);
    }

    private void PlayHardImpactClip()
    {
        int randomClip = Random.Range(0, hardImpactClips.Length);
        sfxSource.PlayOneShot(hardImpactClips[randomClip]);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        gM.OnPlayerHardImpact -= PlayHardImpactClip;
        gM.OnPlayerJump -= PlayJumpClip;
    }
}
