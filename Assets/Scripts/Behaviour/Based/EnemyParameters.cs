using System;
using Other;

namespace Behaviour.Based {
	[Serializable]
	public abstract class EnemyParameters : SubjectParameters {
		public Data.EnemyType Type;
		public bool isPatrolling;
	}
}