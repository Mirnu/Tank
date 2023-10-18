using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotReadyMenu : MonoBehaviour
{
    public void OnClose()
    {
        ModeChange.instance.Change(ModeChange.instance.StartScreen);
    }
}
