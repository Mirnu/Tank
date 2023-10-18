using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.PostProcessing;

public class ObjectTransition : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
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
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(TweenVignetteValue(0.2f, 0.3f));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ModeChange.instance.Change(Mode);
        ModeChange.instance.ChangeCam(new Vector3(16.379f, 20.1800f, -55.3f), new Vector3(90, 0, 0));
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
}
