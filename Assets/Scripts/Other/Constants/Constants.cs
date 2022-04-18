namespace Other {
  public static class Constants {
    public const string UPPER_CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public const string LOWER_CHARS = "abcdefjhijklmnopqrstuvwxyz";
    public const string NUMBERS = "0123456789";
    public static string SavedFullInventory = nameof(SavedFullInventory);
    public static string SavedQuickInventory = nameof(SavedQuickInventory);
    public const string TRUE = "true";
    public const string FALSE = "false";
    public enum ItemType {
      Food,
      Poison,
      Money,
      Quest,
      Other
    }

    public enum EnemyType {
      Skeleton,
      Wizard
    }

    public enum InventoryType {
      QuickInventory,
      FullInventory,
      Inventory
    }

    public enum MoveTriggers {
      Hurt,
      Attack,
      Jump,
      Grounded,
      AnimState,
      AirSpeed,
      Death,
      Recover
    }
    
    public struct Tags {
      public static string Player = nameof(Player);
      public static string Enemy = nameof(Enemy);
      public static string Quest = nameof(Quest);
    }

    public enum TagsEnum {
      Player,
      Enemy,
      Drag
    }

    public enum EnemyState {
      Angry,
      Attack,
      Idle
    }
  }
}