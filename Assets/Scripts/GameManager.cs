﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator anim;

    public AudioSource dead;

    public float timer;
    private float initTimer;
    public Text timerText;

    public Transform respawnPoint;
    public GameObject player;
    public GameObject deadPlayer;

    private void Start()
    {
        Time.timeScale = 1;
        initTimer = timer;
        StartCoroutine(Timer());
        TransitionController.instance?.FadeOut();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F0");
    }

    public void Respawn()
    {
        if (NoSpawn.canspawn)
        {
            var dead = Instantiate(deadPlayer);
            dead.transform.position = player.transform.position - new Vector3(0,0.08f,0);
        }

        anim.SetTrigger("Respawn");

        player.transform.position = respawnPoint.position;
        timer = initTimer;
        StartCoroutine(Timer());
    }

    public void Die()
    {
        player.transform.position = respawnPoint.position;
        timer = initTimer;

        anim.SetTrigger("Respawn");
        dead.Play();
    }

    public void Reset()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public IEnumerator Timer()
    {
        yield return new WaitUntil(() => timer <= 0);
        dead.Play();
        Respawn();
    }

    public void NextScene()
    {
        if(SceneManager.GetActiveScene().buildIndex == 11)
        {
            TransitionController.instance?.FadeIn(() => SceneManager.LoadScene(0));
        }
        else
        {
            TransitionController.instance?.FadeIn(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
