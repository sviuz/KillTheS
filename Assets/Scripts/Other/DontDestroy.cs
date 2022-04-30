using UnityEngine;

namespace Other {
  public class DontDestroy : MonoBehaviour {
    private void Awake() {
      DontDestroyOnLoad(gameObject);
    }
  }
}
