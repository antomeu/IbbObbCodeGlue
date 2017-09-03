using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform Player;
    public float MinTreshold = 4;
          
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x - Player.transform.position.x >= MinTreshold)
            transform.position = new Vector3(Player.transform.position.x + MinTreshold,transform.position.y,transform.position.z);
        if (Player.transform.position.x - transform.position.x  >= MinTreshold)
            transform.position = new Vector3(Player.transform.position.x - MinTreshold, transform.position.y, transform.position.z);
    }
}
