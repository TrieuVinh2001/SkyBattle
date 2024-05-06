using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static EffectInfo;

[System.Serializable]
public class EffectInfo
{
    public enum EffectType { Explosion , Hit}
    public EffectType effectType;
    public PooledObject prefab;
    public Stack<PooledObject> stack = new Stack<PooledObject>();
}
public class EffectController : Singleton<EffectController>
{
    [SerializeField] private List<EffectInfo> effects = new List<EffectInfo>();
    private Dictionary<EffectType, Stack<PooledObject>> effectStacks = new Dictionary<EffectType, Stack<PooledObject>>();

    void Start()
    {
        foreach (var effectInfo in effects)
        {
            effectStacks[effectInfo.effectType] = effectInfo.stack;
            PoolingObject.Instance.SetupPool(effectInfo.stack, effectInfo.prefab, 1, transform);
        }
    }

    public void SpawnFX(EffectType effectType, Transform position)
    {
        if (effectStacks.ContainsKey(effectType))
        {
            var effectStack = effectStacks[effectType];
            var prefabEffectInfor = effects.Where(prefab => prefab.effectType == effectType).First();
            var effect = PoolingObject.Instance.GetPooledObject(effectStack, prefabEffectInfor.prefab, transform);
            effect.transform.position = position.position;
            effect.gameObject.SetActive(true);
            StartCoroutine(effect.GetComponent<Effect>().ReturnToPool(effectStacks[effectType]));
        }
        else
        {
            Debug.LogError($"Effect '{effectType}' not found!");
        }
    }
}
