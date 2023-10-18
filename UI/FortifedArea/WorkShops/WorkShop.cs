using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class WorkShop : MonoBehaviour
{
    abstract public Dictionary<string, int> ResourcesForConstruction { get; set; }
    abstract public string Description { get; set; }
    abstract public string name { get; set; }

    public bool isCreated = false;

    abstract public Sprite GetImage();

    public abstract List<Product> Goods { get; set; }
}
