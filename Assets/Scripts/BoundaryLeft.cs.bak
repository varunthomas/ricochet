using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryLeft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
		Debug.Log(stageDimensions.x + " " + stageDimensions.y);
		transform.position = new Vector3(-stageDimensions.x-0.39f,0,0);
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
