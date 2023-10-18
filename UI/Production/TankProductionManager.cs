using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TankProductionManager : MonoBehaviour
{
    public static TankProductionManager Instance;

    [Header("Text")]
    [SerializeField] private TMP_Text TankName;
    [SerializeField] private TMP_Text TankType;
    [SerializeField] private TMP_Text TankArmor;
    [SerializeField] private TMP_Text TankSpeed;
    [SerializeField] private TMP_Text TankDamage;
    [SerializeField] private TMP_Text TankRadioStation;
    [SerializeField] private TMP_Text TankDisguise;
    [SerializeField] private TMP_Text TankDetecionDevice;
    [SerializeField] private Image TankImage;
    [SerializeField] private Button CreateButton;

    [Header("Tank")]
    public Tank currentTank;

    private void Awake()
    {
        Instance = this;
        CreateButton.onClick.AddListener(Create);
    }

    private void Start()
    {
        SetInfo();
    }

    private string GetStateModule(bool module)
    {
        if (module)
        {
            return "есть";
        }
        else
        {
            return "нет";
        }
    }

    private void SetInfo()
    {
        TankName.text = currentTank.tankName;
        TankType.text = currentTank.type;
        TankArmor.text = currentTank.armor.ToString();
        TankSpeed.text = currentTank.speed.ToString();
        TankDamage.text = $"{currentTank.minDamage} - {currentTank.maxDamage}";
        TankRadioStation.text = GetStateModule(currentTank.radioStation);
        TankDisguise.text = $"{currentTank.disguise}%";
        TankDetecionDevice.text = GetStateModule(currentTank.detectionDevice);
        TankImage.sprite = currentTank.tankImage;
    }

    private void ShowButton()
    {
        Image image = CreateButton.GetComponent<Image>();

        image.color = Color.white;
        if (CheckOnRes()) 
        {
            image.color = Color.red;
        }
    }

    public void SetTank(TankSelectionUI tankUI, Tank tank)
    {
        if (currentTank)
            tankUI.SetTank(currentTank);

        currentTank = tank;

        ShowButton();
        SetInfo();
        TankProductiom.Instance.SetInfo();
    }

    private void Buy()
    {
        foreach (var resource in currentTank.Updates)
        {
            ResourceManager.Instance.Resources[resource] -= 1;
        }
    }

    private bool CheckOnRes()
    {
        foreach (var resource in currentTank.Updates)
        {
            if (ResourceManager.Instance.Resources[resource] <= 0)
            {
                return false;
            }
        }

        return true;
    }

    public void Create()
    {
        if (currentTank)
        {
            if (CheckOnRes())
            {
                Buy();
                TankManager.instance.Tanks[currentTank.tankName].DelTankInSquad(currentTank);

                SetInfo();
                TankProductiom.Instance.SetInfo();

                ShowButton();
            }
        } 
    }
}
