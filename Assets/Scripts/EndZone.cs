using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
    public GameObject timer;
    public GameObject end;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;
            timer.SetActive(false);

            if (SceneManager.GetActiveScene().buildIndex == 11)
            {
                TransitionController.instance?.FadeIn(() => SceneManager.LoadScene(0));
            }
            else
            {
                TransitionController.instance?.FadeIn(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
            }
        }
    }
}
