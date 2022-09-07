using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
	Rigidbody2D rb;
	public float bounceForce = 5;
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

		}

	}
    // Start is called before the first frame update
    void Start()
    {
		ballsClasses.Add(this);
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
