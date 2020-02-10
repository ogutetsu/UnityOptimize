using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageSystem : MonoBehaviour
{

    private static MessageSystem _instance = null;

    public static MessageSystem Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("MessageSystem");
                _instance = obj.AddComponent<MessageSystem>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    public delegate bool MessageHandlerDelegate(Message message);
    
    private Dictionary<string, List<MessageHandlerDelegate>> _listenerDict = new Dictionary<string, List<MessageHandlerDelegate>>();
    private Queue<Message> _messageQueue = new Queue<Message>();

    private const int _maxQueueProcessingTime = 16667;  //60FPS (1/60)
    private System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();

    



    private void Update()
    {
        Broadcast();
    }



    public bool AttachListener(System.Type type, MessageHandlerDelegate handler)
    {
        if(type == null)
        {
            Debug.Log("MesageSystem AttachListener failed");
            return false;
        }

        string msgType = type.Name;
        if (!_listenerDict.ContainsKey(msgType))
        {
            _listenerDict.Add(msgType, new List<MessageHandlerDelegate>());
        }

        List<MessageHandlerDelegate> list = _listenerDict[msgType];
        if(list.Contains(handler))
        {
            return false;
        }

        list.Add(handler);
        return true;
    }

    public bool QueueMessage(Message msg)
    {
        if(!_listenerDict.ContainsKey(msg.type))
        {
            return false;
        }
        _messageQueue.Enqueue(msg);
        return true;
    }


    public bool TriggerMessage(Message msg)
    {
        string msgType = msg.type;
        if(!_listenerDict.ContainsKey(msgType))
        {
            return false;
        }
        List<MessageHandlerDelegate> list = _listenerDict[msgType];

        for(int i = 0; i < list.Count; i++)
        {
            if(list[i](msg))
            {
                return true;
            }
        }
        return true;
    }


    void Broadcast()
    {
        //一定時間内にメッセージ処理が終わらなければ処理を中断します。
        //大量にメッセージが追加された場合に固まらない対策
        timer.Start();
        while(_messageQueue.Count > 0)
        {
            if(_maxQueueProcessingTime > 0.0f)
            {
                if(timer.Elapsed.Milliseconds > _maxQueueProcessingTime)
                {
                    timer.Stop();
                    return;
                }
            }

            Message msg = _messageQueue.Dequeue();
            if(!TriggerMessage(msg))
            {
                Debug.Log("Error message: " + msg.type);
            }
        }
    }

    public bool DetachListener(System.Type type, MessageHandlerDelegate handler)
    {
        if(type == null)
        {
            return false;
        }

        string msgType = type.Name;

        if(!_listenerDict.ContainsKey(type.Name))
        {
            return false;
        }

        List<MessageHandlerDelegate> list = _listenerDict[msgType];
        if(!list.Contains(handler))
        {
            return false;
        }
        list.Remove(handler);
        return true;
    }



}
