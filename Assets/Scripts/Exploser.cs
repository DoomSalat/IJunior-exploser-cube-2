using UnityEngine;

public class Exploser : MonoBehaviour
{
	[SerializeField] private float _explosionForce = 1000f;
	[SerializeField] private float _upwardsModifier = 0.5f;
	[SerializeField] private float _torqueForce = 50f;
	[SerializeField] private float _explosionRadius = 3f;

	public void Explose(Vector3 central, float multiplier)
	{
		Collider[] colliders = Physics.OverlapSphere(central, _explosionRadius);

		foreach (Collider hit in colliders)
		{
			Rigidbody rigidbody = hit.GetComponent<Rigidbody>();

			if (rigidbody != null)
			{
				rigidbody.AddExplosionForce(_explosionForce * multiplier, central, _explosionRadius * multiplier, _upwardsModifier);

				Vector3 direction = (rigidbody.transform.position - central).normalized;
				Vector3 torque = Vector3.Cross(direction, Vector3.down) * _torqueForce;
				rigidbody.AddTorque(torque, ForceMode.Impulse);
			}
		}
	}
}