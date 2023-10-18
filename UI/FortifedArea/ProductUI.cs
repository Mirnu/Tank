using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductUI : MonoBehaviour
{
    private Button button;
    public int ID;
    public WorkShop workShop;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        button.onClick.AddListener(Clicked);
    }

    private void Clicked()
    {
        ProductionManager.Instance.ShowInfo(this);
    }
}
