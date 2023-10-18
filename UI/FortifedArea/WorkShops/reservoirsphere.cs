using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class reservoirsphere : WorkShop
{
    public override string Description { get; set; } = "���������� �����, �������, ������ � �������";
    public override string name { get; set; } = "��������";

    public Sprite image;

    public static reservoirsphere instance;

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
        ["�����"] = 50,
        ["�����"] = 100,
        ["�����"] = 50,
        ["������"] = 3000,
        ["�������"] = 100,
        ["������"] = 50
    };

    private static Dictionary<string, int> ResourceForOil { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 2,
        ["������"] = 2
    };

    private static Dictionary<string, int> ResourceForFuel { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 4,
        ["�����"] = 5,
    };

    private static Dictionary<string, int> ResourceForRubber { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 3,
        ["�����"] = 5,
        ["��������"] = 3,
    };

    private static Dictionary<string, int> ResourceForPlastic { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 3,
        ["�����"] = 5,
        ["��������"] = 3,
    };

    public override List<Product> Goods { get; set; } = new List<Product>()
    {
        new Product("�����", ResourceForOil, 5, instance),
        new Product("�������", ResourceForFuel, 4, instance),
        new Product("������", ResourceForRubber, 5, instance),
        new Product("�������", ResourceForPlastic, 5, instance),
    };
}
