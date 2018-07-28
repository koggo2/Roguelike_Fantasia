using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : BaseReactor {
    protected Animator _animator;

    protected virtual void Awake() {
        _animator = GetComponentInChildren<Animator>(true);
    }

#if UNITY_EDITOR
    protected virtual void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
    }
#endif
}
