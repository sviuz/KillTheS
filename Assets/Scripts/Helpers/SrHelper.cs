using UnityEngine;
using static Other.Constants;

namespace Helpers {
  public class SrHelper : MonoBehaviour {
    
  }

  public static class DataGenerator {
    public static string GenerateId(int length) {
      var str = "";
      string[] chars = {NUMBERS, UPPER_CHARS, LOWER_CHARS}; 
      for (int i = 0; i < length; i++) {
        str += chars[Random.Range(0, 2)][Random.Range(0,chars.Length)];
      }
      return str;
    }
  }
}