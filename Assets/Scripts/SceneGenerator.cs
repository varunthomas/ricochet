using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SceneGenerator : MonoBehaviour
{
	public static SceneGenerator instance;
	public GameObject tile;
	GameObject[] brickArray;
	private int numBricks;
	const int MaxBricks = 130;
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
		for(var i = -2.568f; i <= 4.494f; i=i+0.642f)
		{
			for(var j =0; j <10; j++)
			{
				if (Random.Range(0,2) == 1)
				{
					Debug.Log("looping " + numBricks);
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
	public int getBrickCount()
	{
		return numBricks;
	}
	
}
