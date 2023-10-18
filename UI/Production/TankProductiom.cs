using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Toggle = UnityEngine.UI.Toggle;

public class TankProductiom : MonoBehaviour
{
    public static TankProductiom Instance;

    [SerializeField] private GameObject Choise;

    [SerializeField] private GameObject BaseChoises;
    [SerializeField] private GameObject UpgradeChoises;

    [SerializeField] private List<GameObject> Choises;

    [SerializeField] private List<EquipmentTank> EquipmentTanks;

    private Vector3 StartPos = new Vector3(120, 103, 0);

    private void Awake()
    {
        Instance = this;
        SetInfo();
    }      

    private void SetBaseInfo()
    {
        for (int i = 0; i < TankProductionManager.Instance.currentTank.Base.Count; i++)
        {
            float y = Choise.transform.position.y - i * 35;

            GameObject choise = Instantiate(Choise, new Vector3(Choise.transform.position.x, y, 0), Quaternion.identity);
            choise.GetComponent<Choise>().SetInfo(TankProductionManager.Instance.currentTank.Base[i]);
            choise.GetComponent<Toggle>().interactable = false;

            Choises.Add(choise);

            if (ResourceManager.Instance.Resources[TankProductionManager.Instance.currentTank.Base[i]] == 0)
            {
                choise.GetComponent<Toggle>().isOn = false;
            }
            
            choise.transform.SetParent(BaseChoises.transform, false);
        }
    }

    private void SetUpgradeInfo()
    {
        for (int i = 0; i < TankProductionManager.Instance.currentTank.Updates.Count; i++)
        { 
            float y = Choise.transform.position.y - i * 35;
           
            GameObject choise = Instantiate(Choise, new Vector3(Choise.transform.position.x, y, 0), Quaternion.identity);
            choise.GetComponent<Choise>().SetInfo(TankProductionManager.Instance.currentTank.Updates[i]);
            
            Choises.Add(choise);

            if (ResourceManager.Instance.Resources[TankProductionManager.Instance.currentTank.Updates[i]] == 0)
            {
                choise.GetComponent<Toggle>().isOn = false;
                choise.GetComponent<Toggle>().interactable = false;
            }

            choise.transform.SetParent(UpgradeChoises.transform, false);
        }
    }

    public void SetInfo()
    {
        if (Choises.Count > 0)
        {
            foreach (var item in Choises)
            {
                Destroy(item);
            }

            Choises.Clear();
        }

        SetBaseInfo();
        SetUpgradeInfo();
        EquipmentTanks.ForEach(item => item.SetInfo(TankProductionManager.Instance.currentTank));
    }
}
