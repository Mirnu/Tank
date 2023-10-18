using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class ButtonTransition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TMP_Text Text;

    private PostProcessVolume postProcessVolume;
    private Vignette vignette;

    public GameObject Mode;

    private void Awake()
    {
        postProcessVolume = Camera.main.GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out vignette);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(TweenVignetteValue(0.3f, 0.2f));    
        StartCoroutine(TweenValue(Color.yellow, Color.white, 50));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(TweenVignetteValue(0.2f, 0.3f));
        StartCoroutine(TweenValue(Color.white, Color.yellow, 50));
    }

    public void ButtonClick()
    {
        Text.color = Color.yellow;
        ModeChange.instance.Change(Mode);
    }

    private IEnumerator TweenVignetteValue(float v2, float time)
    {
        float x = time / 100;

        for (float i = 0; i < time; i += x)
        {
            yield return new WaitForSeconds(0.005f);
            vignette.smoothness.value = Mathf.Lerp(vignette.smoothness.value, v2, i);
        }
    }

    private IEnumerator TweenValue(Color c1, Color c2, float time)
    {
        for (float i = 0; i < time; i += 0.01f)
        {
            yield return new WaitForSeconds(0.005f);
            Text.color = Color.Lerp(c1, c2, i);
        }
    }
}
