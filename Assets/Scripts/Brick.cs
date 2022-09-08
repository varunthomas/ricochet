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

				clonePowerUpSprite = Instantiate(powerUpSprite, transform.position,Quaternion.identity);
				clonePowerUpSprite.tag = "PowerUpClone";
				Vector2 randomDirection = new Vector2(0,-1);
				var rbClonepw = clonePowerUpSprite.GetComponent<Rigidbody2D>();
				rbClonepw.AddForce(randomDirection*2, ForceMode2D.Impulse);
				//PowerUp.instance.setPowerUp(true);
				
			}
		}
		else if(collision.gameObject.tag == "Paddle" || collision.gameObject.tag == "FallCheck")
		{
			GameManager.instance.Restart();
		}

	}
}
