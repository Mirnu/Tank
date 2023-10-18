using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AirTower : WorkShop
{
    public override string Description { get; set; } = "производит нитраты, порох, воду известняк и органику";
    public override string name { get; set; } = "Химический";

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
        ["энергия"] = 100,
        ["детали заводов"] = 150,
        ["уголь"] = 100,
        ["нефть"] = 100,
        ["сталь"] = 200,
        ["деньги"] = 2000,
        ["пластик"] = 100,
        ["резина"] = 50
    };

    private static Dictionary<string, int> ResourceForNitrates { get; set; } = new Dictionary<string, int>()
    {
        ["известняк"] = 2,
        ["органика"] = 2,
    };

    private static Dictionary<string, int> ResourceForGunpowder { get; set; } = new Dictionary<string, int>()
    {
        ["сера"] = 3,
        ["уголь"] = 3,
        ["нитраты"] = 3,
        ["вода"] = 1,
        ["энергия"] = 4,
    };

    private static Dictionary<string, int> ResourceForWater { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 2,
        ["деньги"] = 2
    };

    private static Dictionary<string, int> ResourceForLimeStone { get; set; } = new Dictionary<string, int>()
    {
        ["руда"] = 2,
        ["деньги"] = 5
    };

    private static Dictionary<string, int> ResourceForOrganic { get; set; } = new Dictionary<string, int>()
    {
        ["энергия"] = 2,
        ["деньги"] = 2
    };

    public override List<Product> Goods { get; set; } = new List<Product>()
    {
        new Product("нитраты", ResourceForNitrates, 2, instance),
        new Product("порох", ResourceForGunpowder, 7, instance),
        new Product("вода", ResourceForWater, 5, instance),
        new Product("известняк", ResourceForLimeStone, 2, instance),
        new Product("органика", ResourceForOrganic, 5, instance)
    };
}
