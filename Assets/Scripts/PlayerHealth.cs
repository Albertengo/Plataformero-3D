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
        public Win_Lose screenW;


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
                PlayerController.enabled = false;
                transform.position = Spawnposition;
                Time.timeScale = 1f;
                //player.jumpForce = 6; //para que no existan errores con las variables 
                //player.moveSpeed = 8;
                Vida--;
                PlayerController.enabled = true;
            }
            //if (collision.gameObject.CompareTag("Enemy"))
            //{
            //    SceneManager.LoadScene("Game");
            //    Time.timeScale = 1f;
            //    Vida--;
            //}
            if (collision.gameObject.CompareTag("Goal"))
            {
                screenW.ActiveScreen();
                Debug.Log("Ganaste!");
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
