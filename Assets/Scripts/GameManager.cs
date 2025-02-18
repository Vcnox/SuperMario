using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InterfaceVariable { TIME, COINS, GOOMBAS};


public class GameManager : MonoBehaviour
{
    public static GameManager _isntance; // public static hace que sea accesible para todo el mundo y que solo haya una solo copia en tdo el programa 
    private float _currentGameTime = 0.0f;
    private int _coins = 0;
    private int _goombas = 0;


    void Awake()
    {
        if (!_isntance)
        {
            _isntance = this;
            DontDestroyOnLoad(gameObject); // no se destruye con la carga de escena
        }
        else
        {
            Destroy(gameObject); // si llega a aparecer cualquier otro se destruye
        }
    }

    // Update is called once per frame
    void Update()
    {
        _currentGameTime += Time.deltaTime;
        _currentGameTime = Mathf.Round(_currentGameTime * 100) / 100;
    }
    public float GetTime()
    {
        return _currentGameTime;
    }
    public void AddCoin(int value)
    {
        _coins += value;
    }
    public int GetCoins()
    {
        return _coins;
    }
    public void AddGoombaValue(int value)
    {
       _goombas += value;
    }
    public int GetGoombaValue()
    {
        return _goombas;
    }
}
