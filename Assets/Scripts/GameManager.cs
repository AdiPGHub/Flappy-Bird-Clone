using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Player player;
	int score;
	public Text scoreTxt;
	public GameObject playBtn, quitBtn;
	public GameObject ImgGame, ImgOver, ImgLogo;
	// public GameObject ImgGame, ImgOver, ImgLogo, ImgGet, ImgReady;

	void Awake()
	{
		Application.targetFrameRate = 60;
		Pause();
		// score = 0;
		// scoreTxt.text = "0";
	}

	void Pause()
	{
		// Pause the game and set time movement to 0. The update functions will stop working.
		Time.timeScale = 0;
		player.enabled = false;
	}

	public void Play()
	{
		score = 0;
		scoreTxt.text = "0";

		// Turn all the required UI elements to On and non-required ones to Off.
		scoreTxt.gameObject.SetActive(true);
		playBtn.SetActive(false);
		quitBtn.SetActive(false);
		// ImgGet.SetActive(true);
		// ImgReady.SetActive(true);
		ImgLogo.SetActive(false);
		ImgGame.SetActive(false);
		ImgOver.SetActive(false);

		PipeMover[] pipeMovers = FindObjectsByType<PipeMover>(FindObjectsSortMode.None);
		foreach (PipeMover pipe in pipeMovers)
		{
			Destroy(pipe.gameObject);
		}

		Time.timeScale = 1;
		player.enabled = true;
	}

	public void GameOver()
	{
		// Play the Death Sound
		FindAnyObjectByType<AudioManager>().PlaySound("Death");

		// Turn all the required UI elements to On and non-required ones to Off.
		ImgGame.SetActive(true);
		ImgOver.SetActive(true);
		playBtn.SetActive(true);
		quitBtn.SetActive(true);

		// Debug.Log("LOSER");
		Pause(); // Pause the game
	}

	public void AddScore()
	{
		FindAnyObjectByType<AudioManager>().PlaySound("Score");
		score++;
		scoreTxt.text = score.ToString();
	}

	public void Quit()
	{
		Application.Quit();
	}
}
