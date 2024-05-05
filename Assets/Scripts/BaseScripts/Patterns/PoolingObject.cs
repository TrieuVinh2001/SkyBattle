using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolingObject : Singleton<PoolingObject>
{
    public void SetupPool(Stack<PooledObject> stack, PooledObject objectToPool, int initPoolSize,Transform holder)
    {
        if (objectToPool == null)
        {
            return;
        }
        for (int i = 0; i < initPoolSize; i++)
        {
            PooledObject instance = Instantiate(objectToPool, holder);
            instance.Pool = this;
            instance.gameObject.SetActive(false);
            stack.Push(instance);
        }
    }

    public PooledObject GetPooledObject(Stack<PooledObject> stack, PooledObject objectToPool, Transform holder)
    {
        if (objectToPool == null)
        {
            return null;
        }

        if (stack.Count == 0)
        {
            PooledObject newInstance = Instantiate(objectToPool, holder);
            newInstance.Pool = this;
            return newInstance;
        }
        PooledObject nextInstance = stack.Pop();
        nextInstance.gameObject.SetActive(true);
        return nextInstance;
    }

    public void ReturnToPool(Stack<PooledObject> stack, PooledObject pooledObject)
    {
        stack.Push(pooledObject);
        pooledObject.gameObject.SetActive(false);
    }
}
