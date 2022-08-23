using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//.32
public class Brick : MonoBehaviour
{
	float speed = 0.02f;
	float height = 0.01f;
	float startY;
	private bool hasCollided = false;
    // Start is called before the first frame update
    void Start()
    {
		startY = transform.position.y;
    }

    // Update is called once per frame
	void Update()
	{
		var pos = transform.position;
		var newY = startY - height*speed;//*Mathf.Sin(Time.time * speed);
		startY = newY;
		transform.position = new Vector3(pos.x, newY, pos.z);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ball")
		{
			if(hasCollided == true){ return; }
			hasCollided = true;
			Debug.Log("collided brick");
			GameManager.instance.ScoreUp(5);
			Debug.Log("Destroy brick");
			Destroy(gameObject);
		}
		else if(collision.gameObject.tag == "Paddle" || collision.gameObject.tag == "FallCheck")
		{
			GameManager.instance.Restart();
		}

	}
}
