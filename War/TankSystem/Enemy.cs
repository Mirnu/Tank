using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Bullet>(out Bullet bullet))
        {
            EnemySpawner.Instance.Spawn();
            Destroy(bullet.gameObject);
            Destroy(gameObject);
        }
    }
}
