using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TankInSquad : MonoBehaviour
{
    [SerializeField] private TMP_Text slotText;
    [SerializeField] private TMP_Text slotTankText;
    [SerializeField] private Image slotImage;

    public Tank tank;

    public string slotName;
    public void SetSlot(int slotNum, Tank tank)
    {
        this.tank = tank;

        slotText.text = $"слот {slotNum}";
        slotTankText.text = $"[{tank.tankName}]";
        slotImage.sprite = tank.tankImage;

        slotName = tank.tankName;
    }

    public void SetText(int slotNum)
    {
        slotText.text = $"слот {slotNum}";
    }

    public void DelTank()
    {
        WareHouseTank wareHouseTank = TankManager.instance.Tanks[tank.tankName];
        wareHouseTank.DelTankInSquad(tank);

        SquadManager.instance.DellTankInSquad(this);

        Destroy(gameObject);
    }
}
