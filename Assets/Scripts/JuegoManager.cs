using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JuegoManager : MonoBehaviour
{

    // M�todo para regresar al men� principal
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

