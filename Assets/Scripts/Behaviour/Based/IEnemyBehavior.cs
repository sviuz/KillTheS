﻿using System.Collections;

namespace Behaviour.Based {
  public interface IEnemyBehavior: ISubjectBehaviour {
    public void Patrol();
    public void Angry();
    public void ReturnToPatrol();
  }
}