using UnityEngine;
using UnityEngine.UI;

public class GameManagerBak : MonoBehaviour
{
	public Player player;

	public Text scoreTxt;
	int score = 0;
	public GameObject playBtn, quitBtn;
	public GameObject ImgGame, ImgOver, ImgLogo;
	// public GameObject ImgGame, ImgOver, ImgGet, ImgReady, ImgLogo;

	void Awake()
	{
		scoreTxt.text = "0";
	}

	void Start()
	{
		Pause();
	}

	void Pause()
	{
		Time.timeScale = 0;
	}

	// FIXME: When you lose a game and want to play again, the Flappy doesn't reset its position, and drifts into the direction, it was last facing at.
	public void GameStart()
	{
		ResetGame();

		ImgLogo.SetActive(false);
		scoreTxt.gameObject.SetActive(true);
		playBtn.SetActive(false);
		quitBtn.SetActive(false);
		// ImgGet.SetActive(true);
		// ImgReady.SetActive(true);
		ImgGame.SetActive(false);
		ImgOver.SetActive(false);

		Time.timeScale = 1f;
	}

	public void GameOver()
	{
		// Debug.Log("LOSER");
		Pause();
		ImgGame.SetActive(true);
		ImgOver.SetActive(true);
		playBtn.SetActive(true);
		quitBtn.SetActive(true);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void AddScore()
	{
		score++;
		scoreTxt.text = score.ToString();
	}

	void ResetGame()
	{
		score = 0;
		scoreTxt.text = "0";

		PipeMover[] pipeMovers = FindObjectsByType<PipeMover>(FindObjectsSortMode.None);
		foreach (PipeMover pipe in pipeMovers)
		{
			Destroy(pipe.gameObject);
		}

		player.transform.position = new Vector3(0, 0, 0);
		player.transform.rotation = Quaternion.Euler(0, 0, 0);
	}
}
