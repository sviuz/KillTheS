using System;
using UnityEngine;
using Zenject;

namespace Core {
  public class GameManager : MonoBehaviour {
    [SerializeField]
    private GameObject Player;

    [Inject]
    public Vector3 GetPlayerPosition() {
      if (Player) {
        return Player.transform.position;
      }

      throw new NullReferenceException("Player is not set");
    }

  }
}