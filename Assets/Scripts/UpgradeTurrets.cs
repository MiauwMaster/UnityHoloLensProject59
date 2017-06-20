using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class UpgradeTurrets : MonoBehaviour {



    #region Variables
    
    GestureRecognizer recognizer;
    RaycastHit hit;
    Camera mainCam { get { return Camera.main.GetComponent<Camera>(); } }
    Ray ray { get { return mainCam.ScreenPointToRay(this.transform.position); } }
    bool didHitSomething { get { return Physics.Raycast(ray, out hit); } }
    bool hitCollider { get { return hit.collider != null; } }
    #endregion


    #region Unity Methods

    private void Start()
    {
        recognizer = new GestureRecognizer();
        recognizer.TappedEvent += Recognizer_TappedEvent;
        recognizer.StartCapturingGestures();
    }

    void UpgradeTurret()
    {
      
        if (didHitSomething && hitCollider)
        {
            hit.collider.GetComponent<Turret>().testUpgrade = true;
        }
    }

    void Recognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        if (Camera.main.GetComponent<Player>().money >= (hit.collider.GetComponent<Turret>().price / 2))
        {
            UpgradeTurret();
        }
    }
    #endregion
}
