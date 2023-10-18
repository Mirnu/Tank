using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{
    public static TankManager instance;

    private void Awake()
    {
        instance = this;
    }

    public Dictionary<string, WareHouseTank> Tanks = new Dictionary<string, WareHouseTank> ();
}
