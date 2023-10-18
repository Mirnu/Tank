using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingWar : MonoBehaviour
{
    private Stack<GameObject> Floors = new Stack<GameObject>();

    public void AddFloor(GameObject floor) => Floors.Push(floor);

    private GameObject CurrentBreack;

    private void DestroyCurrentBreak( )
    {
        if (CurrentBreack)
        {
            Destroy(CurrentBreack);
        }
    }

    private void BreakFloor()
    {
        if (Floors.Count > 0)
        {
            DestroyCurrentBreak();

            GameObject floor = Floors.Pop();

            CurrentBreack = Instantiate(BuildingManager.Instance.BreakFloor, new Vector3(floor.transform.position.x, floor.transform.position.y, floor.transform.position.z), Quaternion.identity);
   
            Destroy(floor);
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Bullet>(out Bullet bullet))
        {
            Destroy(bullet.gameObject);
            BreakFloor();
        }
    }
}
