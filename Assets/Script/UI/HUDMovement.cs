using UnityEngine;

public class HUDMovement : MonoBehaviour
{
    public float speed = 1.0f;  // Velocidade do movimento
    public float height = 100.0f;  // Altura do movimento
    public bool isMovingUp = true;  // Define a direção inicial do movimento

    void Update()
    {
        // Mover o elemento HUD na direção e velocidade definidas
        if (isMovingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        // Verificar se o elemento HUD atingiu o limite superior ou inferior da tela
        if (transform.position.y >= height)
        {
            isMovingUp = false;
        }
        else if (transform.position.y <= 0)
        {
            isMovingUp = true;
        }
    }
}
