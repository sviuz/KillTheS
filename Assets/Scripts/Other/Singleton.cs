using UnityEngine;

namespace Other {
  public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    private static bool _mShuttingDown;
    private static readonly object MLock = new object();
    private static T _mInstance;

    private static void GetInstance() {
      if (_mInstance == null) {
        _mInstance = (T) FindObjectOfType(typeof(T));
      }
    }

    private static void StartManager() {
      lock (MLock) {
        GetInstance();
      }
    }

    private void Start() {
      StartManager();
    }

    public static T Instance {
      get {
        if (_mShuttingDown) {
          return null;
        }

        lock (MLock) {
          GetInstance();
          return _mInstance;
        }
      }
    }

    private void OnApplicationQuit() {
      _mShuttingDown = true;
    }
  }
}