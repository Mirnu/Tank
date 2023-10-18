using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boostrap : MonoBehaviour
{
    [Header("Mode")]
    [SerializeField] private ModeChange modeChange;
    [SerializeField] private GameObject StartScreen;

    [SerializeField] private List<GameObject> modes;

    [Header("Tanks")]
    [SerializeField] private List<WareHouseTank> wareHouseTanks;


    private void Awake()
    {
        modeChange.Init(StartScreen);
        modes.ForEach(x => x.SetActive(false));
    }

    private void Start()
    {
        wareHouseTanks.ForEach(x => TankManager.instance.Tanks.Add(x.tankData.tankName, x));
    }
}
