using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    // Spawn settings
    float xRange = 10;
    float height = 2.0f;
    float zRange = 10;

    // Movement settings
    float speed = 8.0f;

    private void Start()
    {
        ResetPosition(); // initial position
    }

    private void FixedUpdate()
    {
        if (transform.position.z < -zRange) ResetPosition(); // reset if it is invisible for user
        transform.Translate(Vector3.down * Time.deltaTime * speed); // move
    }

    void ResetPosition() // initial state of the gem
    {
        gameObject.SetActive(false);
        gameObject.transform.position = RandomPosition();
    }

    Vector3 RandomPosition() // for x-axis
    {
        return new Vector3(Random.Range(-xRange, xRange), height, zRange);
    }
}
