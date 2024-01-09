using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class MessageBox : MonoBehaviour
{
    [SerializeField] private MessageDatabase messageDatabase;
    [SerializeField] private MessageView messagePrefab;

    private ObjectPool<MessageView> messagePool;
    private CharacterId lastCharacterId;
    private DateTime lastRedrawTime;

    public List<MessageView> activeViews;

    private void Awake()
    {
        messagePool = new ObjectPool<MessageView>(
        () => Instantiate(messagePrefab).GetComponent<MessageView>(),
        view => view.gameObject.SetActive(true),
        view => view.gameObject.SetActive(false),
        null,false,10,20);
    }

    private void OnEnable()
    {
        ShowMessages(lastCharacterId);
    }

    public void ShowMessages(CharacterId characterId)
    {
        if (lastRedrawTime > messageDatabase.lastUpdateTime && lastCharacterId == characterId) return;

        foreach (var view in activeViews)
        {
            messagePool.Release(view);
        }
        activeViews.Clear();

        foreach (var message in messageDatabase.messages
            .Where(message => message.CharacterId == characterId && (DateTime.Parse(message.Date) < DateTime.Now))
            .OrderByDescending(message => DateTime.Parse(message.Date)))
        {
            var view = messagePool.Get();
            view.DisplayMessage(message);
            view.transform.SetAsLastSibling();
            activeViews.Add(view);
        }

        lastCharacterId = characterId;
        lastRedrawTime = DateTime.Now;
    }
}
