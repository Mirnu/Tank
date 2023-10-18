using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentTank : MonoBehaviour
{
    [SerializeField] private Text name;
    [SerializeField] private TMP_Text Count;

    public string text;

    private float Max;

    private Tank tank;

    public void SetInfo(Tank tank)
    {
        this.tank = tank;

        if (text == "")
        {
            name.text = tank.bullet;
            this.text = tank.bullet;
            Max = float.PositiveInfinity;
            Count.text = ResourceManager.Instance.Resources[text].ToString();
            tank.currentBullet = ResourceManager.Instance.Resources[text];
        }
        else
        {
            name.text = text;
            Max = tank.maxFuel;
            Count.text = Mathf.Min(ResourceManager.Instance.Resources[text], tank.maxFuel).ToString();
            tank.currentFuel = ResourceManager.Instance.Resources[text];
        }
    }

    private void ChangeText()
    {
        if (text == "")
        {
            tank.currentBullet = ResourceManager.Instance.Resources[text];
        }
        else
        {  
            tank.currentFuel = ResourceManager.Instance.Resources[text];
        }

        Count.text = ResourceManager.Instance.Resources[text].ToString();
    }

    public void Plus()
    {
        if (tank != null)
        {
            ResourceManager.Instance.Resources[text] = (int)Mathf.Min(ResourceManager.Instance.Resources[text] + 1, Max);

            ChangeText();
        } 
    }

    public void Minus()
    {
        if (tank != null)
        {
            ResourceManager.Instance.Resources[text] = (int)Mathf.Clamp(ResourceManager.Instance.Resources[text] - 1, 0, Max);

            ChangeText();
        }
    }
}
