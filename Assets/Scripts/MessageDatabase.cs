using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MessageDatabase", menuName = "ScriptableObjects/MessageDatabase", order = 1)]
public class MessageDatabase : ScriptableObject
{
    public DateTime lastUpdateTime = DateTime.Now;
    public MessageData[] messages;
}
