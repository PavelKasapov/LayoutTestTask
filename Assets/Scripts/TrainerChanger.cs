using UnityEngine;

public class TrainerChanger : MonoBehaviour
{
    [SerializeField] MessageBox messageBox;
    [SerializeField] TrainerSelectButton[] TrainerSelectButtons;

    private CharacterId lastCharacterId;

    private void Start()
    {
        SetActiveTrainer(lastCharacterId);
    }

    public void SetActiveTrainer(CharacterId characterId)
    {
        foreach (var trainerButton in TrainerSelectButtons)
        {
            trainerButton.SetSelected(trainerButton.characterId == characterId);
        }

        messageBox.ShowMessages(characterId);

        lastCharacterId = characterId;
    }
}
