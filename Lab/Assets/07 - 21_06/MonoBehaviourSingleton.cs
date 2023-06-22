using UnityEngine;

public class MonoBehaviourSingleton<T> : MonoBehaviour where T : Component
{
	public bool persistance;
    private static T instance;

    public static T Get()
    {
        return instance;
    }

    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            if (persistance)
				DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
