using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Effect : MonoBehaviour
{
    [SerializeField] private EffectInfo effectInfo;
    [SerializeField] private float timeDelay;
    public IEnumerator ReturnToPool(Stack<PooledObject> effectStack)
    {
        yield return new WaitForSeconds(timeDelay);
        GetComponent<PooledObject>().Release(effectStack);
        gameObject.SetActive(false);
    }
}
