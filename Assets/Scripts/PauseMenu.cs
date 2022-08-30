using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

	public static bool GamePaused = false;
	public GameObject PauseMenuUI;
	public Button but;
	public Sprite play;
	public Sprite pause;
    public void PauseGame()
	{
		if(GamePaused)
		{
			Resume();
		}
		else
		{
			Pause();
		}
		Debug.Log("Pause clicked");
	}
	
	void Pause()
	{
		//PauseMenuUI.SetActive(true);
		but.image.sprite = play;
		Time.timeScale = 0f;
		GamePaused = true;
	}
	
	void Resume()
	{
		//PauseMenuUI.SetActive(false);
		but.image.sprite = pause;
		Time.timeScale = 1f;
		GamePaused = false;
	}
}
