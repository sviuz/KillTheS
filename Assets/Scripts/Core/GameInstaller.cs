using UnityEngine;
using Zenject;

namespace Core {
  public class GameInstaller : MonoInstaller {
    public override void InstallBindings() {
      Container.Bind<GameManager>().AsSingle();
    }
  }
}