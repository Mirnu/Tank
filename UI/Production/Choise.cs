using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Toggle = UnityEngine.UI.Toggle;

public class Choise : MonoBehaviour
{
    [SerializeField] private Text name;
    [SerializeField] private TMP_Text Count;

    private Toggle toogle;

    private string text;

    private void Awake()
    {
        toogle = GetComponent<Toggle>();
    }

    private void Start()
    {
        toogle.onValueChanged.AddListener(OnChanged);
    }

    private void OnChanged(bool state)
    {
        if (state)
        {
            TankProductionManager.Instance.currentTank.Updates.Add(text);
        }
        else
        {
            TankProductionManager.Instance.currentTank.Updates.RemoveAt(TankProductionManager.Instance.currentTank.Updates.IndexOf(text));
        }
    }

    public void SetInfo(string text)
    {
        this.text = text;

        name.text = text;
        Count.text = ResourceManager.Instance.Resources[text].ToString();
    }
}
