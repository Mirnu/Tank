using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankSelectionUI : MonoBehaviour
{
    [SerializeField] private Tank tank;
    [SerializeField] private Image image;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        TankProductionManager.Instance.SetTank(this, tank);
    }

    public void SetTank(Tank tank)
    {
        this.tank = tank;
        image.sprite = tank.tankImage;
    }
}
