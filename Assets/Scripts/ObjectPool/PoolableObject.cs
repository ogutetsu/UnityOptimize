using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolableObject
{
    void New();
    void Respawn();
}
