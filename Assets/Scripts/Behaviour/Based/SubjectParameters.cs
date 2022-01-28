using System;
using UnityEngine;

namespace Behaviour.Based {
	[Serializable]
	public abstract class SubjectParameters : MonoBehaviour {
		public int Health;
		public int AttackPoints;
		public float Speed;
		public bool isAlive;
		public Transform AttackPosition;
		public float AttackRange;
		public LayerMask Mask;
	}
}