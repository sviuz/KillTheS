using UnityEngine;

namespace Weather {
  public class WeatherController : MonoBehaviour {
    [SerializeField]
    private Transform target;
    private void Update() {
      transform.position = new Vector3(transform.position.x, 1.3f, transform.position.z);
    }
  }
}