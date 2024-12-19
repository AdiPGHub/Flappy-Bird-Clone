using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
	public GameObject prefab;
	public float spawnRate = 1f;
	public float spawnWaitDuration = 2f;
	float maxHeight = 2.5f;
	float minHeight = -1.75f;

	void FixedUpdate()
	{
		transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x + 2f, 0, -1);
	}
	void OnEnable()
	{
		InvokeRepeating(nameof(SpawnPipes), spawnWaitDuration, spawnRate);
	}

	void OnDisable()
	{
		CancelInvoke(nameof(SpawnPipes));
	}

	void SpawnPipes()
	{
		GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
		pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
		pipes.tag = "GameOver";
	}
}
