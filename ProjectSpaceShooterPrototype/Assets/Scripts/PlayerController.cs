using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //PLAYER MOVEMENT VARIABLE
    public float playerSpeed;

    //PROJECTILE VARIABLE
    public GameObject Bullet;
    public float rateOfFire;
    public float bulletSpeed;

	// Use this for initialization
	void Start () {
		
	}

    void Shooting()
    {
        Vector3 startPosition = transform.position + new Vector3(0, 0.4f, 0);
        GameObject attack = Instantiate(Bullet, startPosition, Quaternion.identity) as GameObject;
        attack.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletSpeed, 0);
    }
	
	// Update is called once per frame
	void Update () {

        //MOVEMENT CONTROLS
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.left * playerSpeed * Time.deltaTime;
        }

        //SHOOTING
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Shooting", 0.0001f, rateOfFire);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Shooting");
        }
    }
}
