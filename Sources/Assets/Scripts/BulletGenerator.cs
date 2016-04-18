using UnityEngine;
using System.Collections;

public class BulletGenerator : MonoBehaviour {

	/// <summary> The Force of the bullet. </summary>
	public float BulletForce = 500000.0f;

	/// <summary> Detects if the user has touched the sceen. </summary>
	public static bool TouchRelease()
	{
		bool b = false;
		for (int i = 0; i < Input.touches.Length; i++)
		{
			b = Input.touches[i].phase == TouchPhase.Ended;
			if (b) break;
		}
		return b;
	}

	/// <summary> Called on every frame. </summary>
	void Update () {
		if (Input.GetMouseButtonUp(0) || TouchRelease())
		{
			Vector3 position = gameObject.transform.position;
			Vector3 forward = gameObject.transform.forward.normalized;
			GameObject bullet = Instantiate(Resources.Load("Bullet", typeof(GameObject))) as GameObject;
			bullet.transform.position = position;
			bullet.GetComponent<Rigidbody>().AddForce(forward * BulletForce, ForceMode.Impulse);
		}
	}
}
