using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tower3 : WorkShop
{
    public override string Description { get; set; } = "производит очищенную руду";
    public override string name { get; set; } = "Горно-рудный";

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
        ["энергия"] = 100,
        ["детали заводов"] = 200,
        ["уголь"] = 200,
        ["сталь"] = 200,
        ["деньги"] = 1000,
    };

    private static Dictionary<string, int> ResourceForRefinedOre { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 2,
        ["руда"] = 10,
        ["вода"] = 1
    };
    public override List<Product> Goods { get; set; } = new List<Product>()
    {
        new Product("очищенная руда", ResourceForRefinedOre, 2, instance)
    };
}
