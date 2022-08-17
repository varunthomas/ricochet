using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public GameObject GameStartUI;
	int remBricks;
	int score;
	bool isWin;
	public Text textScore;
	public Text winText;

	private void Awake()
	{
		instance = this;
	}
    // Start is called before the first frame update
    void Start()
    {
        remBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
		Debug.Log("rem " + remBricks);
    }

    // Update is called once per frame
    void Update()
    {
        if (isWin == true)
		{
			Debug.Log("win true");
			var balls = GameObject.FindGameObjectsWithTag("Ball");
			foreach (var ball in balls)
			{
				Destroy(ball);
			}
			if(Input.anyKeyDown)
			{
				Restart();
			}
		}
    }
	public void Restart()
	{
		SceneManager.LoadScene("Game");
	}
	public void ScoreUp(int val)
	{
		//Debug.Log("val " + val + "score before " +score);
		score=score+val;
		if (val == 5)
		{
			remBricks--;
		}
		Debug.Log("new rem " + remBricks);
		Debug.Log("score after " + score);
		textScore.text = score.ToString();
		if (remBricks == 0)
		{
			winText.gameObject.SetActive(true);
			textScore.gameObject.SetActive(false);
			isWin = true;
		}
	}
	public void GameStart()
	{
		GameStartUI.SetActive(false);
		textScore.gameObject.SetActive(true);
	}
}
