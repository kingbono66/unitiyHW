using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 20f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController pc = other.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.Die();
            }
        }
        if (other.CompareTag("Wall"))
        {
            transform.forward = Vector3.Reflect(transform.forward.normalized, (new Vector3(0, 0.5f, 0) - other.transform.position).normalized);
            rb.velocity = transform.forward * speed;
        }
    }
}
