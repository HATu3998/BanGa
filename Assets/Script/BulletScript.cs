using System;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   [SerializeField] private float Speed;
    [SerializeField] private float DistancesDestroy;
     void Start()
    {
        DistancesDestroy = 10 ;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
         DestroyIfReachDistances();
    }
    void DestroyIfReachDistances()
    {
        Vector3 CenterScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2),0);
        if  (Vector3.Distance(CenterScreen, transform.position) > DistancesDestroy){
            Console.WriteLine("xoa");
            Destroy(this.gameObject);

        }
    }
}
