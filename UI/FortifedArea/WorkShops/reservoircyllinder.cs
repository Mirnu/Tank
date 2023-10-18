using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class reservoircyllinder : WorkShop
{
    public override string Description { get; set; } = "���������� ������ ������, �������, ������ �������";
    public override string name { get; set; } = "����������";

    public static reservoircyllinder instance;

    public Sprite image;

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

    private static Dictionary<string, int> ResourceForSceleton { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 50,
        ["������"] = 5,
        ["�����"] = 50,
        ["�������"] = 5,
        ["�����"] = 5,
    };

    private static Dictionary<string, int> ResourceForLTA { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 20,
        ["������"] = 100,
        ["�����"] = 50,
    };

    private static Dictionary<string, int> ResourceForMTA { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 30,
        ["������"] = 200,
        ["�����"] = 75,
    };

    private static Dictionary<string, int> ResourceForHTA { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 50,
        ["������"] = 300,
        ["�����"] = 100,
    };

    private static Dictionary<string, int> ResourceForLCC { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 50,
        ["������"] = 250,
        ["�����"] = 25,
    };

    private static Dictionary<string, int> ResourceForMCC { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 40,
        ["������"] = 200,
        ["�����"] = 20,
    };

    private static Dictionary<string, int> ResourceForSCRFC { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 30,
        ["������"] = 250,
        ["�����"] = 15,
    };

    private static Dictionary<string, int> ResourceForSCC { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 20,
        ["������"] = 150,
        ["�����"] = 15,
    };

    private static Dictionary<string, int> ResourceForSRS { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 10,
        ["�������"] = 5,
        ["������"] = 50,
        ["������� �������"] = 5,
    };

    private static Dictionary<string, int> ResourceForBRS { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 15,
        ["�������"] = 10,
        ["������"] = 100,
        ["������� �������"] = 10,
    };

    private static Dictionary<string, int> ResourceForMM { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 20,
        ["������"] = 20,
        ["������"] = 150,
        ["������� �������"] = 5,
    };

    private static Dictionary<string, int> ResourceForID { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 20,
        ["������"] = 5,
        ["������"] = 150,
        ["������"] = 5,
        ["������� �������"] = 5,
    };

    private static Dictionary<string, int> ResourceForCS { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 5,
        ["������� �������"] = 5,
        ["�����"] = 5,
        ["�����"] = 5,
    };

    private static Dictionary<string, int> ResourceForDF { get; set; } = new Dictionary<string, int>()
    {
        ["�������"] = 20,
        ["������� �������"] = 10,
        ["�����"] = 30,
        ["�������"] = 5,
        ["������"] = 5,
    };

    public override List<Product> Goods { get; set; } = new List<Product>()
    {
        new Product("������", ResourceForSceleton, 1, instance),
        new Product("������ ����� �����", ResourceForLTA, 1, instance),
        new Product("������� ����� �����", ResourceForMTA, 1, instance),
        new Product("������� ����� �����", ResourceForHTA, 1, instance),
        new Product("����� ������� ������", ResourceForLCC, 1, instance),
        new Product("����� ������� ������", ResourceForMCC, 1, instance),
        new Product("�������������� ����� ������ �������", ResourceForSCRFC, 1, instance),
        new Product("����� ������ �������", ResourceForSCC, 1, instance),
        new Product("����� ������������", ResourceForSRS, 1, instance),
        new Product("������� ������������", ResourceForBRS, 1, instance),
        new Product("������ ����������", ResourceForMM, 1, instance),
        new Product("���������� ��������", ResourceForID, 1, instance),
        new Product("������� �������� �������", ResourceForCS, 7, instance),
        new Product("������� �������� �������", ResourceForCS, 12, instance),
        new Product("������� ������ �������", ResourceForCS, 18, instance),
        new Product("������ �������", ResourceForDF, 15, instance),
    };
}