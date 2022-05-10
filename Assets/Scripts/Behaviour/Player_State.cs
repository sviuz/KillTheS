using UnityEngine;

namespace Behaviour {
	public class Player_State : MonoBehaviour {
		private int _сolCount = 0;
		private float _disableTimer;

		private void OnEnable() {
			_сolCount = 0;
		}

		public bool State() {
			if (_disableTimer > 0)
				return false;
			return _сolCount > 0;
		}

		private void OnTriggerEnter2D(Collider2D other) {
			_сolCount++;
		}

		private void OnTriggerExit2D(Collider2D other) {
			_сolCount--;
		}

		private void Update() {
			_disableTimer -= Time.deltaTime;
		}

		public void Disable(float duration) {
			_disableTimer = duration;
		}
	}
}