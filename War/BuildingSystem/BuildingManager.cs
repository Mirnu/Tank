using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance;

    [SerializeField] private List<GameObject> Spawns;
    [SerializeField] private List<BuildingWarData> WarData;

    public GameObject BreakFloor;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        foreach (var spawn in Spawns)
        {
           BuildingWarData building = WarData[Random.RandomRange(0, WarData.Count)];

           building.Spawn(spawn.transform);
        }
    }
}
