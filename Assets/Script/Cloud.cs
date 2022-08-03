using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float randomMinSpeed;
    public float randomMaxSpeed;
    private float speed;
    void Start()
    {
        speed = Random.Range(randomMinSpeed, randomMaxSpeed);
    }

    void Update()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
