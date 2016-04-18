using UnityEngine;
using System.Collections;

public class EnemyCanon : MonoBehaviour {

	/// <summary> The AR Camera GameObject. </summary>
	GameObject ARCamera;

	/// <summary> The Rotation Speed. </summary>
	float speRotationSpeed = 1.0f;

	/// <summary> The curent shoot time. </summary>
	float CurrentShootTime = 0;

	/// <summary> The next shoot time. </summary>
	float NextShootTime;


	/// <summary> Called upon initialization. </summary>
	void Start ()
	{
		// Get the AR Camera
		ARCamera = GameObject.Find("ARCamera") ;

		// Calculate the next shoot time
		NextShootTime = Random.Range(2f, 6f);
    }

	/// <summary> Called on every frame. </summary>
	void Update ()
	{
		// Get the target position and adjust the rotation
		Vector3 target = ARCamera.transform.position; target.y = transform.position.y;
		Quaternion targetRotation = Quaternion.LookRotation(ARCamera.transform.position - transform.position);

		// Smoothly rotate towards the target point.
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speRotationSpeed * Time.deltaTime);

		// Shoot whenever the time is right
		if (GetComponent<Renderer>().enabled)
		{
			CurrentShootTime += Time.deltaTime;
			if (CurrentShootTime > NextShootTime)
			{
				// Create the new bullet instance
				GameObject bullet = Instantiate(Resources.Load("EnemyBullet", typeof(GameObject))) as GameObject;
				bullet.transform.position = transform.position;
				bullet.GetComponent<EnemyBullet>().Direction = transform.forward.normalized; ;

				// Restart the shoot time
				NextShootTime = Random.Range(2f, 6f); CurrentShootTime = 0;
			}
		}

		// If the canon reaches the floor, it should dissapear
		if (transform.parent.position.y < 0.02f)
		{
			GameManager.Instance.Enemies -= 1;
			Destroy(transform.parent.gameObject);
		}
	}
}
