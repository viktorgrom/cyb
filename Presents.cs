using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presents : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
            Destroy(gameObject);
    }
}
