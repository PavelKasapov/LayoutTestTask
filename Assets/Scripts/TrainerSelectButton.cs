using UnityEngine;
using UnityEngine.UI;

public class TrainerSelectButton : MonoBehaviour
{
    [SerializeField] TrainerChanger trainerChanger;
    [SerializeField] Button button;
    [SerializeField] Image backgroundImage;
    [SerializeField] Sprite defaultBackground;
    [SerializeField] Sprite selectedBackground;

    public CharacterId characterId;

    private void Awake()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        trainerChanger.SetActiveTrainer(characterId);
    }

    public void SetSelected(bool isSelected)
    {
        backgroundImage.sprite = isSelected ? selectedBackground : defaultBackground;
        button.interactable = !isSelected;
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(OnButtonClick);
    }
}
