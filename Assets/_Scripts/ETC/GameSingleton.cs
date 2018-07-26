using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameSingleton<T> : MonoBehaviour where T : MonoBehaviour {
    private static T _instance;

    public static T Instance {
        get {
            if (_instance == null) {

                if (FindObjectsOfType<T>().Count() > 0) {
                    _instance = FindObjectOfType<T>();
                    return _instance;
                }

                var singletonGameObject = new GameObject();
                _instance = singletonGameObject.AddComponent<T>();
                singletonGameObject.name = "(singleton) " + typeof(T);
            }

            return _instance;
        }
    }

    protected virtual void Awake() {
        DontDestroyOnLoad(this);
    }
}
