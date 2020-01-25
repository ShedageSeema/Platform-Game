using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour {
    public float speed = 1.0f;
    public GameObject HUD;
	// Use this for initialization
	void Start () {
		
	}
	
	//late update function will call at the end so i can read the run after the calculation 
	void LateUpdate () {
        HUD.transform.position = new Vector3(transform.position.x,
            HUD.transform.position.y,
            transform.position.z);
	}//not changing the y position 

     void FixedUpdate()
    {
        transform.position = transform.position+
            transform.forward * Input.GetAxis("Vertical")+
            transform.right*Input.GetAxis("Horizontal");

    }
}
