using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ModeChange : MonoBehaviour
{
    public static ModeChange instance;

    public GameObject StartScreen;

    private GameObject currentMode;

    private bool inited = false;

    private Vector3 StartPos = new Vector3(-2.33999991f, 3.98000002f, -5.73999977f);
    private Vector3 StartRot = new Vector3(45, 45, -1.2f);

    public void Init(GameObject mode)
    {
        if (!inited)
        {
            Camera.main.transform.position = StartPos;
            Camera.main.transform.rotation = Quaternion.Euler(StartRot);

            instance = this;
            inited = true;

            StartScreen = mode;
            currentMode = mode;

            currentMode.SetActive(true);
        }
    }

    public void ChangeCam(Vector3 p, Vector3 r)
    {
        Camera.main.transform.position = p;
        Camera.main.transform.rotation = Quaternion.Euler(r);
    }

    public void Change(GameObject mode)
    {
        mode.SetActive(true);
        currentMode.SetActive(false);

        currentMode = mode;
    }
}
