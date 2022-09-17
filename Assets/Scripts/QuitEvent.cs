using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitEvent : MonoBehaviour
{
	public GameObject QuitUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void confirmQuit()
	{
		Application.Quit();
		Debug.Log("Quit");
	}
	
	public void goBack()
	{
		Time.timeScale = 1f;
		QuitUI.SetActive(false);
	}	
}

