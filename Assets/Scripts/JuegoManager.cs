using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JuegoManager : MonoBehaviour
{

    // Método para regresar al menú principal
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

