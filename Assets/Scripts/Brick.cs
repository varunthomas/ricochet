using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//.32
public class Brick : MonoBehaviour
{

	float startY;
	float height = 3f;
	float speed = 1f;
	Rigidbody2D rbClone;
	GameObject clone;
	private float bounceForce = 5f;
	private bool hasCollided = false;
	bool powerUpHit = false;
	public GameObject powerUpSprite;
	GameObject clonePowerUpSprite;
	Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
		startY = transform.position.y;
		
		
    }

	void LateUpdate()
	{
		this.hasCollided = false;
	}
    // Update is called once per frame
	void Update()
	{


		/*var pos = transform.position;
		var newY = startY - height*speed;//*Mathf.Sin(Time.time * speed);
		startY = newY;
		transform.position = new Vector3(pos.x, newY, pos.z);*/
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ball")
		{
			if(this.hasCollided == true){ Debug.Log("Has collided 1"); return; }
			this.hasCollided = true;
			//Debug.Log("collided brick");
			GameManager.instance.ScoreUp(5);
			//Debug.Log("Destroy brick");
			Destroy(gameObject);
			if(gameObject.tag == "SpecialBrick")
			{
				SceneGenerator.instance.remBalls++;
				var vec = transform.position;
				vec.x = vec.x+1;
				vec.y = vec.y+1;
				clone = Instantiate(collision.gameObject, collision.gameObject.transform.position,collision.gameObject.transform.rotation);
				rbClone = clone.GetComponent<Rigidbody2D>();
				rbClone.AddForce(vec*bounceForce, ForceMode2D.Impulse);
			}
			if(gameObject.tag == "PowerBrick")
			{

				//powerUpHit = true;
				clonePowerUpSprite = Instantiate(powerUpSprite, transform.position,Quaternion.identity);
				clonePowerUpSprite.tag = "PowerUpClone";
				PowerUp.instance.setStartPos(transform.position);
				PowerUp.instance.setPowerUp(true);
				Physics2D.IgnoreCollision(clonePowerUpSprite.GetComponent<Collider2D>(), GetComponent<Collider2D>()); 
				
			}
		}
		else if(collision.gameObject.tag == "Paddle" || collision.gameObject.tag == "FallCheck")
		{
			GameManager.instance.Restart();
		}

	}
}
