using UnityEngine;

public class MaterialRandomer : MonoBehaviour
{
	[SerializeField] private Material[] _materials;

	public Material GetRandom()
	{
		int randomMaterial = Random.Range(0, _materials.Length);
		return _materials[randomMaterial];
	}
}
