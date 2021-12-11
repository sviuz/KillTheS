using UnityEngine;
using Random = System.Random;

namespace Other {
  public static class Randomizer {
    private static int previousNumber;
    private static int currentNumber;
    
    public static float GetUniqueInt() {
      var rand = new Random();
      currentNumber = rand.Next(0,100);
      if (previousNumber == currentNumber) {
        do {
          currentNumber = rand.Next(0,100);
        } while (currentNumber!=previousNumber);
      }

      previousNumber = currentNumber;
      return currentNumber;
    }
  }
}