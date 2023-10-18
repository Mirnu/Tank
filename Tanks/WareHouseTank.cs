using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WareHouseTank : MonoBehaviour
{
    public Tank tankData;

    [SerializeField] private TMP_Text CountTanksText;

    public List<Tank> Tanks = new List<Tank>();

    private Button button;

    private void Awake()
    {
        button = GetComponentInChildren<Button>();
    }

    private void Start()
    {
        CountTanksText.text = Tanks.Count.ToString();

        button.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        if (SquadManager.instance.tanksInSquad.Count < 4 && Tanks.Count > 0)
        {
            SquadManager.instance.AddSquad(tankData);
            Tanks.RemoveAt(0);

            CountTanksText.text = Tanks.Count.ToString();
        }
    }

    public void DelTankInSquad(Tank tank)
    {
        Tanks.Add(tank);
        CountTanksText.text = Tanks.Count.ToString();
    }
}
