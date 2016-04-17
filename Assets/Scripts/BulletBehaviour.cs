using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
	/// <summary> Called explosion force. </summary>
	public float ExplosionForce = 10.00f;

	/// <summary> Called explosion radius. </summary>
	public float ExplosionRadius = 0.05f;

	/// <summary> The list of RigidBody components. </summary>
	private Rigidbody[] Bodies;


	/// <summary> Called upon initialization. </summary>
	void Start()
	{
		// Retrieve the list of rigid bodies
		Bodies = GameObject.Find("ImageTarget").GetComponentsInChildren<Rigidbody>();
	}

	/// <summary> Called on collision. </summary>
	void OnCollisionEnter()
	{
		// Create an explosion force for all other objects in the scene
		foreach (Rigidbody body in Bodies)
		{
			if (body == null) continue;
			body.AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius);
		}

		// Destroy the object after a short while
		Destroy(gameObject, 0.1f);
	}
}
