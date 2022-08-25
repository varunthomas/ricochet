using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SceneGenerator : MonoBehaviour
{
	public static SceneGenerator instance;
	public GameObject tile;
	public GameObject cloneBall;
	GameObject clone;
	Rigidbody2D rbClone;
	GameObject[] brickArray;
	public int numBricks;
	public int remBalls = 1;
	const int MaxBricks = 1000;
	
	public Sprite specialSprite;
	private void Awake()
	{
		instance = this;
	}

    // Start is called before the first frame update
	//.324
    void Start()
    {
		
		brickArray = new GameObject[MaxBricks];
        Debug.Log("Start called");
		/*for(var i = -7.704f; i <= 7.704f; i=i+0.642f)
		{
			for(var j =0; j <3; j++)
			{
				brickArray[numBricks] = Instantiate(tile, new Vector2(i, j+1),Quaternion.identity) as GameObject;

					numBricks++;
			}
		}*/
		generateBricks();
		SceneGenerator.instance.toggleAllBricks(false);
		/*for(var i = -7.704f; i <= 7.704f; i=i+0.642f)
		{
			for(var j =0; j <10; j++)
			{
				if (Random.Range(0,2) == 1)
				{
					//Debug.Log("looping " + numBricks);
					brickArray[numBricks] = Instantiate(tile, new Vector2(i, 0.324f*j),Quaternion.identity) as GameObject;

					numBricks++;
				}					
			}
		}*/
		
		Debug.Log("Start finished");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isWin == true)
		{
			var balls = GameObject.FindGameObjectsWithTag("Ball");
			foreach (var ball in balls)
			{
				Destroy(ball);
			}
			Debug.Log("Destroyed balls");
			Debug.Log("Genrating bricks");
			generateBricks();
			setSpecialBrick();
			generateBall(5);
			GameManager.instance.remBricks = getBrickCount();
			remBalls = 1;
			Debug.Log("brick count " + GameManager.instance.remBricks);
			GameManager.instance.isWin = false;
		}
		//Debug.Log("count outside " + GameObject.FindGameObjectsWithTag("Ball").Length);
    }
	public void toggleAllBricks(bool toggle)
	{
		for(var i =0; i<numBricks; i++)
		{
			brickArray[i].gameObject.SetActive(toggle);
		}
	}
	
	public void setSpecialBrick()
	{
		for(var i =0; i<numBricks; i++)
		{
			if(Random.Range(0,5) == 0)
			{
				brickArray[i].gameObject.tag = "SpecialBrick";
				setSpecialSprite(brickArray[i]);
			}
		}
	}
	
	void setSpecialSprite(GameObject tempTile)
	{
		SpriteRenderer specialBrick;
		specialBrick = tempTile.GetComponent<SpriteRenderer>();
		specialBrick.sprite = specialSprite;
	}
	
	public int getBrickCount()
	{
		return numBricks;
	}
	public void generateBricks()
	{
		for(var i = -7.704f; i <= 7.704f; i=i+0.642f)
		{
			for(var j =0; j <10; j++)
			{
				if (Random.Range(0,2) == 1)
				{
					var v = new Vector2(i, 0.324f*j);
					Debug.Log("looping " + numBricks + " " + v);
					brickArray[numBricks] = Instantiate(tile, new Vector2(i, 0.324f*j),Quaternion.identity) as GameObject;

					numBricks++;
				}					
			}
		}		
	}

	public void generateBall(float bounceForce)
	{
		Vector2 initPosition = new Vector2(0,-3.08f);
		Vector2 randomDirection = new Vector2(-0.5f,1);
		clone = Instantiate(cloneBall, initPosition, Quaternion.identity);
		rbClone = clone.GetComponent<Rigidbody2D>();
		rbClone.AddForce(randomDirection*bounceForce, ForceMode2D.Impulse);
		//return Instantiate(cloneBall, dir, Quaternion.identity) as GameObject;
	}
}

