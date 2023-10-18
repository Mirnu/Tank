using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangar : MonoBehaviour
{
    public List<Tank> tanks;

    public void OnReady()
    {

        if (SquadManager.instance.tanksInSquad.Count > 0)
        {
            tanks.Clear();

            foreach (var tank in SquadManager.instance.tanksInSquad)
            {
                tanks.Add(tank.tank);
            }

            ModeChange.instance.Change(ModeChange.instance.StartScreen);
        }   
    }
}
