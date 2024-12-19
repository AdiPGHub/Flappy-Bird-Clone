using UnityEngine;

public class BGParallax : MonoBehaviour
{
	MeshRenderer meshRenderer;
	public float animSpeed;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Awake()
	{
		meshRenderer = GetComponent<MeshRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		meshRenderer.material.mainTextureOffset += new Vector2(Time.deltaTime * animSpeed, 0);
	}
}
