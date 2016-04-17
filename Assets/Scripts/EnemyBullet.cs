using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	/// <summary> The AR Camera GameObject. </summary>
	GameObject ARCamera;

	/// <summary> The direction of the Bullet. </summary>
	public Vector3 Direction;

	/// <summary> The speed of the Bullet. </summary>
	public float Speed;


	/// <summary> Called upon initialization. </summary>
	void Start () {
		ARCamera = GameObject.Find("ARCamera");
		Destroy(gameObject, 6f);
	}
	
	// Update is called once per frame
	void Update () {
		
		// Recalculate the next possition
		transform.position += Direction * Speed;
		
		// If the bullet gets near the camera, destroy it and remove one life point
		if(Vector3.Distance(ARCamera.transform.position, transform.position) < 0.1f)
		{ GameManager.Instance.Life -= 1; Destroy(gameObject); }
	}
}
