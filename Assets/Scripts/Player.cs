using UnityEngine;

public class Player : MonoBehaviour {
    private SpriteRenderer spriteRenderer;      // Hamari saari images ek sprite hoti hai and unhi ko render karne ke liye spriteRenderer use hota hai.
    public Sprite[] sprites;    // sprites ek list hai jisme hamari Flappy Bird ki alag alag images hai, jinhe ek ke baad ek chala ke animation banega.
    private int spriteIndex;    // spriteIndex is doing the same work as "i" in a loop.
    private Vector3 direction;
    public float gravity = -22f;
    public float strength = 8f;
    public float tilt = 5f;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start () {
        InvokeRepeating(nameof(animateSprite), 0.1f, 0.1f);
    }
    
    private void OnEnable() {
        Vector3 position = transform.position;
        position. y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * strength;
        }

        // if(Input.touchCount > 0) {
        //     Touch touch = Input.GetTouch(0);
        //     if(touch.phase == TouchPhase.Began) {
        //         direction = Vector3.up * strength;
        //     }
        // }
        
        transform.position += direction * Time.deltaTime;
        direction.y += gravity * Time.deltaTime;
        
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;
    }

    private void animateSprite() {
        spriteIndex++;
        if(spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Defeat") {
            FindObjectOfType<GameManager>().gameOver();
        }
        else if(other.gameObject.tag == "Score") {
            FindObjectOfType<GameManager>().increaseScore();
        }
        else if(other.gameObject.tag == "ExitGame") {
            FindObjectOfType<GameManager>().quitGame();
        }
    }

}
