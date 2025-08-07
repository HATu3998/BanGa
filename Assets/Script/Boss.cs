using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject EggPrefabs;
    [SerializeField] private int health = 100;
    [SerializeField] private GameObject VFX;
    public static Boss instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(eggSpawn());
        StartCoroutine(MoveBossToRandomPoint());
    }
    public void PutDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
            var vfx = Instantiate(VFX, transform.position, Quaternion.identity);
            Destroy(vfx, 1f);   
        }
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

    IEnumerator MoveBossToRandomPoint()
    {
        Vector3 point = getRandomPoint();
        while (transform.position != point)
        {
            transform.position = Vector3.MoveTowards(transform.position, point, 0.1f);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        StartCoroutine(MoveBossToRandomPoint());
    }

    Vector3 getRandomPoint()
    {
        Vector3 posRandom = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0, 1f), Random.Range(0.5f, 1f)));
        posRandom.z = 0;
        return posRandom;
    }
}
