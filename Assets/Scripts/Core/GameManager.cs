using System;
using UnityEngine;
using Zenject;

namespace Core {
  public class GameManager : MonoBehaviour {
    [SerializeField]
    private GameObject _player;

    [Inject]
    public Vector2 GetPlayerPosition() {
      if (_player) {
        return _player.transform.position;
      }

      throw new NullReferenceException("Player is not set");
    }

  }
}