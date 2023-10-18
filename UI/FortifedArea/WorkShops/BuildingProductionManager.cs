using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildingProductionManager : MonoBehaviour
{
    public static BuildingProductionManager Instance;

    [SerializeField] private TMP_Text ProductionInformation;
    [SerializeField] private TMP_Text ProductionCost;
    [SerializeField] private TMP_Text NameWorkShop;
    [SerializeField] private Image WorkShopImage;

    public Image ButtonBuild;

    private WorkShop currentState;

    private void Awake()
    {
        Instance = this;
    }

    private string GetResourceInfo(WorkShop workshop)
    {
        currentState = workshop;

        string totalText = "";

        foreach (var resource in workshop.ResourcesForConstruction)
        {
            totalText += $"{resource.Key} {resource.Value},\n";
        }

        return totalText;

    }

    public void ShowInfo(WorkShop workshop)
    {
        NameWorkShop.text = workshop.name;
        WorkShopImage.sprite = workshop.GetImage();
        ProductionInformation.text = workshop.Description;
        ProductionCost.text = GetResourceInfo(workshop);
    }

    private void BuyWorkShop()
    {
        foreach (var resource in currentState.ResourcesForConstruction)
        {
            ResourceManager.Instance.Resources[resource.Key] -= resource.Value;
        }
    }

    public bool CheckResource(WorkShop currentState)
    {
        foreach (var resource in currentState.ResourcesForConstruction)
        {
            print(ResourceManager.Instance);
            foreach (var item in ResourceManager.Instance.Resources)
            {
                print($"{item.Key}: {item.Value}");
            }
            if (ResourceManager.Instance.Resources[resource.Key] < resource.Value)
            {
                return false;
            }
        }

        return true;
    }

    public void CreateWorkShop()
    {
        if (currentState && !currentState.isCreated && CheckResource(currentState))
        {
            BuyWorkShop();

            currentState.isCreated = true;

            currentState.gameObject.GetComponent<WorkshopUI>().workshopUI.SetActive(false);
            ButtonBuild.color = Color.white;
        }
    }
}
