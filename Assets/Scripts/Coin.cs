using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlatformMovement>())
        {
            GameManager._isntance.AddCoin(value);
            Debug.Log("Monedas:" + GameManager._isntance.GetCoins());
            Destroy(gameObject);
        }
    }
}
