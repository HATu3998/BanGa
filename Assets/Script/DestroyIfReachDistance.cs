using System;
using UnityEngine;

public class DestroyIfReachDistance : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    [SerializeField] private float DistancesDestroy;
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        DestroyIfTrue();
    }
    void DestroyIfTrue()
    {
        Vector3 CenterScreen = Camera.main.ScreenToWorldPoint(Vector3.zero);
        CenterScreen.z = 0;
        if (Vector3.Distance(CenterScreen, transform.position) > DistancesDestroy)
        {
           
            Destroy(this.gameObject);

        }
    }
}
