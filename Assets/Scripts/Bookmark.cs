
using UnityEngine;
using UnityEngine.UI;

public class Bookmark : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Image icon;

    [SerializeField] GameObject linkedTab;
    [SerializeField] SelectedBookmark selectedBookmark;
    [SerializeField] TabSelector tabSelector;

    private void Awake()
    {
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        selectedBookmark.SetParameters(transform, icon.sprite);
        tabSelector.SelectTab(linkedTab);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(OnClick);
    }
}
