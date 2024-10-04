using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	private Player player;
	public Text scoreText;
	public GameObject playButton;
	public GameObject lostImage;
	public GameObject quitImage;

	private int score;

	private void Awake()
	{
		Application.targetFrameRate = 60;
		player = FindFirstObjectByType<Player>();
		Pause();
	}

	public void Play()
	{
		score = 0;
		scoreText.text = score.ToString();
		playButton.SetActive(false);
		lostImage.SetActive(false);
		quitImage.SetActive(false);
		Time.timeScale = 1f;
		player.enabled = true;

		Moving[] moving = FindObjectsByType<Moving>(FindObjectsSortMode.None);
		for (int i = 0; i < moving.Length; i++)
		{
			Destroy(moving[i].gameObject);
		}
	}

	public void Pause()
	{
		Time.timeScale = 0f;
		player.enabled = false;
	}

	public void IncreaseScore()
	{
		score++;
		scoreText.text = score.ToString();
	}

	public void GameOver()
	{
		lostImage.SetActive(true);
		playButton.SetActive(true);
		quitImage.SetActive(true);
		Pause();
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
