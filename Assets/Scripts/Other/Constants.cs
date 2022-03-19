using System;
using Behaviour;
using InventoryBased;

namespace Other {
  public static class Constants {
    public delegate void AddItemToInventory(InventoryItem item);
    public delegate bool RemoveItemFromQuickListEvent(int index);

    public static string MyInventory = nameof(MyInventory);

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