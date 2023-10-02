using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruirPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("personagem")){
            Destroy(gameObject);            
        }
    }
}
