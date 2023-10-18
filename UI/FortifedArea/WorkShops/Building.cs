using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Building : WorkShop
{
    public override string Description { get; set; } = "производит сталь, цветные металлы";
    public override string name { get; set; } = "Литейный";

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
        ["энергия"] = 100,
        ["детали заводов"] = 300,
        ["уголь"] = 200,
        ["сталь"] = 200,
        ["деньги"] = 2000,
    };

    private static Dictionary<string, int> ResourceForProduct { get; set; } = new Dictionary<string, int>()
    {
        ["очищенная руда"] = 10,
        ["энергия"] = 3,
        ["уголь"] = 4,
    };
    
    public override List<Product> Goods { get; set; } = new List<Product>()
    {
        new Product("сталь", ResourceForProduct, 5, instance),
        new Product("цветные металлы", ResourceForProduct, 5, instance),
    };
}
