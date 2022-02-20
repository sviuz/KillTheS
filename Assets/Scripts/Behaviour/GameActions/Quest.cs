using System;

namespace Behaviour.Questable {
  public class Quest {
    public Action OnTakeQuest;
    public Action OnFinishQuest;
    
    public string QuickDescription;
    public string FullDescription;
    
    public bool isTaken;
    
  }
}