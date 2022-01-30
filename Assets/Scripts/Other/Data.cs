using System;
using Behaviour;

namespace Other {
	public static class Data {
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
		
		public class MoveTriggers {
			public string Hurt = "Hurt";
			public string Attack = "Attack";
			public string Jump = "Jump";
			public string Grounded = "Grounded";
			public string AnimState = "AnimState";
			public string AirSpeed = "AirSpeed";
			public string Death = "Death";
			public string Recover = "Recover";
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
