using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class AimManager : MonoBehaviour
{
    [SerializeField] private GameObject Spread;
    [SerializeField] private TankManagement tank;

    public float Scale = 1;

    private Vector3 GetSize(float x)
    {
        return Vector3.one * Mathf.Clamp(Spread.transform.localScale.x + x, 0.3f, 1);
    }

    private void IncreaseSpread()
    {
        Spread.transform.localScale = GetSize(0.0005f);
    }

    private void ReduceSpread()
    {
        Spread.transform.localScale = GetSize(-0.0005f);
    }

    public void UpdateSpread(Quaternion x1, Quaternion x2)
    {
        if (Mathf.Abs(x1.eulerAngles.y - x2.eulerAngles.y) > 60 * Scale)
        {
            IncreaseSpread();
        }
        else
        {
            ReduceSpread();  
        }

        if (Spread.transform.localScale.x == 0.3f && tank.Authomatic && EnemySpawner.Instance.currentEnemy != null)
            FireManager.Instance.Fire();
    }

    public void UpdateMousePosition()
    {
        transform.position = Input.mousePosition;
    }
}
