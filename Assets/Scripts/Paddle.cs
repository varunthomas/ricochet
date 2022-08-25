using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

	Rigidbody2D rb;
	public float moveSpeed;
	Vector2 originalPos;
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
    // Start is called before the first frame update
    void Start()
    {
		originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);   
    }

    // Update is called once per frame
    void Update()
    {


    }
	private void FixedUpdate()
	{
		/*if (GameManager.instance.isWin == true)
		{
			rb.constraints = RigidbodyConstraints2D.FreezeAll;
		}
		else
		{
			rb.constraints = RigidbodyConstraints2D.None;
			rb.freezeRotation = true;
			rb.constraints = RigidbodyConstraints2D.FreezePositionY;
		}*/
		TouchMove();
		
	}
	void TouchMove()
	{
		if(GameManager.instance.isWin == false && Input.GetMouseButton(0))
		{
			Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if(touchPos.x < 0)
			{
				rb.velocity = Vector2.left*moveSpeed;
			}
			else
			{
				rb.velocity = Vector2.right*moveSpeed;
			}
		}
		else if( GameManager.instance.isWin == true)
		{
			transform.position = originalPos;
			rb.velocity = Vector2.zero;
		}
		else
		{
			rb.velocity = Vector2.zero;
		}
	}
}
