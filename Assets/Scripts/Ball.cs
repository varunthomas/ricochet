using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

	Rigidbody2D rb;
	bool gameStarted;
	public float bounceForce;
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{

		if(collision.gameObject.tag == "FallCheck")
		{
			GameManager.instance.Restart();
		}
		else if(collision.gameObject.tag == "Paddle")
		{
			GameManager.instance.ScoreUp(1);
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
		if (!gameStarted)
		{
			if(Input.anyKeyDown)
			{
			
				StartBounce();
				gameStarted = true;
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
		Debug.Log("x dir" + nonZero);
		Vector2 randomDirection = new Vector2(nonZero,1);
		rb.AddForce(randomDirection*bounceForce, ForceMode2D.Impulse);
	}	

}
