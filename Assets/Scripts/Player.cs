using UnityEngine;

public class Player : MonoBehaviour
{
	// For changing the Sprites to make it look like Flappy is flapping its wings
	SpriteRenderer spriteRenderer;
	public Sprite[] sprites;
	int spriteInd = -1;
	public float repeatFreq = 0.15f;
	float angleRotateFlappy = -1.25f;

	// For making the Flappy go up and down
	Rigidbody2D rb;
	Vector3 direction;
	bool jumpRequested = false;
	public float strength = 5f;
	public float gravity = -9.5f;

	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		InvokeRepeating(nameof(AnimateSprite), 0, repeatFreq);
	}

	void OnEnable()
	{
		// transform.position = new Vector3(transform.position.x, 0, transform.position.z);
		transform.SetPositionAndRotation(new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
	}

	void OnDisable()
	{
		direction.y = 0;
		transform.position += Time.deltaTime * direction;
	}

	void Update()
	{
		// Check if the Space key is pressed or the Left Mouse Button is clicked or the Touch Screen is touched
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
		{
			jumpRequested = true;
		}
	}

	void FixedUpdate()
	{
		// Apply the physics-based jump if input was detected and reset jumpRequested to False
		if (jumpRequested)
		{
			// rb.linearVelocity = strength * Vector2.up;
			direction = Vector3.up * strength;
			transform.rotation = Quaternion.Euler(0, 0, 25);
			jumpRequested = false;
			FindAnyObjectByType<AudioManager>().PlaySound("Flap");
		}

		direction.y += Time.deltaTime * gravity;
		transform.position += Time.deltaTime * direction;
		// rb.linearVelocity += Time.fixedDeltaTime * gravity * Vector2.up;
		transform.Rotate(0, 0, angleRotateFlappy);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("GameOver"))
		{
			FindAnyObjectByType<GameManager>().GameOver();
		}
		else if (other.gameObject.CompareTag("AddScore"))
		{
			FindAnyObjectByType<GameManager>().AddScore();
		}
	}

	void AnimateSprite()
	{
		spriteInd++;
		spriteInd %= sprites.Length;
		spriteRenderer.sprite = sprites[spriteInd];
	}
}
