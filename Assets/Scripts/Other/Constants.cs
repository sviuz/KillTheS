using System;
using Behaviour;
using InventoryBased;

namespace Other {
	public static class Constants {
		public delegate void AddItemToInventory(InventoryItem item);
		public delegate void RemoveItemToInventoryByIndex(int index);
		
		public static class PlayerData {
			public static MoveTriggers moveTriggers = new MoveTriggers();
		}
		
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
			FullInventory
		}
		
		public class MoveTriggers {
			public readonly string Hurt = "Hurt";
			public readonly string Attack = "Attack";
			public readonly string Jump = "Jump";
			public readonly string Grounded = "Grounded";
			public readonly string AnimState = "AnimState";
			public readonly string AirSpeed = "AirSpeed";
			public readonly string Death = "Death";
			public readonly string Recover = "Recover";
		}
		
		public struct Tags {
			public static string Player = "Player";
			public static string Enemy = "Enemy";
			
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
