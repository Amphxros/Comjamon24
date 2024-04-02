
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "GameManager")]
public class GameManagerSO : ScriptableObject
{

    private Global_Controls globalControls;
    
    [SerializeField] 
    private Player playerPrefab;

    [NonSerialized] 
    private int currentPlayers = 1;

    [NonSerialized]
    private List<Player> players = new List<Player>();

    [NonSerialized]
    private Camera mainCamera;

    [NonSerialized]
    private Camera uiCamera;
    
    private Transform worldPlane;




    #region Eventos
    public event Action OnPlayerHardImpact;
    public event Action OnPlayerJump;
    public event Action OnMissionStarts;
    public event Action OnGameEnds;
    public event Action<Transform> OnNewPlayerSpawned;
    #endregion
    
    public Transform WorldPlane { get => worldPlane; set => worldPlane = value; }
    public List<Player> Players { get => players; }
    public int CurrentPlayers { get => currentPlayers; }
    public Camera MainCamera { get => mainCamera; set => mainCamera = value; }
    public Camera UiCamera { get => uiCamera; set => uiCamera = value; }

    private void OnEnable()
    {
        globalControls = new Global_Controls();
        globalControls.Enable();

        //globalControls.Global.SpawnPlayer.started += SpawnPlayer_started;
        globalControls.Global.StartMission.started += StartMission;
    }


    public void SpawnPlayer()
    {
        if(currentPlayers < 2)
        {
            PlayerInput newPlayerTransform = PlayerInput.Instantiate(playerPrefab.gameObject,controlScheme: "Jugador2", pairWithDevices: Keyboard.current);
            OnNewPlayerSpawned?.Invoke(newPlayerTransform.transform);

            currentPlayers++;
        }
    }

    #region Global Gameplay
    private void StartMission(InputAction.CallbackContext obj)
    {
        OnMissionStarts?.Invoke();
    }
    public void PlayerHardImpact()
    {
        OnPlayerHardImpact?.Invoke();
    }

    public void PlayerJumps()
    {
        OnPlayerJump?.Invoke();
    }

    public void FinDePartida()
    {
        Time.timeScale = 0;
        OnGameEnds?.Invoke();

    }
    #endregion
}
