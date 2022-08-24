using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public GameObject startUI;
	int remBricks;
	public bool gameStarted;
	int score;
	bool isWin;
	public Text textScore;
	public GameObject winText;
	


	private void Awake()
	{
		instance = this;
	}
    // Start is called before the first frame update
    void Start()
    {
		Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
		Debug.Log(stageDimensions.x);
        //remBricks = SceneGenerator.instance.getBrickCount();
		//Debug.Log("rem bricks " + remBricks);
		//SceneGenerator.instance.toggleAllBricks(false);
	}

    // Update is called once per frame
    void Update()
    {

        if (isWin == true)
		{
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
			//Debug.Log("rem bricks " + remBricks);
			remBricks--;
			Debug.Log("rem bricks " + remBricks);
		}
		textScore.text = score.ToString();
		if (remBricks == 0)
		{
			winText.SetActive(true);
			textScore.gameObject.SetActive(false);
			isWin = true;
		}
	}
	public void GameStart()
	{
		Debug.Log("Game start");
		remBricks = SceneGenerator.instance.getBrickCount();
		Debug.Log("rem bricks start " + remBricks);
		startUI.SetActive(false);
		textScore.gameObject.SetActive(true);
		SceneGenerator.instance.toggleAllBricks(true);
		SceneGenerator.instance.setSpecialBrick();
	}
}
