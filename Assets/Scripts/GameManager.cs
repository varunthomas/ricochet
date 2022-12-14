using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public GameObject startUI;
	public int remBricks;
	public bool gameStarted;
	public Text HighScore;
	public Text HighScoreText;
	public Text Level;
	int lvl = 1;
	public Text LevelNum;
	public GameObject QuitUI;
	public GameObject ContinueUI;
	public bool continue_game = false;
	int score;
	public bool isWin;
	bool ad_shown = false;
	public float timer;
	public bool startTimer;
	public Text textScore;
	//public GameObject winText;


	private void Awake()
	{
		instance = this;
	}
    // Start is called before the first frame update
    void Start()
    {
		Debug.Log("Activiatng power up in gamemanager");
		Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
		//Debug.Log(stageDimensions.x);
		HighScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        //remBricks = SceneGenerator.instance.getBrickCount();
		//Debug.Log("rem bricks " + remBricks);
		//SceneGenerator.instance.toggleAllBricks(false);
	}

    // Update is called once per frame
    void Update()
    {

		 if (Input.GetKeyDown(KeyCode.Escape)) 
		 {
			QuitUI.SetActive(true);
			Time.timeScale = 0f;			
		 }
		if (startTimer == true)
		{
			foreach (Ball obj in Ball.ballsClasses) {
				obj.bounceForce = 2;
			}
			var balls = GameObject.FindGameObjectsWithTag("Ball");
			/*foreach (var ball in balls)
			{
				 var rb = ball.GetComponent<Rigidbody2D>();
				 Debug.Log("Slowing down " + rb.velocity);
				 rb.velocity = .2f* (rb.velocity.normalized);
				 Debug.Log("After Slowing down " + rb.velocity);
			}*/
			timer += Time.deltaTime;
			if (timer >= 5f)
			{
				startTimer = false;
				foreach (Ball obj in Ball.ballsClasses) {
					obj.bounceForce = 5;
				}
				/*foreach (var ball in balls)
				{
					var rb = ball.GetComponent<Rigidbody2D>();
					rb.velocity = 5* (rb.velocity.normalized);
				}*/
				timer = 0f;
			}
		}
        if (isWin == true)
		{
			
			var balls = GameObject.FindGameObjectsWithTag("Ball");
			foreach (var ball in balls)
			{
				Destroy(ball);
			}
			/*if(Input.anyKeyDown)
			{
				Restart();
			}*/
		}
    }
	public void Restart()
	{
		if (ad_shown)
		{
			SceneManager.LoadScene("Game");
		}
		else
		{	
			ContinueUI.SetActive(true);
			ad_shown = true;
		}
		//SceneManager.LoadScene("Game");
	}
	public void ScoreUp(int val)
	{
		score=score+1;
		if (val == 5)
		{
			//Debug.Log("rem bricks " + remBricks);
			remBricks--;
			//Debug.Log("rem bricks " + remBricks);
		}
		textScore.text = score.ToString();
		if (remBricks == 0)
		{
			//winText.SetActive(true);
			//textScore.gameObject.SetActive(false);
			lvl++;
			LevelNum.text = lvl.ToString();
			SceneGenerator.instance.numBricks = 0;
			isWin = true;
		}
	}
	public void GameStart()
	{
		//Debug.Log("Game start");
		remBricks = SceneGenerator.instance.getBrickCount();
		//Debug.Log("rem bricks start " + remBricks);
		startUI.SetActive(false);
		textScore.gameObject.SetActive(true);
		Level.gameObject.SetActive(true);
		LevelNum.gameObject.SetActive(true);
		HighScore.gameObject.SetActive(false);
		HighScoreText.gameObject.SetActive(false);
		SceneGenerator.instance.toggleAllBricks(true);
		SceneGenerator.instance.setSpecialBrick();
	}
	
	public void SetHighScore()
	{
		if (PlayerPrefs.GetInt("HighScore",0) < score)
		{
			PlayerPrefs.SetInt("HighScore", score);
			
		}
	}
}
