using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using interfaz;
using UnityEngine.Device;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [Header("Lógica")]
        public int VidasMax;
        public static int Vida;
        public CharacterController PlayerController;
        public PlayerController player;
        Vector3 Spawnposition;

        [Header("UI")]
        public TextMeshProUGUI textoVidas;
        public Win_Lose screenL;


        void Start()
        {
            Vida = VidasMax;
            //textoVidas = GetComponent<TextMeshProUGUI>();
            Spawnposition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            VidaTerminada();
            textoVidas.text = "Lives left: " + Vida;
        }

        private void OnTriggerEnter(Collider collision) //para boosters y killzone
        {
            if (collision.gameObject.CompareTag("KillZone"))
            {
                //SceneManager.LoadScene("Game");
                PlayerController.enabled = false;
                transform.position = Spawnposition;
                Time.timeScale = 1f;
                player.jumpForce = 6;
                Vida--;
                PlayerController.enabled = true;
            }
            if (collision.gameObject.CompareTag("Enemy"))
            {
                SceneManager.LoadScene("Game");
                Time.timeScale = 1f;
                Vida--;
            }
        }

        void VidaTerminada()
        {
            if (Vida == 0)
            {
                screenL.ActiveScreen();
            }
        }
    }
}
