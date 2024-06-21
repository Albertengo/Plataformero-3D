using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Player;

namespace interfaz
{
    public class Botones : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene("Game");
            Time.timeScale = 1f;
            PlayerHealth.Vida = 3;
        }
        public void Menu()
        {
            SceneManager.LoadScene("Menú");
        }
        public void PlayButton()
        {
            SceneManager.LoadScene("Game");
            Time.timeScale = 1f;
        }
        public void QuitGame()
        {
            Debug.Log("Saliste.");
            Application.Quit();
        }
    }
}
