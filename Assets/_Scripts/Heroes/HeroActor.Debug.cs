using UnityEngine;

public partial class HeroActor {
    
#if UNITY_EDITOR
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
        Gizmos.DrawWireSphere(transform.position, _agent.radius);
    }
#endif
    
}
