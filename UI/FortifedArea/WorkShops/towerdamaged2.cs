using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class towerdamaged2 : WorkShop
{
    public override string Description { get; set; } = "производит энергию";
    public override string name { get; set; } = "Энергетический";

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
        ["энергия"] = 100,
        ["детали заводов"] = 150,
        ["уголь"] = 100,
        ["нефть"] = 100,
        ["сталь"] = 200,
        ["деньги"] = 2000,
        ["пластик"] = 100,
        ["резина"] = 50
    };

    private static Dictionary<string, int> ResourceForEnergyFromCoal { get; set; } = new Dictionary<string, int>()
    {
        ["уголь"] = 10,
    };

    private static Dictionary<string, int> ResourceForEnergyFromGas { get; set; } = new Dictionary<string, int>()
    {
        ["газ"] = 10,
    };

    private static Dictionary<string, int> ResourceForEnergyFromOil { get; set; } = new Dictionary<string, int>()
    {
        ["нефть"] = 10,
    };

    public override List<Product> Goods { get; set; } = new List<Product>()
    {
        new Product("энергия", ResourceForEnergyFromCoal, 3, instance),
        new Product("энергия", ResourceForEnergyFromGas, 4, instance),
        new Product("энергия", ResourceForEnergyFromOil, 4, instance),
    };
}
