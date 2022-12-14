using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
	Rigidbody2D rb;
	public float bounceForce = 5;
	public Button PlayButton;
	float rightHit, leftHit;
	public Button AudioToggle;
	bool lastSideHit;
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
				SceneGenerator.instance.remBalls--;
				//Debug.Log("rem balls " + SceneGenerator.instance.remBalls);
			}
			Destroy(gameObject);
		}
		else if (collision.gameObject.tag == "BoundaryLeft")
		{
			leftHit = transform.position.y;
			if (lastSideHit == true)
			{
				
				if(Math.Abs(leftHit - rightHit) < 0.5f)
				{
					//Debug.Log("perpendicular x " + transform.position.x + " y " + transform.position.y);
					Vector2 vec = new Vector2(transform.position.x, transform.position.y);
				
					vec.x = 3f;
					rb.AddForce(vec*bounceForce, ForceMode2D.Impulse);					
				}
			}
			lastSideHit = true;

		}
		else if (collision.gameObject.tag == "BoundaryRight")
		{
			rightHit = transform.position.y;
			if (lastSideHit == true)
			{
				
				if(Math.Abs(leftHit - rightHit) < 0.5f)
				{
					//Debug.Log("perpendicular x " + transform.position.x + " y " + transform.position.y);
					Vector2 vec = new Vector2(transform.position.x, transform.position.y);
				
					vec.x = -3f;
					rb.AddForce(vec*bounceForce, ForceMode2D.Impulse);					
				}
			}
			lastSideHit = true;
		}
		else if (collision.gameObject.tag == "Paddle")
		{
			lastSideHit = false;
			AudioManager.instance.PlayHitAudio();
		}
		else
		{
			lastSideHit = false;
		}

	}
    // Start is called before the first frame update
    void Start()
    {
		ballsClasses.Add(this);
		GameObject[] powerUps = GameObject.FindGameObjectsWithTag("PowerUpClone");
        foreach (GameObject obj in powerUps) {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>()); 
        }		
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
    }

	void StartBounce()
	{
		SceneGenerator.instance.generateBall(bounceForce);
	}	
}
