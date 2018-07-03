using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TerrainActor : MonoBehaviour {

	private StageActor _stageActor;
	
	private void Awake() {
		_stageActor = GetComponentInParent<StageActor>();
	}
	
	public void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject())
			return;
		
		var mPosition = Input.mousePosition;
		var mainCam = Camera.main;

		var ray = mainCam.ScreenPointToRay(mPosition);
		var hit = new RaycastHit();
		var stageLayer = LayerMask.NameToLayer("Stage");

		if (Physics.Raycast(ray, out hit, 1000f, 1 << stageLayer)) {
			_stageActor?.OnPlayerClickedPlane(hit.point);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
