using UnityEngine;
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; protected set; }

    [Header("Singleton Settings")]
    [Space(5)]
    [SerializeField] protected bool immortal = true;
    public bool Immortal => immortal;

    protected virtual void Awake() => HandleSingleton();

    private void HandleSingleton() {
        if (Instance == null)
        {
            Instance = this as T;
            if (immortal)
                DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
            Destroy(gameObject);
    }

    private void OnDestroy() {
        if (Instance == this)
            Instance = null;
    }
}
