using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class reservoircyllinder : WorkShop
{
    public override string Description { get; set; } = "производит детали танков, снаряды, детали заводов";
    public override string name { get; set; } = "Инженерный";

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
        ["энергия"] = 100,
        ["детали заводов"] = 150,
        ["уголь"] = 100,
        ["нефть"] = 100,
        ["сталь"] = 200,
        ["деньги"] = 2000,
        ["пластик"] = 100,
        ["резина"] = 50
    };

    private static Dictionary<string, int> ResourceForSceleton { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 50,
        ["резина"] = 5,
        ["сталь"] = 50,
        ["пластик"] = 5,
        ["нефть"] = 5,
    };

    private static Dictionary<string, int> ResourceForLTA { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 20,
        ["деньги"] = 100,
        ["сталь"] = 50,
    };

    private static Dictionary<string, int> ResourceForMTA { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 30,
        ["деньги"] = 200,
        ["сталь"] = 75,
    };

    private static Dictionary<string, int> ResourceForHTA { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 50,
        ["деньги"] = 300,
        ["сталь"] = 100,
    };

    private static Dictionary<string, int> ResourceForLCC { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 50,
        ["деньги"] = 250,
        ["сталь"] = 25,
    };

    private static Dictionary<string, int> ResourceForMCC { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 40,
        ["деньги"] = 200,
        ["сталь"] = 20,
    };

    private static Dictionary<string, int> ResourceForSCRFC { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 30,
        ["деньги"] = 250,
        ["сталь"] = 15,
    };

    private static Dictionary<string, int> ResourceForSCC { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 20,
        ["деньги"] = 150,
        ["сталь"] = 15,
    };

    private static Dictionary<string, int> ResourceForSRS { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 10,
        ["пластик"] = 5,
        ["деньги"] = 50,
        ["цветные металлы"] = 5,
    };

    private static Dictionary<string, int> ResourceForBRS { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 15,
        ["пластик"] = 10,
        ["деньги"] = 100,
        ["цветные металлы"] = 10,
    };

    private static Dictionary<string, int> ResourceForMM { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 20,
        ["резина"] = 20,
        ["деньги"] = 150,
        ["цветные металлы"] = 5,
    };

    private static Dictionary<string, int> ResourceForID { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 20,
        ["резина"] = 5,
        ["деньги"] = 150,
        ["резина"] = 5,
        ["цветные металлы"] = 5,
    };

    private static Dictionary<string, int> ResourceForCS { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 5,
        ["цветные металлы"] = 5,
        ["порох"] = 5,
        ["сталь"] = 5,
    };

    private static Dictionary<string, int> ResourceForDF { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 20,
        ["цветные металлы"] = 10,
        ["сталь"] = 30,
        ["пластик"] = 5,
        ["резина"] = 5,
    };

    public override List<Product> Goods { get; set; } = new List<Product>()
    {
        new Product("каркас", ResourceForSceleton, 1, instance),
        new Product("легкая броня танка", ResourceForLTA, 1, instance),
        new Product("средняя броня танка", ResourceForMTA, 1, instance),
        new Product("тяжелая броня танка", ResourceForHTA, 1, instance),
        new Product("пушка крупный калибр", ResourceForLCC, 1, instance),
        new Product("пушка средний калибр", ResourceForMCC, 1, instance),
        new Product("скорострельная пушка малого калибра", ResourceForSCRFC, 1, instance),
        new Product("пушка малого калибра", ResourceForSCC, 1, instance),
        new Product("малая радиостанция", ResourceForSRS, 1, instance),
        new Product("большая радиостанция", ResourceForBRS, 1, instance),
        new Product("модуль маскировки", ResourceForMM, 1, instance),
        new Product("устройство разведки", ResourceForID, 1, instance),
        new Product("снаряды крупного калибра", ResourceForCS, 7, instance),
        new Product("снаряды среднего калибра", ResourceForCS, 12, instance),
        new Product("снаряды малого калибра", ResourceForCS, 18, instance),
        new Product("детали заводов", ResourceForDF, 15, instance),
    };
}