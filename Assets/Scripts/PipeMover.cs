using UnityEngine;

public class PipeMover : MonoBehaviour
{
	public float speed = 5f;
	float leftEdge;

	void Start()
	{
		// Debug.Log(Camera.main.ScreenToWorldPoint(Vector3.zero).x);
		leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
	}

	void Update()
	{
		transform.position += Time.deltaTime * speed * Vector3.left;

		if (transform.position.x < leftEdge)
		{
			Destroy(gameObject);
		}
	}
}
