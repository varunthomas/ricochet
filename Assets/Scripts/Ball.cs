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
		Debug.Log("Collison");
		if(collision.gameObject.tag == "FallCheck")
		{
			Debug.Log("Restart");
			GameManager.instance.Restart();
		}
		else if(collision.gameObject.tag == "Paddle")
		{
			GameManager.instance.ScoreUp();
			Debug.Log("No restart");
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
		Debug.Log("Vel " + rb.velocity);
	if (!gameStarted)
	{
		if(Input.anyKeyDown)
		{
			
			StartBounce();
			gameStarted = true;
			GameManager.instance.GameStart();
		}
		
	}
        
    }

	void StartBounce()
	{
		
		Vector2 randomDirection = new Vector2(Random.Range(-1,1),1);
		rb.AddForce(randomDirection*bounceForce, ForceMode2D.Impulse);
	}	

}
