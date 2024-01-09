using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MinimizeButton : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;
    [SerializeField] Button button;
    [SerializeField] Image arrowIcon;
    [SerializeField] LayoutElement element;
    [SerializeField] float animationTime;

    private float height;

    private bool isMinimizing;
    private float currentAnimationTime;
    private void Awake()
    {
        height = element.minHeight;
        currentAnimationTime = animationTime;
        button.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        StopAllCoroutines();

        isMinimizing = !isMinimizing;
        currentAnimationTime = animationTime - currentAnimationTime;
        arrowIcon.transform.localScale = new Vector2 (isMinimizing? -1 : 1, 1);

        StartCoroutine(MinimizationRoutine());
    }

    IEnumerator MinimizationRoutine()
    {
        while (currentAnimationTime < animationTime)
        {
            element.minHeight = Mathf.Lerp(isMinimizing ? height : 0, isMinimizing ? 0 : height,  curve.Evaluate(currentAnimationTime / animationTime));
            currentAnimationTime += Time.deltaTime;
            yield return null;
        }
    }
}
