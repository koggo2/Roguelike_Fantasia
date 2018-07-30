using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class TerrainReactor : BaseReactor {

	public delegate void HitTerrain(Vector3 point);
	public HitTerrain OnHitTerrain;

	protected override void OnClick() {
		base.OnClick();
		
		if (EventSystem.current.IsPointerOverGameObject())
			return;
		
		var mPosition = Input.mousePosition;
		var mainCam = Camera.main;

		var ray = mainCam.ScreenPointToRay(mPosition);
		var hit = new RaycastHit();
		var stageLayer = LayerMask.NameToLayer("Stage");
		
		if (Physics.Raycast(ray, out hit, 1000f, 1 << stageLayer)) {
			var navMeshHit = new NavMeshHit();
			if(NavMesh.SamplePosition(hit.point, out navMeshHit, 100.0f, NavMesh.AllAreas))
				OnHitTerrain?.Invoke(navMeshHit.position);
		}
	}
}
