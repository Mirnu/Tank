using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    [SerializeField] private AimManager aimManager;
    [SerializeField] private TankRecharge tankRecharge;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject Muzzle;

    public static FireManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private float GetRandom(float x1)
    {
        return Random.Range(x1 - aimManager.Scale * 20, x1 + aimManager.Scale * 20);
    }

    public void Fire()
    {
        if (tankRecharge.isRecharged)
        {
            float y = GetRandom(Muzzle.transform.rotation.eulerAngles.y);

            Instantiate(Bullet, new Vector3(Muzzle.transform.position.x, Muzzle.transform.position.y - 1, Muzzle.transform.position.z), Quaternion.Euler(new Vector3(Muzzle.transform.rotation.eulerAngles.x, y, Muzzle.transform.rotation.eulerAngles.z)));

            tankRecharge.StartRecharge();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
}
