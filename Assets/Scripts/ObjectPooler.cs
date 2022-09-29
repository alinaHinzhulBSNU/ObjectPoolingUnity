using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    // Pool of objects class
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    // All pools
    [SerializeField]
    List<Pool> pools;
    
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // Singleton
    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitPoolDictionary();
    }

    void InitPoolDictionary()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> queue = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject gem = InstantiateGem(pool.prefab);
                queue.Enqueue(gem);
            }

            poolDictionary.Add(pool.tag, queue);
        }
    }

    GameObject InstantiateGem(GameObject prefab)
    {   
        return Instantiate(prefab, prefab.transform.position, prefab.transform.rotation);
    }

    public void SpawnFromPool(string tag)
    {
        if (poolDictionary.ContainsKey(tag))
        {
            GameObject gem = poolDictionary[tag].Dequeue();
            
            gem.SetActive(true);
            poolDictionary[tag].Enqueue(gem);
        }
        else
        {
            Debug.Log("Invalid Tag!");
        }
    }
}
