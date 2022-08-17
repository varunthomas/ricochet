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
	public void ScoreUp()
	{
		score++;
		textScore.text = score.ToString();
	}
	public void GameStart()
	{
		GameStartUI.SetActive(false);
		textScore.gameObject.SetActive(true);
	}
}
