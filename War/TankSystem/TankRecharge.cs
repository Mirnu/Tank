using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankRecharge : MonoBehaviour
{
    private Image ChargedImage;
    public bool isRecharged = false;
    public float SpeedRecharge;

    private void Awake()
    {
        ChargedImage = GetComponent<Image>();
    }

    private void Start() => StartRecharge();

    public void StartRecharge()
    {
        ChargedImage.enabled = true;
        ChargedImage.fillAmount = 0;
        isRecharged = false;

        StartCoroutine(Recharge());
    }

    private IEnumerator Recharge()
    {
        for (float i = 0; i < 1; i += SpeedRecharge/100)
        {
            yield return new WaitForSeconds(0.05f);
            ChargedImage.fillAmount = i;
        }

        ChargedImage.enabled = false;
        isRecharged = true;
    }
}
