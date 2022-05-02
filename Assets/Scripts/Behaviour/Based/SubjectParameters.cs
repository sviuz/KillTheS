using System;
using UnityEngine;

namespace Behaviour.Based {
	[Serializable]
	public abstract class SubjectParameters : MonoBehaviour {
		public float Speed;
		public Transform AttackPosition;
		public float AttackRange;
		public LayerMask Mask;
	}
}