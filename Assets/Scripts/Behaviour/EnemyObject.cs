using System;
using Behaviour.Based;
using UnityEngine;

namespace Behaviour {
	public class EnemyObject : EnemyParameters,
		ISubjectBehaviour {

		[SerializeField]private CircleCollider2D _circleCollider;
		[SerializeField]private SpriteRenderer _exclamationPointSprite;
		[SerializeField]private bool _patrolled = true;
		[SerializeField]private Transform[] _patrollingPoints;

		private bool isPatrolling = false;
		
		private void Awake() {
			_circleCollider.radius = RadiusSearch > 0 ? RadiusSearch : 3.5f;
		}

		private void Start() {
			isPatrolling = true;
		}

		private void OnTriggerEnter(Collider other) {
			print("JOPA");
		}

		public void ShowWarning() {
			_exclamationPointSprite.gameObject.SetActive(true);
		}

		private void PatrollingBetweenPoints(Transform pointA, Transform pointB) {
			if (isPatrolling) {
				
			}
		}

		#region Interface relization

		public void Move(float values) {
			throw new System.NotImplementedException();
		}
		public void Attack() {
			throw new System.NotImplementedException();
		}
		public void Idle() {
			throw new System.NotImplementedException();
		}
		public void Hurt() {
			throw new System.NotImplementedException();
		}
		public void Death() {
			throw new System.NotImplementedException();
		}
		public void Jump() {
			throw new System.NotImplementedException();
		}
		public void CombatIdle() {
			throw new System.NotImplementedException();
		}
		public void Grounded() {
			throw new System.NotImplementedException();
		}

		#endregion


	}
}