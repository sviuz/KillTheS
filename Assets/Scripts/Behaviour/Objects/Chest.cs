using DG.Tweening;
using InventoryBased;
using Other;
using UnityEngine;

public class Chest : MonoBehaviour {
  [SerializeField]
  private GameObject _enterDetector;

  private bool isClosed = true;
  
  private float _startDetectorPosY;

  private void Awake() {
    _startDetectorPosY = _enterDetector.transform.localPosition.y;
  }

  private void OnTriggerEnter2D(Collider2D col) {
    if (!col.CompareTag(Data.Tags.Player)) return;
        
    print("open chest"); 
    EnterDetection();
  }

  private void OnTriggerExit2D(Collider2D col) {
    if (!col.CompareTag(Data.Tags.Player)) return;
    
    print("close chest ");
    EnterDetection(false);
  }

  private void EnterDetection(bool b = true) {
    var sq = DOTween.Sequence();
    if (b) {//Enter
      sq.Append(_enterDetector.transform.DOLocalMoveY(_startDetectorPosY + 15, .2f));
    } else {//Exit
      sq.Append(_enterDetector.transform.DOLocalMoveY(_startDetectorPosY, .2f));
      
    }
  }
}