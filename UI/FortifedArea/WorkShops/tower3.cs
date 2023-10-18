using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tower3 : WorkShop
{
    public override string Description { get; set; } = "���������� ��������� ����";
    public override string name { get; set; } = "�����-������";

    public Sprite image;

    public static tower3 instance;

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
        ["������ �������"] = 200,
        ["�����"] = 200,
        ["�����"] = 200,
        ["������"] = 1000,
    };

    private static Dictionary<string, int> ResourceForRefinedOre { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 2,
        ["����"] = 10,
        ["����"] = 1
    };
    public override List<Product> Goods { get; set; } = new List<Product>()
    {
        new Product("��������� ����", ResourceForRefinedOre, 2, instance)
    };
}
