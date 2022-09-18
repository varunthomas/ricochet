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
	public static AudioManager instance;
	AudioSource source;
	public AudioClip slowDownClip;
	public AudioClip hitClip;
	
	void Awake()
	{
		instance = this;
	}
    // Start is called before the first frame update
    void Start()
    {
		source = GetComponent<AudioSource>();
		
		
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
	
	public void PlayPowerUpAudio()
	{
		source.clip = slowDownClip;
		source.Play();
	}
	
	public void PlayHitAudio()
	{
		source.clip = hitClip;
		source.Play();		
	}
	
}
