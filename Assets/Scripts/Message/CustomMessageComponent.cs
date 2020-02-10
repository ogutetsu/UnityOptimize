using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMessage : Message
{
    public readonly GameObject gameObject;
    public readonly string name;
}


public class CustomMessageComponent : MonoBehaviour
{

    private void Start()
    {
        MessageSystem.Instance.AttachListener(typeof(CustomMessage),
                                            this.HandleMessage);
    }

    private void Update()
    {
        //スペースキーを押すと、HandleMessage関数がキューに入り、MessageSystemから呼び出されます。
        if(Input.GetKeyDown(KeyCode.Space))
        {
            MessageSystem.Instance.QueueMessage(new CustomMessage());
        }
    }


    bool HandleMessage(Message msg)
    {
        Debug.Log("CustomMessageComponent.HandleMessage");
        return true;
    }

}

