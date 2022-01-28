namespace Behaviour.Based {
	public interface ISubjectBehaviour {
		public void Move(float value);
		public void Attack();
		public void Idle();
		public void Hurt(int value);
		public void Death();
		public void Jump();
	}
}