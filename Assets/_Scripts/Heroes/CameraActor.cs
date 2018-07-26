using UnityEngine;
using UnityEngine.AI;

public class CameraActor : MonoBehaviour {

    private Quaternion _defaultRotation;

    private void Awake() {
        _defaultRotation = transform.rotation;
    }
    
    public void AttachToHero(HeroActor heroActor) {
        transform.parent = heroActor.transform;
        transform.localPosition = Vector3.zero;
    }

    private void LateUpdate() {
        transform.rotation = _defaultRotation;
    }
}

