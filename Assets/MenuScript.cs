using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (this.gameObject.name.Contains("Start"))
            {
                TransitionController.instance?.FadeIn(() => SceneManager.LoadScene(1));
            }
            if (this.gameObject.name.Contains("End"))
            {
                Application.Quit();
            }
        }
    }
}
