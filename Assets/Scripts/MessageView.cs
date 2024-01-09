using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class MessageView : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI date;

    [SerializeField] private MessageData messageData;

#if UNITY_EDITOR
    private void Update()
    {
        DisplayMessage(messageData);
    }
#endif


    public void DisplayMessage(MessageData messageData)
    {
        if (this.messageData == messageData)
#if UNITY_EDITOR
            if (EditorApplication.isPlaying)
#endif
            return;

        icon.sprite = messageData.Icon;
        title.text = messageData.Title;
        text.text = messageData.Message;
        date.text = messageData.Date.Substring(0, 5);
        title.color = MyContsants.TitleColors[messageData.TitleColor];

        this.messageData = messageData;
    }
}
