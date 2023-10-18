using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TankManagement : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private AimManager aimManager;

    public bool Authomatic = false;

    private Vector3 currentAim;

    private void Start()
    {
        StartCoroutine(TowerMovement());
    }

    private void Update()
    {
        if (!Authomatic)
        {
            Ray mouseCast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            aimManager.UpdateMousePosition();

            if (Physics.Raycast(mouseCast, out hit))
            {
                HitProcessing(hit);
            }

        }
        else
        {
            if (EnemySpawner.Instance.currentEnemy != null)
            {
                currentAim = EnemySpawner.Instance.currentEnemy.transform.position;
            }
        } 
    }

    private void HitProcessing(RaycastHit hit)
    {
        Vector3 target = new Vector3(hit.point.x, 0f, hit.point.z);

        if (target != currentAim)
        {
            currentAim = target;
            
        } 
    }

    public void ChangeState()
    {
        Authomatic = !Authomatic;
    }

    private IEnumerator TowerMovement()
    {
        Vector3 direction;

        while (transform.gameObject.activeSelf) 
        {
            direction = currentAim - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);

            aimManager.UpdateSpread(rotation, transform.rotation);

            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Speed * Time.deltaTime);

            yield return new WaitForSeconds(0.001f);
        };
    }
}
