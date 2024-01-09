using UnityEngine;
using UnityEngine.UI;

public class SelectedBookmark : MonoBehaviour
{
    [SerializeField] Image image;
    public void SetParameters(Transform transform, Sprite sprite)
    {
        image.sprite = sprite;
        this.transform.position = transform.position;
    }
}
