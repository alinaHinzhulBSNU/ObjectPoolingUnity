using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    float delay = 0;
    float interval = 0.5f;

    string[] poolTags = { "BlueGems", "RoseGems", "YellowGems" };
    
    public void Start()
    {
        objectPooler = ObjectPooler.Instance;
        InvokeRepeating("SpawnGems", delay, interval);
    }

    void SpawnGems()
    {
        int index = Random.Range(0, poolTags.Length); // select type of gem randomly
        objectPooler.SpawnFromPool(poolTags[index]);
    }
}
