using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WorkshopUI : MonoBehaviour
{
    public GameObject workshopUI;

    private Button button;
    private WorkShop workshop;

    private void Awake()
    {
        button = GetComponent<Button>();
        workshop = GetComponent<WorkShop>();
    }

    private void Start()
    {
        button.onClick.AddListener(Clicked);
    }

    private void Clicked()
    {
        BuildingProductionManager.Instance.ShowInfo(workshop);
        ProductionManager.Instance.ShowProducts(workshop);

        if (!workshop.isCreated && BuildingProductionManager.Instance.CheckResource(workshop))
        {
            BuildingProductionManager.Instance.ButtonBuild.color = Color.red;
        }
        else
        {
            BuildingProductionManager.Instance.ButtonBuild.color = Color.white;
        }
    }
}
