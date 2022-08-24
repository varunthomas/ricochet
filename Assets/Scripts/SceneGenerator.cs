using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SceneGenerator : MonoBehaviour
{
	public static SceneGenerator instance;
	public GameObject tile;
	GameObject[] brickArray;
	private int numBricks;
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
		for(var i = -7.704f; i <= 7.704f; i=i+0.642f)
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
		}
		
		Debug.Log("Start finished");
    }

    // Update is called once per frame
    void Update()
    {
        
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
	
}
