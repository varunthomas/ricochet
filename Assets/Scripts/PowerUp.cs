using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

	float speed = 0.01f;
	float timer = 0f;
	//AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
		//source = GetComponent<AudioSource>();
		
		List<GameObject> objList = new List<GameObject>();
		GameObject[] brickObjects = GameObject.FindGameObjectsWithTag("Brick");
		GameObject[] spBrickObjects = GameObject.FindGameObjectsWithTag("SpecialBrick");
		GameObject[] pwBrickObjects = GameObject.FindGameObjectsWithTag("PowerBrick");
		GameObject[] ballObjects = GameObject.FindGameObjectsWithTag("Ball");
		objList.AddRange(brickObjects);
		objList.AddRange(spBrickObjects);
		objList.AddRange(pwBrickObjects);
		objList.AddRange(ballObjects);

        foreach (GameObject obj in objList) {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>()); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnCollisionEnter2D(Collision2D collision)
	{

			if(collision.gameObject.tag == "Paddle")
			{
				AudioManager.instance.PlayPowerUpAudio();
				Destroy(gameObject, 0.1f);
				GameManager.instance.startTimer  = true;
				GameManager.instance.timer = 0f;
				
				Debug.Log("starting timer");
				//setPowerUp(false);
			}
			else if(collision.gameObject.tag == "FallCheck")
			{
				Destroy(gameObject);
				Debug.Log("Destroy powerup failcheck");
			}
	}
}
