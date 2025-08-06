using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject EggPrefabs;
    void Start()
    {
        StartCoroutine(eggSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator eggSpawn()
    {
        while (true)
        {
            Instantiate(EggPrefabs, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.0f, 2.0f));
        }
    }
}
