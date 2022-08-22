using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

	GameObject clone;
	Rigidbody2D rb;
	Rigidbody2D rbClone;
	public float bounceForce;
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
				Debug.Log("Restart called remballs 0");
				GameManager.instance.Restart();
			}
			else
			{
				Destroy(gameObject);
				SceneGenerator.instance.remBalls--;
			}
		}
		else if(collision.gameObject.tag == "Paddle")
		{
			GameManager.instance.ScoreUp(1);
		}
		else if(collision.gameObject.tag == "SpecialBrick")
		{
			//Debug.Log("Hit special brick " + gameObject.tag);
			SceneGenerator.instance.remBalls++;
			var vec = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);
			clone = Instantiate(gameObject, vec,Quaternion.identity);
			rbClone = clone.GetComponent<Rigidbody2D>();
			rbClone.AddForce(vec*bounceForce, ForceMode2D.Impulse);
		}
		else if (collision.gameObject.tag == "Ball")
        {
			Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CircleCollider2D>(), gameObject.GetComponent<CircleCollider2D>());
		}
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		rb.velocity = bounceForce* (rb.velocity.normalized);
		if (!GameManager.instance.gameStarted)
		{
			if(Input.anyKeyDown)
			{
			
				StartBounce();
				GameManager.instance.gameStarted = true;
				GameManager.instance.GameStart();
			}
		
		}
		/*if (GameManager.instance.isWin == true)
		{
			Debug.Log("win true");
			//Dstroy(gameObject);
			if(Input.anyKeyDown)
			{
				GameManager.instance.Restart();
			}
		}*/
    }

	void StartBounce()
	{
		float nonZero;
		while((nonZero = Random.Range(-1,1)) == 0 )
		{
		}
		Vector2 randomDirection = new Vector2(nonZero,1);
		rb.AddForce(randomDirection*bounceForce, ForceMode2D.Impulse);
	}	

}
