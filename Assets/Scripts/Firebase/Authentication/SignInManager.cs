using Firebase.Auth;
using UnityEngine;

namespace Firebase.Authentication {
  public class SignInManager : MonoBehaviour {
    private FirebaseAuth _auth;

    private bool SingIn(string email, string password) {
      var res = false;
      _auth.SignInWithEmailAndPasswordAsync(email, password)
        .ContinueWith(task => {
                        if (task.IsCanceled) {
                          Debug.LogError("SignInWithEmailAndPasswordAsync is canceled");
                          return;
                        }

                        if (task.IsFaulted) {
                          Debug.LogError("SignInWithEmailAndPasswordAsync is faulted");
                          return;
                        }

                        FirebaseUser newUser = task.Result;
                        Debug.Log($"User is signed in successfully {newUser.Email}: {newUser.DisplayName}");
                        res = true;
                      });
      return res;
    }
  }
}