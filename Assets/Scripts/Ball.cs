using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

	GameObject cloneBall;
	Rigidbody2D rb;
	Rigidbody2D rbClone;
	//private bool hasCollided = false;
	//private bool hasCollidedBrick = false;
	public float bounceForce = 5;
	public static bool startTimerFlag = false;
	public static bool resetTimer = false;
	float timer = 0f;
	float temp = 0f;
	public Button PlayButton;
	public Button AudioToggle;
	public static List<Ball> ballsClasses = new List<Ball>();

	void OnEnable()
	{
		GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("Ball");

        foreach (GameObject obj in otherObjects) {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>()); 
        }

	}
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	/*void LateUpdate()
	{
		this.hasCollided = false;
		this.hasCollidedBrick = false;
	}*/
	private void OnCollisionEnter2D(Collision2D collision)
	{

		if(collision.gameObject.tag == "FallCheck")
		{

			
			if (SceneGenerator.instance.remBalls == 1)
			{
				//Debug.Log("Restart called remballs 0");
				GameManager.instance.SetHighScore();
				GameManager.instance.Restart();
			}
			else
			{
				Destroy(gameObject);
				SceneGenerator.instance.remBalls--;
				//Debug.Log("rem balls " + SceneGenerator.instance.remBalls);
			}
		}
		else if (collision.gameObject.tag == "BoundaryLeft")
		{
			//Debug.Log("x " + transform.position.x + "y " + transform.position.y);
			if(Math.Abs(temp-transform.position.x) < 1.5f)
			{
				Debug.Log("perpendicular x " + transform.position.x + " y " + transform.position.y);
				Vector2 vec = new Vector2(transform.position.x, transform.position.y);
				
				vec.x = 3f;
				rb.AddForce(vec*bounceForce, ForceMode2D.Impulse);
			}	
			
			temp = transform.position.x;
			/*Vector2 vec = new Vector2(transform.position.x, transform.position.y);
			if(vec.x >0)
			{
				vec.x = 3f;
				
			}
			else
			{
				vec.x = -3f;
			}
			vec.y = -vec.y;
			rb.AddForce(vec*bounceForce,ForceMode2D.Impulse);*/
		}
		else if (collision.gameObject.tag == "BoundaryRight")
		{
			//Debug.Log("x " + transform.position.x + "y " + transform.position.y);
			if(Math.Abs(temp-transform.position.x) < 1)
			{
				Debug.Log("perpendicular right x " + transform.position.x + " y " + transform.position.y);
				Vector2 vec = new Vector2(transform.position.x, transform.position.y);
				
				vec.x = -3f;
				rb.AddForce(vec*bounceForce, ForceMode2D.Impulse);
			}	
			
			temp = transform.position.x;
			/*Vector2 vec = new Vector2(transform.position.x, transform.position.y);
			if(vec.x >0)
			{
				vec.x = 3f;
				
			}
			else
			{
				vec.x = -3f;
			}
			vec.y = -vec.y;
			rb.AddForce(vec*bounceForce,ForceMode2D.Impulse);*/
		}
		/*else if(collision.gameObject.tag == "Brick")
		{
					if(this.hasCollidedBrick == true){ Debug.Log("Has collided 1"); return; }
			this.hasCollidedBrick = true;
			//if(gameObject.tag == "SpecialBrick")
			//{
				//SceneGenerator.instance.remBalls++;
			//}
			Debug.Log("collided brick");
			GameManager.instance.ScoreUp(5);
			//Debug.Log("Destroy brick");
			Destroy(collision.gameObject);
		}
		else if(collision.gameObject.tag == "SpecialBrick")
		{
			if(this.hasCollided == true){ Debug.Log("Has collided 2"); return; }
			this.hasCollided = true;
			Debug.Log("Hit special brick ");
			SceneGenerator.instance.remBalls++;
			GameManager.instance.ScoreUp(5);
			Destroy(collision.gameObject);
			//Debug.Log("rem balls inc " + SceneGenerator.instance.remBalls);
			//var vec = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);
			clone = Instantiate(gameObject, transform.position,transform.rotation);
			
			//rbClone = clone.GetComponent<Rigidbody2D>();
			//rbClone.AddForce(vec*bounceForce, ForceMode2D.Impulse);

		}*/
		/*else if (collision.gameObject.tag == "Ball")
        {
			Physics2D.IgnoreCollision(collision.gameObject.GetComponent<PolygonCollider2D>(), gameObject.GetComponent<PolygonCollider2D>());
		}*/
	}
    // Start is called before the first frame update
    void Start()
    {
		ballsClasses.Add(this);
		/*if(startTimerFlag)
		{
			bounceForce = 2;
		}
		else
		{
			bounceForce = 5;
		}
		
		//startTimerFlag = false;
		rb.velocity = bounceForce* (rb.velocity.normalized);*/
		//Debug.Log("Reset bounce force in start");

    }

    // Update is called once per frame
    void Update()
    {
		rb.velocity = bounceForce* (rb.velocity.normalized);
		//Debug.Log("bounce force is " + bounceForce);
		if (!GameManager.instance.gameStarted)
		{
			if(Input.anyKeyDown)
			{

				StartBounce();
				//SceneGenerator.instance.generatePowerUp();
				PlayButton.gameObject.SetActive(true);
				AudioToggle.gameObject.SetActive(true);
				GameManager.instance.gameStarted = true;
				GameManager.instance.GameStart();
			}
		
		}
		
/*		if (startTimerFlag == true)
		{
			GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("Ball");

			if(resetTimer)
			{
				Debug.Log("Resetting timer because paddle took another power up");
				
				foreach (Ball obj in ballsClasses) {
					obj.timer = 0f;
				}
				resetTimer = false;
			}
		
        foreach (Ball obj in ballsClasses) {
			obj.bounceForce = 2;
			obj.timer += Time.deltaTime;
        }

			
			//Debug.Log("Timer is " + timer + " delta time is " + Time.deltaTime);
			if(timer >= 5f)
			{
				startTimerFlag = false;
       foreach (Ball obj in ballsClasses) {
			obj.bounceForce = 5;
			obj.timer = 0f;
			
        }
				Debug.Log("Stopping timer " + bounceForce);
				
			}
		}*/
		/*if (GameManager.instance.isWin == true)
		{
			var balls = GameObject.FindGameObjectsWithTag("Ball");
			foreach (var ball in balls)
			{
				Destroy(ball);
			}
			Debug.Log("Destroyed balls");
		}*/
    }

	void StartBounce()
	{
		
		/*float nonZero;
		
		while((nonZero = Random.Range(-1,1)) == 0 )
		{
		}
		Vector2 initPosition = new Vector2(0,-3.08f);
		Vector2 randomDirection = new Vector2(-0.5f,1);

		cloneBall = SceneGenerator.instance.generateBall(initPosition);
		rbClone = cloneBall.GetComponent<Rigidbody2D>();
		rbClone.AddForce(randomDirection*bounceForce, ForceMode2D.Impulse);*/
		SceneGenerator.instance.generateBall(bounceForce);
	}	

}
