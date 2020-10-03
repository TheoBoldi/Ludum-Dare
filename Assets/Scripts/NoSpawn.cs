using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSpawn : MonoBehaviour
{
    public static bool canspawn;

    private void Start()
    {
        canspawn = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("cant spawn");
            canspawn = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("can spawn");
            canspawn = true;
        }
    }
}
