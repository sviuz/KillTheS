using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Firebase {
  public class FirebaseDatabaseManager : MonoBehaviour {
    public static FirebaseDatabaseManager Instance;
    private FirebaseDatabase _database;
    private DatabaseReference _databaseReference;
    private readonly List<string> _listOfUsernames = new List<string>();
    private readonly List<string> _listOfPassword = new List<string>();

    private void Awake() {
      if (Instance == null) {
        Instance = this;
      } else {
        Destroy(gameObject);
      }
      DontDestroyOnLoad(gameObject);
    }

    private void Start() {
      GetInternalUsernames();
    }

    public void SaveData(string id, string username, string password, int index = 0) {
      _database = FirebaseDatabase.DefaultInstance;
      _databaseReference = _database.RootReference;

      var user = new User(id, username, password, index);
      string json = JsonConvert.SerializeObject(user);
      _databaseReference.Child("Users")
        .Child(user.username)
        .SetRawJsonValueAsync(json);
    }

    public List<string> GetListOfUsernames() {
      return _listOfUsernames;
    }

    public List<string> GetListOfPasswords() {
      return _listOfPassword;
    }

    private void GetInternalUsernames() {
      _database ??= FirebaseDatabase.DefaultInstance;
      _database.GetReference("Users/").GetValueAsync().ContinueWith(ContinuationFunction());
    }

    private Action<Task<DataSnapshot>> ContinuationFunction() {
      return task => {
               if (!task.IsCompleted) return;

               DataSnapshot snapshot = task.Result;
               snapshot.Children.ToList()
                 .ForEach(
                   child => _listOfUsernames.Add(child.Key));
               snapshot.Children.ToList()
                 .ForEach(
                   child =>
                     child.Children.ToList().ForEach(_value => {
                                                       if (_value.Key == "password") {
                                                         _listOfPassword.Add(_value.Value.ToString());
                                                       }
                                                     }));
             };
    }
  }
}