using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Building : WorkShop
{
    public override string Description { get; set; } = "���������� �����, ������� �������";
    public override string name { get; set; } = "��������";

    public Sprite image;

    public static Building instance;

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
        ["������ �������"] = 300,
        ["�����"] = 200,
        ["�����"] = 200,
        ["������"] = 2000,
    };

    private static Dictionary<string, int> ResourceForProduct { get; set; } = new Dictionary<string, int>()
    {
        ["��������� ����"] = 10,
        ["�������"] = 3,
        ["�����"] = 4,
    };
    
    public override List<Product> Goods { get; set; } = new List<Product>()
    {
        new Product("�����", ResourceForProduct, 5, instance),
        new Product("������� �������", ResourceForProduct, 5, instance),
    };
}
