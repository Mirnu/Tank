using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class towerdamaged2 : WorkShop
{
    public override string Description { get; set; } = "���������� �������";
    public override string name { get; set; } = "��������������";

    public Sprite image;

    public static towerdamaged2 instance;

    private void Awake()
    {
        instance = this;
    }

    public override Sprite GetImage()
    {
        return image;
    }

    public override Dictionary<string, int> ResourcesForConstruction { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 100,
        ["������ �������"] = 150,
        ["�����"] = 100,
        ["�����"] = 100,
        ["�����"] = 200,
        ["������"] = 2000,
        ["�������"] = 100,
        ["������"] = 50
    };

    private static Dictionary<string, int> ResourceForEnergyFromCoal { get; set; } = new Dictionary<string, int>()
    {
        ["�����"] = 10,
    };

    private static Dictionary<string, int> ResourceForEnergyFromGas { get; set; } = new Dictionary<string, int>()
    {
        ["���"] = 10,
    };

    private static Dictionary<string, int> ResourceForEnergyFromOil { get; set; } = new Dictionary<string, int>()
    {
        ["�����"] = 10,
    };

    public override List<Product> Goods { get; set; } = new List<Product>()
    {
        new Product("�������", ResourceForEnergyFromCoal, 3, instance),
        new Product("�������", ResourceForEnergyFromGas, 4, instance),
        new Product("�������", ResourceForEnergyFromOil, 4, instance),
    };
}
