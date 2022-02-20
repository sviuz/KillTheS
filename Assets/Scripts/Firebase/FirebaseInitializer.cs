using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Firebase {
  public class FirebaseInitializer : MonoBehaviour {
    public UnityEvent _onFirebaseInitialized;
    
    private void Start() {
      StartCoroutine(CheckAndFixDependenciesCoroutine());
    }
    
    private IEnumerator CheckAndFixDependenciesCoroutine()
    {
      Task<DependencyStatus> checkDependenciesTask = FirebaseApp.CheckAndFixDependenciesAsync();
      yield return new WaitUntil(() => checkDependenciesTask.IsCompleted);

      DependencyStatus dependencyStatus = checkDependenciesTask.Result;
      if (dependencyStatus != DependencyStatus.Available) yield break;

      print($"Firebase: {dependencyStatus}.");
      _onFirebaseInitialized.Invoke();
    }
  }
}