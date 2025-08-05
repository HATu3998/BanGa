using System.Collections;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  [SerializeField]  public GameObject ShipPrefaps;
    public static ShipController Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnShip()
    {
 var newShip = Instantiate(ShipPrefaps, Camera.main.ViewportToWorldPoint(new Vector3(0.5f, -0.5f, 0)), Quaternion.identity);
        var point = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.1f, 0));
        point.z = 0;
        StartCoroutine(MoveShipToPoint(newShip, point));
    }
    IEnumerator MoveShipToPoint(GameObject ship , Vector3 point)
    {
        float timer = 0;
        while(ship && ship.transform.position != point)
        {
            timer += Time.fixedDeltaTime;
            ship.transform.position = Vector3.Lerp(ship.transform.position, point, timer);
            yield return new WaitForFixedUpdate();
        }
    }
}
