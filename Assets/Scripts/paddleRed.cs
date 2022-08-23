using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleRed : MonoBehaviour
{
	
	float speed = 2f;
float height = 0.01f;
float startY = 1.62f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
void Update(){
    var pos = transform.position;
	//Debug.Log("time " + Mathf.Sin(Time.time * speed));
    var newY = startY - height*speed;//*Mathf.Sin(Time.time * speed);
    startY = newY;
	transform.position = new Vector3(pos.x, newY, pos.z);
}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Paddle" || col.gameObject.tag == "Ball")
		{
			Destroy(gameObject);
		}
	}
}
