using System;
using System.Collections;
using Other;
using UnityEngine;

namespace Weather {
  public class WeatherRandomizer : MonoBehaviour {
    [SerializeField]
    private RainController _rainController;

    private void Start() {
      var currentRainNumber = Randomizer.GetUniqueInt();
    }
  }
}