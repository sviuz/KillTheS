using System.Threading.Tasks;
using UnityEngine;

namespace Firebase {
  public class FirebaseAppManager : MonoBehaviour {
    public static FirebaseAppManager Instance;
    private FirebaseApp app;
    
    private void Awake() {
      if (Instance == null) {
        Instance = this;
      } else {
        Destroy(gameObject);
      }
    }

    private void Start() {
      ValidateVersions();
    }

    private void ValidateVersions() {
      FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(CheckFirebaseApp);
    }

    private void CheckFirebaseApp(Task<DependencyStatus> task) {
      DependencyStatus dependencyStatus = task.Result;
      if (dependencyStatus == DependencyStatus.Available) {
        app = FirebaseApp.DefaultInstance;
      }
    }
  }
}