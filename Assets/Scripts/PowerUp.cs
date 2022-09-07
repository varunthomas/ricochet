using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
	public static PowerUp instance;
	Vector2 pos;
	bool powerUpFlag;
		float startY;
	float height = 3f;
	
	float speed = 0.01f;
	float timer = 0f;
	bool startTimerFlag;
	
	private void Awake()
	{
		instance = this;
	}
    // Start is called before the first frame update
    void Start()
    {
		Debug.Log("Activiatng power up in powerup");
		//gameObject.SetActive(true);
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
        startY = transform.position.y;
		Debug.Log("Instatiated power up start timer should be called next");
    }

    // Update is called once per frame
    void Update()
    {
		/*if (GameManager.instance.isWin == true)
		{
			Destroy(gameObject);
		}*/
		
		/*if (!GameManager.instance.gameStarted)
		{
			Instantiate(powerUpSprite, new Vector2(-12.77f, -0.37f),Quaternion.identity);
			GameManager.instance.gameStarted = true;
		}	*/		
		if(powerUpFlag == true)
		{
			//var newY = startY - height*speed;//*Mathf.Sin(Time.time * speed);
			//startY = newY;
			//transform.position = new Vector2(transform.position.x, newY);
			//speed+=0.0001f;
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
				//Ball.startTimerFlag = true;
				//Ball.resetTimer = true;
				GameManager.instance.startTimer  = true;
				GameManager.instance.timer = 0f;
				Debug.Log("starting timer");
				setPowerUp(false);
			}
	}
	
	public void setStartPos(Vector2 position)
	{
		pos = position;
	}
	public Vector2 getStartPos()
	{
		return pos;
	}
	public void setPowerUp(bool isPowerUp)
	{
		powerUpFlag = isPowerUp;
	}
}
