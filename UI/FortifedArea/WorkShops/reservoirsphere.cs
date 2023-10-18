using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class reservoirsphere : WorkShop
{
    public override string Description { get; set; } = "производит нефть, топливо, резину и пластик";
    public override string name { get; set; } = "Нефтяной";

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
        ["энергия"] = 100,
        ["детали заводов"] = 200,
        ["уголь"] = 50,
        ["нефть"] = 100,
        ["сталь"] = 50,
        ["деньги"] = 3000,
        ["пластик"] = 100,
        ["резина"] = 50
    };

    private static Dictionary<string, int> ResourceForOil { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 2,
        ["деньги"] = 2
    };

    private static Dictionary<string, int> ResourceForFuel { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 4,
        ["нефть"] = 5,
    };

    private static Dictionary<string, int> ResourceForRubber { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 3,
        ["нефть"] = 5,
        ["органика"] = 3,
    };

    private static Dictionary<string, int> ResourceForPlastic { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 3,
        ["нефть"] = 5,
        ["органика"] = 3,
    };

    public override List<Product> Goods { get; set; } = new List<Product>()
    {
        new Product("нефть", ResourceForOil, 5, instance),
        new Product("топливо", ResourceForFuel, 4, instance),
        new Product("резина", ResourceForRubber, 5, instance),
        new Product("пластик", ResourceForPlastic, 5, instance),
    };
}
