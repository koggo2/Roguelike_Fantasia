
using UnityEngine;

public static class CharacterPositioning {

	private static float _gap = 2.0f;
	
	private static Vector3[] _positions = {
		new Vector3(0f, 0f, 0f),
		new Vector3(-_gap, 0f, 0f),
		new Vector3(_gap, 0f, 0f),
		new Vector3(-_gap, 0f, -_gap),
		new Vector3(0f, 0f, -_gap),
		new Vector3(_gap, 0f, -_gap),
		new Vector3(-_gap, 0f, -_gap * 2),
		new Vector3(0f, 0f, -_gap * 2),
		new Vector3(_gap, 0f, -_gap * 2),
	};
	
	public static Vector3 GetPosition(int index, float angle) {

		if (index > 8)
			return _positions[0];

		Debug.Log(angle);
		return Quaternion.Euler(0f, angle, 0f) * _positions[index];
	}
}
