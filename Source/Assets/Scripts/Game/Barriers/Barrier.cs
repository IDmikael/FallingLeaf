﻿using UnityEngine;

public class Barrier : MonoBehaviour
{
    //Parent class for all barriers

    protected float upForceValue = 0.1f;

    protected virtual void Update()
    {
        //Destroys object when its out of the screen
        if (transform.position.y > 15f || transform.position.y < -15f)
            Destroy(gameObject);

        //moves object up
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + upForceValue, 0);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "TheLeafMain")
        {
            Debug.Log("Game over, collider: " + gameObject.transform.parent);
            gameObject.transform.parent.gameObject.GetComponent<BarrierSpawner>().GameOver();
        }
            
    }
}
