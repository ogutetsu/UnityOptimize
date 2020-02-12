using System.Collections;
using System.Collections.Generic;

public class ObjectPool<T> where T : IPoolableObject, new()
{
    private Stack<T> _pool;
    private int _currentIndex = 0;

    public ObjectPool(int initialCapacity)
    {
        _pool = new Stack<T>(initialCapacity);
        for(int i = 0; i < initialCapacity; i++)
        {
            Spawn();
        }
        Reset();
    }

    public int Count
    {
        get { return _pool.Count; }
    }

    public void Reset()
    {
        _currentIndex = 0;
    }

    public T Spawn()
    {
        if(_currentIndex < Count)
        {
            T obj = _pool.Peek();
            _currentIndex++;
            IPoolableObject po = obj as IPoolableObject;
            po.Respawn();
            return obj;
        } 
        else
        {
            T obj = new T();
            _pool.Push(obj);
            _currentIndex++;
            IPoolableObject po = obj as IPoolableObject;
            po.New();
            return obj;
        }
    }


}
