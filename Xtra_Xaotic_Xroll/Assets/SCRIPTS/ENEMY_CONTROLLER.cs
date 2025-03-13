using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY_CONTROLLER : MonoBehaviour
{
    public float enemyHealth;
    public string targetTag = "YourBase"; // Tag del objetivo (la base)
    public float moveSpeed = 3f; // Velocidad de movimiento
    public float attackRange = 1.5f; // Rango de ataque
    public float attackCooldown = 1f; // Tiempo entre ataques
    private float lastAttackTime = 0f; // Tiempo del �ltimo ataque
    private Transform targetPosition; // Posici�n a la que se mover� el enemigo

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 10;

        // Buscar el GameObject con el tag "YourBase" y obtener su Transform
        GameObject targetObject = GameObject.FindGameObjectWithTag(targetTag);

        if (targetObject != null)
        {
            targetPosition = targetObject.transform; // Asignar la posici�n de la base
        }
        else
        {
            Debug.LogWarning("No se encontr� un objeto con el tag 'YourBase'.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Verificar la salud del enemigo
        if (enemyHealth <= 0)
        {
            Destroy(gameObject); // Eliminar el enemigo si su salud es 0 o menos
        }

        // Asegurarse de que el objetivo haya sido encontrado
        if (targetPosition != null)
        {
            // Mover al enemigo hacia la posici�n de destino
            MoveTowardsTarget();

            // Comprobar si est� en rango de ataque y puede atacar
            if (Vector3.Distance(transform.position, targetPosition.position) <= attackRange)
            {
                Attack();
            }
        }
    }

    // M�todo para mover al enemigo hacia la posici�n del objetivo
    private void MoveTowardsTarget()
    {
        // Mover al enemigo hacia la posici�n de destino
        Vector3 direction = (targetPosition.position - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
    }

    // M�todo de ataque
    private void Attack()
    {
        // Comprobar si el enemigo puede atacar (si ha pasado el tiempo de cooldown)
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            // Realizar el ataque
            Debug.Log("�El enemigo ataca!");

            // Actualizar el tiempo del �ltimo ataque
            lastAttackTime = Time.time;

            // Aqu� podr�as agregar m�s l�gica para aplicar da�o, como un sistema de salud al objetivo
        }
    }

    // M�todo para recibir da�o
    public void GetDamage()
    {
        enemyHealth -= 2;
        Debug.Log("El enemigo ha recibido da�o. Salud restante: " + enemyHealth);
    }
}
