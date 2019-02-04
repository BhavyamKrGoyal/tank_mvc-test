using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApplication : SingletonScene<GameApplication>
{

    public ScriptableEnemy[] enemy;

    public GameObject player;
    List<Vector3> EnemyPosition = new List<Vector3>();
    public override void OnInitialize()
    {
        base.OnInitialize();

        Debug.Log("in awake of GameApplication");
        ServiceEnemy.Instance.SetEnemyList(enemy);
    }
    public void ReSpawnPlayer(Controls controls)
    {
        new ControllerPlayer(player, SpawnPlayer(ServiceEnemy.Instance.GetEnemyPositions()), controls);
    }
    // Start is called before the first frame update
    void Start()
    {
        new ControllerPlayer(player, new Vector3(Random.Range(-40, 41), 5, Random.Range(-40, 41)), Controls.WASD);
        new ControllerPlayer(player, new Vector3(Random.Range(-40, 41), 5, Random.Range(-40, 41)), Controls.IJKL);

    }
    // Update is called once per frame
    void Update()
    {

    }

    private Vector3 SpawnPlayer(List<Vector3> enemyPositions)
    {
        int[,] threatLevelGrid = new int[20, 20];
        int minThreat = 0;
        int xPos=0, zPos=0;
        List<Vector3> safeZones=new List<Vector3>(); ;
        Debug.Log(enemyPositions.Count);
        foreach (Vector3 enemyPosition in enemyPositions)
        {
            threatLevelGrid = increaseThreat(threatLevelGrid, GridValue(enemyPosition.x), GridValue(enemyPosition.z));
        }
        minThreat = threatLevelGrid[0, 0];
        for(int x=0;x<20;x++)
        {
            for (int z = 0; z < 20; z++)
            {
                if (minThreat > threatLevelGrid[x, z])
                {
                    safeZones = new List<Vector3>();
                    Debug.Log("x=" + x + " Z=" + z);
                    minThreat = threatLevelGrid[x, z];
                    xPos = x;
                    zPos = z;
                    safeZones.Add(new Vector3((xPos - 10) * 4, 5, (zPos - 10) * 4));
                }else if(minThreat == threatLevelGrid[x, z])
                {
                    xPos = x;
                    zPos = z;
                    safeZones.Add(new Vector3((xPos - 10) * 4, 5, (zPos - 10) * 4));
                }
            }
        }
        Debug.Log("x="+xPos+" Z="+zPos);
        return safeZones[Random.Range(0,safeZones.Count)];
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
}
