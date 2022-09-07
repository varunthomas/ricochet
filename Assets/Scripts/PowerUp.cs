using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
	public static PowerUp instance;
	bool powerUpFlag;
	float speed = 0.01f;
	float timer = 0f;
	
	private void Awake()
	{
		instance = this;
	}
    // Start is called before the first frame update
    void Start()
    {
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
		if(powerUpFlag == true)
		{
			transform.position = new Vector2(transform.position.x , transform.position.y - speed);
		
			//TODO: Change hardcoding
			if (transform.position.y <= -5.77)
			{
				Debug.Log("Setting to false");
				Destroy(gameObject);
				setPowerUp(false);
			}
		}
        
    }
	
	private void OnCollisionEnter2D(Collision2D collision)
	{

			if(collision.gameObject.tag == "Paddle")
			{
				Destroy(gameObject);
				GameManager.instance.startTimer  = true;
				GameManager.instance.timer = 0f;
				Debug.Log("starting timer");
				setPowerUp(false);
			}
	}
	
	public void setPowerUp(bool isPowerUp)
	{
		powerUpFlag = isPowerUp;
	}
}
