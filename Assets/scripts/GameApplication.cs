using Enemy;
using Replay_Service;
using ScriptableObjects;
using StateMachines;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameApplication : Singleton<GameApplication>
{
    bool playState = false;
    public ScriptableEnemy[] enemy;
    public GameObject player;
    public event Action<ControllerPlayer> OnPlayerSpawn;
    public List<ControllerPlayer> players = new List<ControllerPlayer>();
    List<Vector3> EnemyPosition = new List<Vector3>();
    //Debug.Log("in awake of GameApplication");

    public void ReSpawnPlayer(Controls controls, PlayerNumber playerNumber)
    {
        StartCoroutine(LateRespawn(controls, playerNumber));
    }
    public void ReSpawnPlayer2(Controls controls, PlayerNumber playerNumber, Vector3 pos)
    {
        StartCoroutine(LateReplayRespawn(playerNumber,controls,pos));
       // AddPlayerController(new ControllerPlayer(player, pos, controls, playerNumber, false));

    }
    // Start is called before the first frame update
    void Start()
    {
        StateManager.Instance.OnStateChanged += OnStateChanged;

    }
    public void SetPlayerPrefab(GameObject player)
    {
        this.player = player;
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }
    void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
            playState = true;
            ServiceEnemy.Instance.SetEnemyList(enemy);
            Vector3 pos1 = SpawnPlayer(EnemyPosition);
           // Vector3 pos2 = new Vector3(UnityEngine.Random.Range(-40, 41), 5, UnityEngine.Random.Range(-40, 41));
            ServiceReplay.Instance.SetPosition(PlayerNumber.Player1, pos1, Controls.WASD);
            //ServiceReplay.Instance.SetPosition(PlayerNumber.Player2, pos2, Controls.IJKL);
            AddPlayerController(new ControllerPlayer(player, pos1, Controls.WASD, PlayerNumber.Player1, true));
           // AddPlayerController(new ControllerPlayer(player, pos2, Controls.IJKL, PlayerNumber.Player2, true));
        }

    }
    void OnStateChanged(GameState currentState)
    {
        if (currentState is GameReplayState)
        {
            playState = false;
        }
        else
        {
            playState = true;
        }
    }
    private Vector3 SpawnPlayer(List<Vector3> enemyPositions)
    {
        int[,] threatLevelGrid = new int[20, 20];
        int minThreat = 0;
        int xPos = 0, zPos = 0;
        List<Vector3> safeZones = new List<Vector3>(); ;
        //Debug.Log(enemyPositions.Count);
        foreach (Vector3 enemyPosition in enemyPositions)
        {
            threatLevelGrid = increaseThreat(threatLevelGrid, GridValue(enemyPosition.x), GridValue(enemyPosition.z));
        }
        minThreat = threatLevelGrid[0, 0];
        for (int x = 0; x < 20; x++)
        {
            for (int z = 0; z < 20; z++)
            {
                if (minThreat > threatLevelGrid[x, z])
                {
                    safeZones = new List<Vector3>();
                    //Debug.Log("x=" + x + " Z=" + z);
                    minThreat = threatLevelGrid[x, z];
                    xPos = x;
                    zPos = z;
                    safeZones.Add(new Vector3((xPos - 10) * 4, 5, (zPos - 10) * 4));
                }
                else if (minThreat == threatLevelGrid[x, z])
                {
                    xPos = x;
                    zPos = z;
                    safeZones.Add(new Vector3((xPos - 10) * 4, 5, (zPos - 10) * 4));
                }
            }
        }
        //Debug.Log("x="+xPos+" Z="+zPos);
        return safeZones[UnityEngine.Random.Range(0, safeZones.Count)];
    }

    private int[,] increaseThreat(int[,] grid, int enemyPosX, int enemyPosY)
    {
        for (int i = enemyPosX - 3; i <= enemyPosX + 3; i++)
        {
            for (int j = enemyPosY - 3; j <= enemyPosY + 3; j++)
            {
                if (i >= 0 && i < 20 && j >= 0 && j < 20)
                {
                    grid[i, j]++;
                }
            }
        }
        return grid;
    }

    private int GridValue(float pos)
    {
        int grid = (int)Mathf.Ceil(pos / 4);
        return (grid + 10);
    }
    public void AddPlayerController(ControllerPlayer player)
    {
        GameApplication.Instance.players.Add(player);
        player.OnPlayerDeath += RemovePlayerController;
        OnPlayerSpawn.Invoke(player);

    }
    public void RemovePlayerController(ControllerPlayer player, InputComponent inputComponent, Controls controls)
    {
        GameApplication.Instance.players.Remove(player);
        if (!playState)
        {
            ServiceReplay.Instance.ReplayReSpawn(player.GetPlayerNumber());
        }
        else
        {
            ReSpawnPlayer(player.GetControls(), player.GetPlayerNumber());
        }
        if (GameApplication.Instance.players.Count == 0)
        {
            if (StateManager.Instance.currentState is GameReplayState)
            {
                StateManager.Instance.ChangeState(new GameOverState(), true);
            }
            else
            {
                StateManager.Instance.ChangeState(new GameReplayState(), false);
            }
        }
    }
    IEnumerator LateRespawn(Controls controls, PlayerNumber playerNumber)
    {
        yield return new WaitForSeconds(3f);
        if (SceneManager.GetActiveScene().name == "GameScene" && playState)
        {
            Vector3 pos = SpawnPlayer(ServiceEnemy.Instance.GetEnemyPositions());
            AddPlayerController(new ControllerPlayer(player, pos, controls, playerNumber, false));
            ServiceReplay.Instance.SetPosition(playerNumber, pos, controls);
        }
    }
    IEnumerator LateReplayRespawn(PlayerNumber playerNumber,Controls controls,Vector3 pos)
    {
        yield return new WaitForSeconds(3f);
        if (!playState)
        {
            AddPlayerController(new ControllerPlayer(player, pos, controls, playerNumber, false));
//            ServiceReplay.Instance.SetPosition(playerNumber, pos, controls);
        }

    }
}
