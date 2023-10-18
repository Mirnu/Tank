using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "BuildingWarData", menuName = "BuildingWar Data")]
public class BuildingWarData : ScriptableObject
{
    public List<GameObject> Floors;

    public void Spawn(Transform spawn)
    {
        float x, y, z;
        BuildingWar buildingWar = null;

        for (int i = 0; i < Floors.Count; i++)
        {
            x = spawn.position.x;
            y = spawn.position.y + i * 1;
            z = spawn.position.z;

            GameObject Floor = Instantiate(Floors[i], new Vector3(x, y, z), Quaternion.identity);

            if (i == 0)
            {
                buildingWar = Floor.GetComponent<BuildingWar>();
            }

            buildingWar.AddFloor(Floor);
        }
    }
}
