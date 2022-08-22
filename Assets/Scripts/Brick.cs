using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//.32
public class Brick : MonoBehaviour
{
	private bool hasCollided = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
	/*void LateUpdate()
	{
		this.hasCollided = false;
	}*/
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

	}
}
