using UnityEngine;

public class SingletonMB<T> : MonoBehaviour where T : MonoBehaviour
{
	static T _instance;

	static object _lock = new();

	static bool _isQuitting;

	public static T Instance
	{
		get
		{
			lock(_lock)
			{
				if (_instance == null)
				{
					var objects = FindObjectsOfType(typeof(T));
					
					if (objects.Length > 0)
					{
						_instance = (T) objects[0];
					}
					else if (objects.Length > 1)
                    {
                        Debug.LogWarning($"There are more than one object with type: {typeof(T).Name}");
                        return _instance;
                    }

					if (_instance == null && !_isQuitting) return null;
				}

				return _instance;
			}
		}
	}

	void OnDestroy () 
	{
		OnDestroySpecific();
	}

	void OnApplicationQuit()
	{
		_isQuitting = true;
	}

	protected virtual void OnDestroySpecific() {}
}
