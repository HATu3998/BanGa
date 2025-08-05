using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  [SerializeField]  private float speed;
    [SerializeField] private GameObject[] BulletList;
    [SerializeField] private int CurrentTierBullet;
    [SerializeField] private GameObject VFX;
    [SerializeField] private GameObject Shield;
     void Start()
    {
        StartCoroutine(DisableShield());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }
    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 Direction = new Vector3(x, y, 0);
        transform.position += Direction.normalized * Time.deltaTime * speed;

        Vector3 TopLeftPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, TopLeftPoint.x * -1, TopLeftPoint.x),
            Mathf.Clamp(transform.position.y, TopLeftPoint.y * -1, TopLeftPoint.y));
    }

    void Fire()
    {
        if(Input.GetMouseButtonDown(0))
        Instantiate(BulletList[CurrentTierBullet], transform.position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(!Shield.activeSelf && (collision.CompareTag("Chicken") || collision.CompareTag("Egg")))
        {
            Destroy(gameObject);
        }
    }
    IEnumerator DisableShield()
    {
        yield return new WaitForSeconds(8);
        Shield.SetActive(false);
    }

    private void OnDestroy()
    {
        if (gameObject.scene.isLoaded)
        {
        var vfx=    Instantiate(VFX, transform.position, Quaternion.identity);
            Destroy(vfx, 1f);
            ShipController.Instance.SpawnShip();
        }
    }
}
