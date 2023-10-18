using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AirTower : WorkShop
{
    public override string Description { get; set; } = "���������� �������, �����, ���� ��������� � ��������";
    public override string name { get; set; } = "����������";

    public Sprite image;

    public static AirTower instance;

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

    private static Dictionary<string, int> ResourceForNitrates { get; set; } = new Dictionary<string, int>()
    {
        ["���������"] = 2,
        ["��������"] = 2,
    };

    private static Dictionary<string, int> ResourceForGunpowder { get; set; } = new Dictionary<string, int>()
    {
        ["����"] = 3,
        ["�����"] = 3,
        ["�������"] = 3,
        ["����"] = 1,
        ["�������"] = 4,
    };

    private static Dictionary<string, int> ResourceForWater { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 2,
        ["������"] = 2
    };

    private static Dictionary<string, int> ResourceForLimeStone { get; set; } = new Dictionary<string, int>()
    {
        ["����"] = 2,
        ["������"] = 5
    };

    private static Dictionary<string, int> ResourceForOrganic { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 2,
        ["������"] = 2
    };

    public override List<Product> Goods { get; set; } = new List<Product>()
    {
        new Product("�������", ResourceForNitrates, 2, instance),
        new Product("�����", ResourceForGunpowder, 7, instance),
        new Product("����", ResourceForWater, 5, instance),
        new Product("���������", ResourceForLimeStone, 2, instance),
        new Product("��������", ResourceForOrganic, 5, instance)
    };
}
