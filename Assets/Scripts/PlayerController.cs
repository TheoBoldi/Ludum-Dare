using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerController : MonoBehaviour
{
    public string playerName;

    public PlayerEntity entity;
    public GameManager gameManager;
    private Player _mainPlayer;

    void Start()
    {
        _mainPlayer = ReInput.players.GetPlayer(playerName);
    }

    void Update()
    {
        float dirX = _mainPlayer.GetAxis("MoveHorizontal");
        if (dirX != 0f)
        {
            dirX = Mathf.Sign(dirX);
        }
        entity.Move(dirX);

        if (_mainPlayer.GetButtonDown("Jump") && entity.IsOnground())
        {
            entity.Jump();
        }
        if (_mainPlayer.GetButtonUp("Jump") && entity.IsJumping())
        {
            entity.StopJump();
        }

        if (_mainPlayer.GetButtonDown("Respawn") && NoSpawn.canspawn)
        {
            gameManager.Respawn();
        }

        if (_mainPlayer.GetButtonDown("Reset"))
        {
            gameManager.Reset();
        }
    }
}
