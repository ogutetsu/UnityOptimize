using System.Collections;
using System.Collections.Generic;

public class Message 
{
    public string type;
    public Message() { type = this.GetType().Name; }
}
