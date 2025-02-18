using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoombaMovement : MonoBehaviour
{
    public Transform mario; // Referencia a Mario
    public float speed = 2f; // Velocidad del Goomba
    public float stompThreshold = 0.5f; // Altura desde la que Mario puede destruir al Goomba
    public int value = 1;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento hacia Mario solo en el eje X
        if (mario != null)
        {
            Vector3 direction = (mario.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Determinar si Mario golpea al Goomba por arriba
            float marioY = collision.transform.position.y;
            float goombaY = transform.position.y;

            if (marioY > goombaY + stompThreshold)
            {
                // Mario salta sobre el Goomba -> Destruir al Goomba
                Destroy(gameObject);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
   
}
