using UnityEngine;

public class TabSelector : MonoBehaviour
{
    [SerializeField] GameObject[] tabs;

    public void SelectTab(GameObject tabGameObject)
    {
        foreach (var tab in tabs)
        {
            tab.gameObject.SetActive(tab == tabGameObject);
        }
    }
}
