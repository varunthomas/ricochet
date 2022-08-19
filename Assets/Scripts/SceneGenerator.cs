using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SceneGenerator : MonoBehaviour
{
	public static SceneGenerator instance;
	public GameObject tile;
	GameObject[] brickArray;
	private int x;
	private void Awake()
	{
		instance = this;
	}

    // Start is called before the first frame update
    void Start()
    {
		brickArray = new GameObject[8];
        Debug.Log("Start called");
		for(var i = -1.926f; i <= 2.568f; i=i+0.642f)
		{
			Debug.Log("looping " + x);
			brickArray[x] = Instantiate(tile, new Vector2(i, 3),Quaternion.identity) as GameObject;
			x++;

			
			
			
		}
		
		Debug.Log("Start finished");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void toggleAllBricks(bool toggle)
	{
		for(var i =0; i<x; i++)
		{
			brickArray[i].gameObject.SetActive(toggle);
		}
	}
	public int getBrickCount()
	{
		return x;
	}
	
}
