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
        ["уголь"] = 500000,
        ["руда"] = 350000,
        ["известняк"] = 400000,
        ["нефть"] = 100000,
        ["сера"] = 150000,
        ["вода"] = 600000,
        ["деньги"] = 2500000,
        ["детали заводов"] = 200000,
        ["пластик"] = 500000,
        ["резина"] = 200000,
        ["сталь"] = 200000,
        ["энергия"] = 400000,
        ["органика"] = 200000,
        ["нитраты"] = 500000,
        ["порох"] = 500000,
        ["очищенная руда"] = 100000,
        ["газ"] = 1000,
        ["топливо"] = 100000,
        ["каркас"] = 4,
        ["легкая броня танка"] = 4,
        ["средняя броня танка"] = 4,
        ["тяжелая броня танка"] = 4,
        ["пушка средний калибр"] = 4,
        ["скорострельная пушка малого калибра"] = 4,
        ["пушка малого калибра"] = 4,
        ["малая радиостанция"] = 4,
        ["большая радиостанция"] = 4,
        ["модуль маскировки"] = 4,
        ["устройство разведки"] = 4,
        ["снаряды среднего калибра"] = 20,
        ["снаряды крупного калибра"] = 20,
        ["снаряды малого калибра"] = 20,
        ["цветные металлы"] = 10000,
        ["пушка крупный калибр"] = 2,
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
