using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
public class PooledObject : MonoBehaviour
{
    private PoolingObject pool;
    public PoolingObject Pool { get => pool; set => pool = value; }

    public void Release(Stack<PooledObject> bulletStack)
    {
        pool.ReturnToPool(bulletStack,this);
    }
}
