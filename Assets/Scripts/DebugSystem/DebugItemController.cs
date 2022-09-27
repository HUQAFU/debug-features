using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DebugItemController : MonoBehaviour
{
    [SerializeField]
    string debugItemId;

    [SerializeField]
    bool defaultValue;

    [SerializeField]
    PrioritededItem[] enabledGameObjectsWithPriority;

    [SerializeField]
    PrioritededItem[] disabledGameObjectsWithPriority;

    DebugManager _mDebugManager;

    void Awake()
    {
        _mDebugManager = DebugManager.Instance;
        _mDebugManager.OnDebugKeyChanged += OnDebugKeyChanged;
        _mDebugManager.InitializeKey(debugItemId, defaultValue);
    }

    void OnDebugKeyChanged(string debugKey, bool value)
    {
        if (debugKey.Equals(debugItemId))
        {
            var listSortedByPriority = enabledGameObjectsWithPriority.OrderByDescending(x => x.priority);
            foreach (var enabledGameObject in listSortedByPriority)
            {
                enabledGameObject.item.SetActive(value);
            }

            listSortedByPriority = disabledGameObjectsWithPriority.OrderByDescending(x => x.priority);
            foreach (var disabledGameObject in listSortedByPriority)
            {
                disabledGameObject.item.SetActive(!value);
            }
        }
    }

    [Serializable]
    struct PrioritededItem
    {
        public GameObject item;
        public int priority;
    }
}