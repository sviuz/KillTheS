namespace Other {
	public static class Data {
		public static class PLayerData {
			public static MoveTriggers moveTriggers = new MoveTriggers();
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
		}
	}
}
