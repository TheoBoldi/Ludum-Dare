using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerController : MonoBehaviour
{
    public Animator anim;

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

            if (dirX > 0 && entity.IsOnground())
            {
                anim.SetTrigger("Right");
            }

            if (dirX < 0 && entity.IsOnground())
            {
                anim.SetTrigger("Left");
            }
        }
        entity.Move(dirX);

        if (dirX == 0 && entity.IsOnground())
        {
            anim.SetTrigger("Idle");
        }

        if (_mainPlayer.GetButtonDown("Jump") && entity.IsOnground())
        {
            entity.Jump();
        }
        if (_mainPlayer.GetButtonUp("Jump") && entity.IsJumping())
        {
            entity.StopJump();
        }

        if (entity.IsJumping())
        {
            anim.SetTrigger("Jump");
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
