using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Player player;
    // private Spawner spawner;
    public Text scoreText;
    public GameObject playButton;
    public GameObject lostImage;

    private int score;

    private void Awake() {
        Application.targetFrameRate = 60;
        player = FindObjectOfType<Player>();
        // spawner = FindObjectOfType<Spawner>();
        Pause();
    }

    public void Play() {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        lostImage.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

        Moving[] moving = FindObjectsOfType<Moving>();
        for(int i=0 ; i<moving.Length ; i++) {
            Destroy(moving[i].gameObject);
        }
    }

    public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void increaseScore() {
        score++;
        scoreText.text = score.ToString();
    }

    public void gameOver() {
        lostImage.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }
}
