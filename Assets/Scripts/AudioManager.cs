using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
	public static bool soundOn = true;
	public Button AudioToggle;
	public Sprite mute;
	public Sprite unmute;
    // Start is called before the first frame update
    void Start()
    {
        if(soundOn)
		{
			AudioToggle.image.sprite = unmute;
		}
		else
			AudioToggle.image.sprite = mute;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void ToggleMusic()
	{
		if(soundOn)
		{
			Debug.Log("Turning off sound");
			AudioToggle.image.sprite = mute;
			soundOn = false;
			AudioListener.volume = 0f;
			
		}
		else
		{
			Debug.Log("Turning on sound");
			AudioToggle.image.sprite = unmute;
			soundOn = true;
			AudioListener.volume = 1f;
		}
	}
}
