using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public GameObject GameStartUI;
	int score;
	public Text textScore;

	private void Awake()
	{
		instance = this;
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void Restart()
	{
		SceneManager.LoadScene("Game");
	}
	public void ScoreUp(int val)
	{
		//Debug.Log("val " + val + "score before " +score);
		score=score+val;
		Debug.Log("score after " + score);
		textScore.text = score.ToString();
	}
	public void GameStart()
	{
		GameStartUI.SetActive(false);
		textScore.gameObject.SetActive(true);
	}
}
