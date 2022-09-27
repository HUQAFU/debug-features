using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Holds all debug states
//Add this objects to first scene
public class DebugManager : SingletonMB<DebugManager>
{
    readonly Dictionary<string, bool> _debugKeys = new();
    public event Action<string, bool> OnDebugKeyChanged;
    bool _showDebug;
    
    void OnGUI()
    {
        var height = 20;
        var yOffset = Screen.height - height;
        _showDebug = GUI.Toggle(new Rect(50, yOffset - height, 150, height), _showDebug, "Show debug features");
        if (_showDebug)
        {
            var elementsCount = 0;
            var keys = new List<string>(_debugKeys.Keys);
            foreach (var debugKey in keys)
            {
                elementsCount++;
                var value = GUI.Toggle(new Rect(80, yOffset - height - elementsCount * height, 150, height),
                    _debugKeys[debugKey], debugKey);
                if (value != _debugKeys[debugKey])
                {
                    SetDebugKey(debugKey, value);
                }
            }
        }
    }

    public void InitializeKey(string debugKey, bool defaultValue)
    {
        var value = PlayerPrefs.GetInt($"debug_{debugKey}", -1);
        if (value < 0)
        {
            value = defaultValue ? 1 : 0;
        }

        SetDebugKey(debugKey, value == 1);
        PlayerPrefs.Save();
    }

    void SetDebugKey(string debugKey, bool value)
    {
        PlayerPrefs.SetInt($"debug_{debugKey}", value ? 1 : 0);
        if (!_debugKeys.ContainsKey(debugKey))
        {
            _debugKeys.Add(debugKey, value);
        }
        else
        {
            _debugKeys[debugKey] = value;
        }

        OnDebugKeyChanged?.Invoke(debugKey, value);
    }
}