using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform respawnPoint;
    public GameObject player;
    public GameObject deadPlayer;
    public void Respawn()
    {
        var dead = Instantiate(deadPlayer);
        dead.transform.position = player.transform.position;
        player.transform.position = respawnPoint.position;
    }
}
