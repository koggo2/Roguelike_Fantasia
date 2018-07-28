using UnityEngine;

public partial class HeroActor {
#if UNITY_EDITOR
    protected override void OnDrawGizmos() {
        base.OnDrawGizmos();
        
        Gizmos.DrawWireSphere(transform.position, _agent.radius);
    }
#endif
}
