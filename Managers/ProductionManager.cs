using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ProductionManager : MonoBehaviour
{
    public static ProductionManager Instance;

    [SerializeField] private GameObject ButtonPrefab;
    [SerializeField] private TMP_Text CostInfo;
    [SerializeField] private TMP_Text CountInfo;
    [SerializeField] private TMP_Text NameReceipe;
    [SerializeField] private TMP_Text NameReceipeCount;
    [SerializeField] private TMP_Text CountProducts;
    [SerializeField] private TMP_Text BuyButton;

    private List<GameObject> currentButtons = new List<GameObject>();

    private ProductUI currentProduct;

    private void Awake()
    {
        Instance = this;
    }

    private void CheckButtons()
    {
        if (currentButtons.Count > 0)
        {
            currentButtons.ForEach(o =>
            {
                Destroy(o.gameObject);
            });

            currentButtons.Clear();
        }
    }

    public void ShowProducts(WorkShop workshop)
    {
        CheckButtons();

        int j = 0;
        int i = 0;

        foreach (Product product in workshop.Goods)
        {
            float x = ButtonPrefab.transform.position.x + j * 100;
            float y = ButtonPrefab.transform.position.y - i * 40;

            GameObject button = Instantiate(ButtonPrefab, new Vector3(x, y, 0), Quaternion.identity);
            currentButtons.Add(button);
            button.transform.SetParent(transform, false);

            button.GetComponent<ProductUI>().ID = workshop.Goods.IndexOf(product);
            button.GetComponent<ProductUI>().workShop = workshop;
            button.GetComponentInChildren<TMP_Text>().text = product.product;

            j++;

            if (j == 4)
            {
                i++;
                j = 0;
            }
        }
    }

    private void SetCostInfo()
    {
        string text = "";

        if (currentProduct.workShop.Goods[currentProduct.ID].explore)
        {
            foreach (var resource in currentProduct.workShop.Goods[currentProduct.ID].Resource)
            {
                text += $"{resource.Key} {currentProduct.workShop.Goods[currentProduct.ID].countBuy * resource.Value} из {ResourceManager.Instance.Resources[resource.Key]}\n";
            }
        }
        else
        {
            text = "10 денег";
        }

        CostInfo.text = text;
    }

    public void SetStateButton()
    {
        if (currentProduct.workShop.Goods[currentProduct.ID].explore)
        {
            BuyButton.text = "Произвести";
        }
        else
        {
            BuyButton.text = "Изучить";
        }
    }

    public void ShowInfo(ProductUI product)
    {
        currentProduct = product;

        if (currentProduct.workShop.Goods[currentProduct.ID].explore) 
        {
            CountProducts.text = currentProduct.workShop.Goods[currentProduct.ID].countBuy.ToString();
            CountInfo.text = $"В количестве: 1 * {currentProduct.workShop.Goods[currentProduct.ID].count}"; 
            NameReceipeCount.text = $"Единиц ресурса\r\n\"{currentProduct.workShop.Goods[currentProduct.ID].product}\"";
        }
        else
        {
            CountProducts.text = "0";
            CountInfo.text = "";
            NameReceipeCount.text = "";
        }

        SetStateButton();
        SetCostInfo();
        NameReceipe.text = $"Рецепт: {currentProduct.workShop.Goods[currentProduct.ID].product}";
    }

    public void Plus()
    {
        if (currentProduct.workShop.Goods[currentProduct.ID].explore)
        {
            var value = currentProduct.workShop.Goods[currentProduct.ID];
            ++value.countBuy;
            currentProduct.workShop.Goods[currentProduct.ID] = value;
            ShowInfo(currentProduct);
        } 
    }

    public void Minus()
    {
        if (currentProduct.workShop.Goods[currentProduct.ID].explore)
        {
            var value = currentProduct.workShop.Goods[currentProduct.ID];
            --value.countBuy;
            currentProduct.workShop.Goods[currentProduct.ID] = value;
            ShowInfo(currentProduct);
        }
    }

    public bool Explore()
    {
        if (ResourceManager.Instance.Resources["деньги"] >= 10)
        {
            ResourceManager.Instance.Resources["деньги"] -= 10;
            return true;
        }

        return false;
    }

    public bool Buy()
    {
        foreach (var item in currentProduct.workShop.Goods[currentProduct.ID].Resource)
        {
            if (ResourceManager.Instance.Resources[item.Key] < item.Value * currentProduct.workShop.Goods[currentProduct.ID].countBuy)
            {
                return false;
            }
        }

        foreach (var item in currentProduct.workShop.Goods[currentProduct.ID].Resource)
        {
            ResourceManager.Instance.Resources[item.Key] -= item.Value * currentProduct.workShop.Goods[currentProduct.ID].countBuy;
        }

        ResourceManager.Instance.Resources[currentProduct.workShop.Goods[currentProduct.ID].product] += currentProduct.workShop.Goods[currentProduct.ID].count * currentProduct.workShop.Goods[currentProduct.ID].countBuy;

        return true;
    }

    public void BuyOrExplore()
    {
        if (currentProduct)
        {
            if (currentProduct.workShop.Goods[currentProduct.ID].explore)
            {
                if (Buy())
                {
                    ShowInfo(currentProduct);
                    ResourceManager.Instance.UpdateResources();
                }
            }
            else
            {
                if (Explore())
                {
                    Product product = currentProduct.workShop.Goods[currentProduct.ID];
                    product.explore = true;
                    currentProduct.workShop.Goods[currentProduct.ID] = product;
                    ShowInfo(currentProduct);
                }
            }
        }
    }
}
