using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class SquadManager : MonoBehaviour
{
    public static SquadManager instance;

    [Header("Specifications")]
    [SerializeField] private Image tankImage;
    [SerializeField] private TMP_Text TankName;
    [SerializeField] private TMP_Text Type;
    [SerializeField] private TMP_Text Armor;
    [SerializeField] private TMP_Text Speed;
    [SerializeField] private TMP_Text Damage;
    [SerializeField] private TMP_Text RadioStation;
    [SerializeField] private TMP_Text Disguise;
    [SerializeField] private TMP_Text DetectionDevice;

    [Header("Tank")]
    [SerializeField] private GameObject TankUI;

    public List<TankInSquad> tanksInSquad = new List<TankInSquad>();

    private void Awake()
    {
        instance = this;
    }

    private string GetStateText(bool radioStation)
    {
        if (radioStation)
        {
            return "есть";
        }
        else
        {
            return "нет";
        }
    }

    private void UpdateSpecifications(Tank tankData)
    {
        tankImage.sprite = tankData.tankImage;
        TankName.text = tankData.tankName;
        Type.text = tankData.type;
        Armor.text = tankData.armor.ToString();
        Speed.text = tankData.speed.ToString();
        Damage.text = $"{tankData.minDamage} - {tankData.maxDamage}";
        RadioStation.text = GetStateText(tankData.radioStation);
        Disguise.text = tankData.disguise.ToString() + "%";
        DetectionDevice.text = GetStateText(tankData.detectionDevice);
    }

    private void SetDataTankUI(Tank tankData, GameObject tankUI)
    {
        TankInSquad _tankData = tankUI.GetComponent<TankInSquad>();

        tanksInSquad.Add(_tankData);

        _tankData.SetSlot(tanksInSquad.Count, tankData);
    }

    private void ChangeTransform(GameObject tankUI, int i, float y)
    {
        RectTransform transformTank = tankUI.GetComponent<RectTransform>();
        transformTank.pivot += new Vector2(0, i * y);
    }

    private void AddTankInSquadUI(Tank tankData)
    {
        GameObject tankUI = Instantiate(TankUI, transform);
        ChangeTransform(tankUI, tanksInSquad.Count, -0.7f);

        SetDataTankUI(tankData, tankUI);
    }

    public void AddSquad(Tank tankData)
    {
        if (tanksInSquad.Count < 4)
        {
            UpdateSpecifications(tankData);
            AddTankInSquadUI(tankData);
        }
    }

    public void DellTankInSquad(TankInSquad tank)
    {
        bool passed = false;

        for (int i = 0; i < tanksInSquad.Count + 1; i++)
        {
            if (passed)
            {
                ChangeTransform(tanksInSquad[i - 1].gameObject, 1, 0.7f);
                tanksInSquad[i - 1].SetText(i);
            }

            if (!passed && tanksInSquad[i] == tank)
            {
                passed = true;
                tanksInSquad.RemoveAt(tanksInSquad.IndexOf(tank));
            }
        }
    }
}
