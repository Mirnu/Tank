using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    public List<ResourceData> ResourcesList;
    public List<Image> ResourceGameObjects;

    private void Awake()
    {
        Instance = this;

        UpdateResources();
    }

    public void UpdateResources()
    {
        for (int i = 0; i < ResourcesList.Count; i++)
        {
            ResourceGameObjects[i].sprite = ResourcesList[i].Image;
            ResourceGameObjects[i].GetComponentInChildren<TMP_Text>().text = Resources[ResourcesList[i].NameResource].ToString();
        }
    }

    public Dictionary<string, int> Resources = new Dictionary<string, int>()
    {
        ["�����"] = 500000,
        ["����"] = 350000,
        ["���������"] = 400000,
        ["�����"] = 100000,
        ["����"] = 150000,
        ["����"] = 600000,
        ["������"] = 2500000,
        ["������ �������"] = 200000,
        ["�������"] = 500000,
        ["������"] = 200000,
        ["�����"] = 200000,
        ["�������"] = 400000,
        ["��������"] = 200000,
        ["�������"] = 500000,
        ["�����"] = 500000,
        ["��������� ����"] = 100000,
        ["���"] = 1000,
        ["�������"] = 100000,
        ["������"] = 4,
        ["������ ����� �����"] = 4,
        ["������� ����� �����"] = 4,
        ["������� ����� �����"] = 4,
        ["����� ������� ������"] = 4,
        ["�������������� ����� ������ �������"] = 4,
        ["����� ������ �������"] = 4,
        ["����� ������������"] = 4,
        ["������� ������������"] = 4,
        ["������ ����������"] = 4,
        ["���������� ��������"] = 4,
        ["������� �������� �������"] = 20,
        ["������� �������� �������"] = 20,
        ["������� ������ �������"] = 20,
        ["������� �������"] = 10000,
        ["����� ������� ������"] = 2,
    };
}

public struct Product
{
    public string product;
    public Dictionary<string, int> Resource;
    public int count;
    public WorkShop workshop;
    public bool explore;
    public int countBuy;

    public Product(string product, Dictionary<string, int> Resource, int count, WorkShop workshop)
    {
        this.product = product;
        this.Resource = Resource;
        this.count = count;
        this.workshop = workshop;
        explore = false;
        countBuy = 0;
    }
}
