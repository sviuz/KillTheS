using UnityEngine;

namespace Core {
  public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    public static T Instance;

    private void Start() {
      if (Instance == null) {
        Instance = this as T;
      } else {
        Destroy(gameObject);
      }
    }
  }
}