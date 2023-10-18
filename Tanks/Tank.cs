using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New TankData", menuName = "Tank Data")]
public class Tank : ScriptableObject
{
    public string tankName;
    public string type;
    public int armor;
    public int speed;
    public int minDamage;
    public int maxDamage;
    public bool radioStation;
    public int disguise;
    public bool detectionDevice;
    public Sprite tankImage;
    public List<string> Base;
    public List<string> Updates;
    public string bullet;
    public int maxFuel;
    public readonly int maxEnergy;
    public int Cost;

    public int currentFuel;
    public int currentBullet;
}
