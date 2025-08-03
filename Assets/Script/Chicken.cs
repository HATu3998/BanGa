using System.Collections;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject EggPretabs;
    void Start()
    {
        
    }
    private void Awake()
    {
        StartCoroutine(SpawmEgg());
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawmEgg()
    {
        while (true)
        {
            Instantiate(EggPretabs, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(2, 7));
        }
    }
}
